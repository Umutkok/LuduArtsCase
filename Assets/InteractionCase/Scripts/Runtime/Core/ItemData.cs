using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Interaction/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    [SerializeField] private string m_ItemId;
    [SerializeField] private string m_DisplayName;

    /// <summary> Item id </summary>
    public string ItemId => m_ItemId;

    /// <summary> UI ismi </summary>
    public string DisplayName => m_DisplayName;
}
