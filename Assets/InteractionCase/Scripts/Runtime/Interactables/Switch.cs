using UnityEngine;
using InteractionSystem.Core;

public class Switch : MonoBehaviour, IInteractable
{
    #region Fields

    [Header("Switch Settings")]
    [SerializeField] private Transform pivotPoint;

    private readonly InteractionType m_InteractionType = InteractionType.Toggle;



    #endregion

    #region IInteractable Implementation
    InteractionType IInteractable.InteractionType => m_InteractionType;

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
        // Şimdilik kullanılmıyor
    }
    #endregion

    #region Private Methods

    #endregion
} 