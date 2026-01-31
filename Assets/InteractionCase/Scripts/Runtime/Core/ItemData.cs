using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Interaction/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    [SerializeField] private string m_ItemId;
    [SerializeField] private string m_DisplayName;

    /// <summary> Item unique id (e.g. "Key_Red") </summary>
    public string ItemId => m_ItemId;

    /// <summary> UI display name </summary>
    public string DisplayName => m_DisplayName;
}
