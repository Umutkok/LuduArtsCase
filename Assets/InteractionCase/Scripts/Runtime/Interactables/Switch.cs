using UnityEngine;
using UnityEngine.Events;
using InteractionSystem.Core;

public class Switch : MonoBehaviour, IInteractable
{
    #region Fields

    [Header("Switch Settings")]
    [SerializeField] private Transform m_PivotPoint;
    [SerializeField] private UnityEvent m_OnSwitchToggled;
    private bool m_IsOn;

    private readonly InteractionType m_InteractionType = InteractionType.Toggle;

    #endregion

    #region Private Methods
    
    private void ToggleSwitch()
    {
        if (m_PivotPoint == null)
        {
            Debug.LogWarning($"{name} Switch has no pivot point assigned.");
            return;
        }

        float targetAngle = m_IsOn ? 0f : -30f;
        m_PivotPoint.localRotation = Quaternion.Euler(targetAngle, 0f, 0f);

        m_IsOn = !m_IsOn;
    }

    #endregion

    #region IInteractable Implementation
    bool IInteractable.CanInteract => true;
    string IInteractable.CannotInteractReason => string.Empty;
    InteractionType IInteractable.InteractionType => m_InteractionType;
    float IInteractable.HoldDuration => 0f;

    public void InteractInstant()
    {
        // Şimdilik kullanılmıyor
    }

    public void InteractHold(float holdProgress)
    {
        // Şimdilik kullanılmıyor
    }

    public void InteractToggle()
    {
        ToggleSwitch();
        m_OnSwitchToggled?.Invoke();
    }
    #endregion

} 