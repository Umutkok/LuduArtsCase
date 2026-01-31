using UnityEngine;
using InteractionSystem.Core;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    [SerializeField] private Transform pivotPoint;
    [SerializeField] private float openAngle = 90f;

    private bool isOpen;

    public void InteractInstant()
    {
        ToggleDoor();
        Debug.Log("InteractInstant");
    }

    public void InteractHold(float holdProgress)
    {
        // Şimdilik kullanılmıyor
    }

    public void InteractToggle()
    {
        // Şimdilik kullanılmıyor
    }

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
    }
} 
