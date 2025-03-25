using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}

public enum EquipableType
{
    Attack,
    Shield
}

[System.Serializable]
public class ItemDataEquipable
{
    public EquipableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject   // 정적인 데이터
{
    [Header("Info")]
    public string displayName;
    public string description;
    public string equipDescription;
    public ItemType type;
    public Sprite icon;

    [Header("Equip")]
    public GameObject equipPrefab;
    public ItemDataEquipable[] equipables;
}

public class ItemInfo  // 동적인 데이터는 따로 구현
{
    // 이 아이템 고유의 아이디 
    public ItemData targetItem; 
    public int count; // 내가 몇 개의 아이템 가지고 있는지 개수
    public bool isEquipped = false;
}
