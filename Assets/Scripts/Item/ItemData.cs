using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}

public enum EquipableType
{
    Attack,
    Shield,
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
    public float value;
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;  // 여기서 입력한 값만큼 나중에 consumable items을 먹으면 health가 증가하게 하고 싶음
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

    [Header("Stacking")]
    public bool canStack = false;
    public int maxStack = 10;

    [Header("Equip")]
    public GameObject equipPrefab;
    public ItemDataEquipable[] equipables;

    [Header("Consum")]
    public ItemDataConsumable[] consumables;
}

public class ItemInfo  // 동적인 데이터는 따로 구현
{
    public ItemData targetItem; 
    public int itemUpgradeNum; // 해당 아이템 몇 번 강화했는지 여부
    public bool isEquipped;

    [Header("Upgrade")]
    public int upgradeLevel = 0;
    public float upgradeValue = 1.0f; // 강화 시 효과 증가율

    public void Upgrade()
    {
        upgradeLevel++;
        upgradeValue += 0.1f; // 10% 효과 증가
    }

}
