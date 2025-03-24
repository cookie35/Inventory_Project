using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Resource,
    Equipable,
    Consumable
}

public enum EquipableType
{
    Attack,
    Shield,
    CriticalHit
}

[System.Serializable]
public class ItemDataEquipable
{
    public EquipableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemType type;
    public Sprite icon;

    [Header("Equipable")]
    public ItemDataEquipable[] equipables;
}
