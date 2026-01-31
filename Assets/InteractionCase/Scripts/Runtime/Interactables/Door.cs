using UnityEngine;
using InteractionSystem.Core;

public class Door : MonoBehaviour, IInteractable
{
    #region Fields

    [Header("Door Settings")]
    [SerializeField] private Transform m_PivotPoint;
    [SerializeField] private float m_OpenAngle = 90f;
    [SerializeField] private bool m_IsLocked = true;
    [SerializeField] private ItemData m_RequiredKey;

    private readonly InteractionType m_InteractionType = InteractionType.Toggle;

    private bool m_IsOpen = false;

    #endregion

    #region Methods
    private void TryUnlock()
    {
        PlayerInventory inventory = FindAnyObjectByType<PlayerInventory>();
        if (inventory == null)
            return;

        if (inventory.HasKey(m_RequiredKey))
        {
            m_IsLocked = false;
            Debug.Log("Door unlocked.");
            ToggleDoor();
        }
        else
        {
            Debug.Log("Anahtar gerekli.");
        }
    }
    public void ToggleDoor()
    {
        if (m_IsLocked)
        {
            Debug.Log("Door is locked");
            return;
        }

        if (m_PivotPoint == null)
        {
            Debug.LogWarning($"{name} Door has no pivot point assigned.");
            return;
        }

        float targetAngle = m_IsOpen ? 0f : m_OpenAngle;

        m_PivotPoint.localRotation = Quaternion.Euler(0f, targetAngle, 0f);

        m_IsOpen = !m_IsOpen;
        Debug.Log(m_IsOpen);
    }
    #endregion

    #region IInteractable Implementation
    // Interface'te tanımlıysa explicit implementasyon
    bool IInteractable.CanInteract
    {
        get
        {
            // Eğer kilitli değilse etkileşime açık
            if (!m_IsLocked) return true;

            // Kilitliyse oyuncunun anahtarı var mı kontrol et
            var inventory = FindAnyObjectByType<PlayerInventory>();
            if (inventory == null) return false;

            return inventory.HasKey(m_RequiredKey);
        }
    }

    string IInteractable.CannotInteractReason
    {
        get
        {
            // Etkileşime izin veriliyorsa boş string döndür
            if (((IInteractable)this).CanInteract) return string.Empty;

            // Kilitli ve anahtar yoksa spesifik mesaj
            if (m_IsLocked) return "Door is locked";

            // Genel fallback mesajı (gerektiğinde özelleştir)
            return "Cannot interact";
        }
    }
    InteractionType IInteractable.InteractionType => m_InteractionType;
    float IInteractable.HoldDuration => 0f;

    public void InteractInstant()
    {
    }

    public void InteractHold(float holdProgress)
    {
        // Şimdilik kullanılmıyor
    }

    public void InteractToggle()
    {
        if (m_IsLocked)
        {
            TryUnlock();
            return;
        }

        ToggleDoor();
    }
    #endregion

} 
