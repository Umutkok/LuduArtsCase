using UnityEngine;
using InteractionSystem.Core;

public class InteractionDetector : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Vector3 interactionRayPoint = Vector3.zero;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float interactionRange = 3f;
    [SerializeField] private float holdDuration = 2f;

    private IInteractable currentInteractable;
    private InteractionType currentInteractionType;

    private float holdTimer;

    private void Update()
    {
        DetectInteractable();
        HandleInput();
    }

    private void DetectInteractable()
    {
        Ray ray = new Ray(
            playerCamera.transform.position + interactionRayPoint,
            playerCamera.transform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange, interactableLayer))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                currentInteractable = interactable;

                // Interactable objeden type al
                currentInteractionType =
                    hit.collider.GetComponent<MonoBehaviour>() is var mb &&
                    mb is { } &&
                    mb.GetType().GetProperty("InteractionType") != null
                        ? (InteractionType)mb
                            .GetType()
                            .GetProperty("InteractionType")!
                            .GetValue(mb)
                        : InteractionType.Instant;

                return;
            }
        }

        ResetInteraction();
    }

    private void HandleInput()
    {
        if (currentInteractable == null)
            return;

        switch (currentInteractionType)
        {
            case InteractionType.Instant:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentInteractable.InteractInstant();
                }
                break;

            case InteractionType.Toggle:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentInteractable.InteractToggle();
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
            holdTimer += Time.deltaTime;

            float holdProgress = Mathf.Clamp01(holdTimer / holdDuration);
            currentInteractable.InteractHold(holdProgress);

            if (holdProgress >= 1f)
            {
                holdTimer = 0f;
            }
        }
        else
        {
            holdTimer = 0f;
        }
    }

    private void ResetInteraction()
    {
        currentInteractable = null;
        holdTimer = 0f;
    }
}
