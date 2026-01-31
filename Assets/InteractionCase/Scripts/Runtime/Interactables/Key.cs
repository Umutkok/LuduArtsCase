using UnityEngine;
using InteractionSystem.Core;

public class Key : MonoBehaviour, IInteractable
{
    #region Fields

    [Header("Key Settings")]
    [SerializeField] private ItemData m_keyData;


    private readonly InteractionType m_InteractionType = InteractionType.Instant;

    #endregion

    #region Private Methods

    #endregion

    #region IInteractable Implementation
    bool IInteractable.CanInteract => true;
    string IInteractable.CannotInteractReason => string.Empty;
    InteractionType IInteractable.InteractionType => m_InteractionType;
    float IInteractable.HoldDuration => 0f;

    public void InteractInstant()
    {
        PlayerInventory inventory = FindAnyObjectByType<PlayerInventory>();
        if (inventory == null)
        {
            Debug.LogWarning("No PlayerInventory found.");
            return;
        }

        inventory.AddKey(m_keyData);
        Destroy(gameObject);
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
} 