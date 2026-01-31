using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Toplanan keyler için basit bir envanter
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    private readonly List<ItemData> m_Keys = new();

    /// <summary>
    /// Event sistemi
    /// </summary>
    public event Action<ItemData> KeyAdded;

    public void AddKey(ItemData key)
    {
        if (!m_Keys.Contains(key))
        {
            m_Keys.Add(key);
            Debug.Log($"Key added: {key.DisplayName}");

            KeyAdded?.Invoke(key); // UI a haber verir
        }
    }

    public bool HasKey(ItemData key)
    {
        return m_Keys.Contains(key);
    }

    public IReadOnlyList<ItemData> GetKeys()
    {
        return m_Keys;
    }
}
