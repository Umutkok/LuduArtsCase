using UnityEngine;
using InteractionSystem.Core;

public class Chest : MonoBehaviour, IInteractable
{
    #region Fields

    [Header("Chest Settings")]
    [SerializeField] private Transform pivotPoint;

    private readonly InteractionType m_InteractionType = InteractionType.Hold;



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
