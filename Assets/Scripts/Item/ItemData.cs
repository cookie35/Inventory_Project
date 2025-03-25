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
    public float value;  // ���⼭ �Է��� ����ŭ ���߿� consumable items�� ������ health�� �����ϰ� �ϰ� ����
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

    [Header("Stacking")]
    public bool canStack = false;
    public int maxStack = 10;

    [Header("Equip")]
    public GameObject equipPrefab;
    public ItemDataEquipable[] equipables;

    [Header("Consum")]
    public ItemDataConsumable[] consumables;
}

public class ItemInfo  // ������ �����ʹ� ���� ����
{
    public ItemData targetItem; 
    public int itemUpgradeNum; // �ش� ������ �� �� ��ȭ�ߴ��� ����
    public bool isEquipped;

    [Header("Upgrade")]
    public int upgradeLevel = 0;
    public float upgradeValue = 1.0f; // ��ȭ �� ȿ�� ������

    public void Upgrade()
    {
        upgradeLevel++;
        upgradeValue += 0.1f; // 10% ȿ�� ����
    }

}
