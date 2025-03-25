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
    public int value;  // ���⼭ �Է��� ����ŭ ���߿� consumable items�� ������ health�� �����ϰ� �ϰ� ����
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject   // ������ ������
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


public class ItemInfo  // ������ �����ʹ� ���� ����
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
