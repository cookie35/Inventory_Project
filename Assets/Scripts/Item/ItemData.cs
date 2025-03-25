using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}

public enum EquipableType
{
    Attack,
    Defense,
    CriticalHit
}

public enum ConsumableType
{
    health
}

[System.Serializable]
public class ItemDataEquipable
{
    public EquipableType type;
    public int value;
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public int value;  // 여기서 입력한 값만큼 나중에 consumable items을 먹으면 health가 증가하게 하고 싶음
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

    [Header("Consum")]
    public ItemDataConsumable[] consumables;
}


public class ItemInfo  // 동적인 데이터는 따로 구현
{
    public ItemData targetItem; 
    public bool isEquipped;

    public bool IsEquipable()
    {
        return targetItem.type == ItemType.Equipable;
    }

    public bool IsConsumable()
    {
        return targetItem.type == ItemType.Consumable;
    }
}
