using UnityEngine;
using InteractionSystem.Core;

public class Door : MonoBehaviour, IInteractable
{
    #region Fields

    [Header("Door Settings")]
    [SerializeField] private Transform pivotPoint;
    [SerializeField] private float openAngle = 90f;

    private readonly InteractionType m_InteractionType = InteractionType.Toggle;

    private bool isOpen = false;

    #endregion

    #region IInteractable Implementation
    InteractionType IInteractable.InteractionType => m_InteractionType;

    public void InteractInstant()
    {
    }

    public void InteractHold(float holdProgress)
    {
        // Şimdilik kullanılmıyor
    }

    public void InteractToggle()
    {
        ToggleDoor();
    }
    #endregion

    #region Private Methods
    private void ToggleDoor()
    {
        if (pivotPoint == null)
        {
            Debug.LogWarning($"{name} Door has no pivot point assigned.");
            return;
        }

        float targetAngle = isOpen ? 0f : openAngle;

        pivotPoint.localRotation = Quaternion.Euler(0f, targetAngle, 0f);

        isOpen = !isOpen;
        Debug.Log(isOpen);
    }
    #endregion
} 
