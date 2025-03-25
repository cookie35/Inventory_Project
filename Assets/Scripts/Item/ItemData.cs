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
}

public class ItemInfo  // ������ �����ʹ� ���� ����
{
    // �� ������ ������ ���̵� 
    public ItemData targetItem; 
    public int count; // ���� �� ���� ������ ������ �ִ��� ����
    public bool isEquipped = false;
}
