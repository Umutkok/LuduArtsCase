using UnityEngine;
using InteractionSystem.Core;

public class Chest : MonoBehaviour, IInteractable
{
    #region Fields

    [Header("Chest Settings")]
    [SerializeField] private Transform m_LidPivot;
    [SerializeField] private float m_OpenAngle = 90f;
    [SerializeField] private ItemData m_ContainedKey;
    [SerializeField] private float m_HoldDuration = 2f;

    private readonly InteractionType m_InteractionType = InteractionType.Hold;

    private bool m_IsOpened;
    private bool m_RewardGiven;
    #endregion

    #region Private Methods
    private void OpenChest()
    {
        if (m_LidPivot == null)
        {
            Debug.LogWarning($"{name} Chest has no lid pivot assigned.");
            return;
        }

        m_LidPivot.localRotation = Quaternion.Euler(m_OpenAngle, 0f, 0f);
        m_IsOpened = true;

        GiveReward();

        Debug.Log("Chest opened.");
    }

    private void GiveReward()
    {
        if (m_RewardGiven)
            return;

        PlayerInventory inventory = FindAnyObjectByType<PlayerInventory>();
        if (inventory == null)
            return;

        inventory.AddKey(m_ContainedKey);
        m_RewardGiven = true;

        Debug.Log($"Item collected: {m_ContainedKey.name}");
    }

    #endregion

    #region IInteractable Implementation
    InteractionType IInteractable.InteractionType => m_InteractionType;
    float IInteractable.HoldDuration => m_HoldDuration;

    public void InteractInstant()
    {
        // Şimdilik kullanılmıyor
    }

    public void InteractHold(float holdProgress)
    {
        if (m_IsOpened)
            return;

        if (holdProgress >= 1f)
        {
            OpenChest();
        }
    }

    public void InteractToggle()
    {
        // Şimdilik kullanılmıyor
    }
    #endregion
    
} 
