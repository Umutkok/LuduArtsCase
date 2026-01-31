using UnityEngine;
using InteractionSystem.Core;

public class Key : MonoBehaviour, IInteractable
{
    #region Fields

    [Header("Key Settings")]


    private readonly InteractionType m_InteractionType = InteractionType.Instant;



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