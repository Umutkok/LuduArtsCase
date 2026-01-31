using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores collected key items for the player.
/// Provides lookup and notifies listeners when a key is added.
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    private readonly List<ItemData> m_Keys = new();

    /// <summary>
    /// Fired when a new key is added to the inventory.
    /// </summary>
    public event Action<ItemData> KeyAdded;

    public void AddKey(ItemData key)
    {
        if (!m_Keys.Contains(key))
        {
            m_Keys.Add(key);
            Debug.Log($"Key added: {key.DisplayName}");

            KeyAdded?.Invoke(key); // UIa haber verir
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
