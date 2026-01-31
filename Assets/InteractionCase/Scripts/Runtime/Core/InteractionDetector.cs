using UnityEngine;
using InteractionSystem.Core;

namespace InteractionSystem.Player
{
    /// <summary>
    /// Raycast-based interaction detector.
    /// Reads InteractionType from IInteractable.
    /// Handles Instant, Toggle and Hold interactions.
    /// </summary>
    public class InteractionDetector : MonoBehaviour
    {
        #region Serialized Fields

        [Header("References")]
        [SerializeField] private Camera m_PlayerCamera;

        [Header("Raycast")]
        [SerializeField] private Vector3 m_InteractionRayPoint = Vector3.zero;
        [SerializeField] private LayerMask m_InteractableLayer;
        [SerializeField] private float m_InteractionRange = 3f;

        [Header("Hold")]
        [SerializeField] private float m_HoldDuration = 2f;

        #endregion

        #region Private Fields

        private IInteractable m_CurrentInteractable;
        private InteractionType m_CurrentInteractionType;
        private float m_HoldTimer;

        #endregion

        #region Unity Methods

        private void Update()
        {
            DetectInteractable();
            HandleInput();
        }

        #endregion

        #region Detection

        private void DetectInteractable()
        {
            if (m_PlayerCamera == null)
            {
                Debug.LogError("InteractionDetector: PlayerCamera not assigned.", this);
                return;
            }

            Ray ray = new Ray(m_PlayerCamera.transform.position + m_InteractionRayPoint,
                            m_PlayerCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, m_InteractionRange, m_InteractableLayer))
            {
                // Try get the IInteractable directly (safe, no reflection)
                if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
                {
                    // Şu an etkileşimde olduğumuz obje
                    m_CurrentInteractable = interactable;

                    // etkileşim türü
                    m_CurrentInteractionType = interactable.InteractionType;

                    return;
                }
            }

            ResetInteraction();
        }

        #endregion

        #region Input Handling

        private void HandleInput()
        {
            if (m_CurrentInteractable == null) return;

            switch (m_CurrentInteractionType)
            {
                case InteractionType.Instant:
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        m_CurrentInteractable.InteractInstant();
                    }
                    break;

                case InteractionType.Toggle:
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        m_CurrentInteractable.InteractToggle();
                    }
                    break;

                case InteractionType.Hold:
                    HandleHoldInteraction();
                    break;
            }
        }

        private void HandleHoldInteraction()
        {
            if (Input.GetKey(KeyCode.E))
            {
                m_HoldTimer += Time.deltaTime;
                float holdProgress = Mathf.Clamp01(m_HoldTimer / Mathf.Max(0.0001f, m_HoldDuration));

                m_CurrentInteractable.InteractHold(holdProgress);

                if (holdProgress >= 1f)
                {
                    // Completed hold -> reset timer or keep depending on design
                    m_HoldTimer = 0f;
                }
            }
            else
            {
                // Released before complete
                if (m_HoldTimer > 0f)
                {
                    // Optionally notify with 0 or partial progress
                    m_CurrentInteractable.InteractHold(0f);
                }

                m_HoldTimer = 0f;
            }
        }

        #endregion

        #region Helpers

        private void ResetInteraction()
        {
            m_CurrentInteractable = null;
            m_HoldTimer = 0f;
        }

        #endregion
    }
}

