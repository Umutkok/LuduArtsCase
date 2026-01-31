using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private readonly List<ItemData> m_Keys = new();

    public void AddKey(ItemData key)
    {
        if (!m_Keys.Contains(key))
        {
            m_Keys.Add(key);
            Debug.Log($"Key added: {key.DisplayName}");
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
