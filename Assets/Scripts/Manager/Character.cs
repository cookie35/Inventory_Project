using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Character : MonoBehaviour
{
    public string id { get; set; }
    public int level { get; set; }
    public int gold { get; set; }

    // �⺻ ���� (����Ʈ ������ �ٲٸ� ��� ����, ������ enum���� ����� ������ �õ��غ� ����. �ð������ ����)
    public int baseAttack;
    public int baseShield;
    public int baseCriticalHit;
    public int baseHealth;

    public int bonusAttack;  // ��� ���� �� ������ ��ġ
    public int bonusShield;
    public int bonusCriticalHit;
    public int bonusHealth; // �Һ� ������ ���� �� ������ ��ġ

    // �κ��丮 �ý���
    public List<ItemInfo> itemList { get; set; } = new List<ItemInfo>();  // �������� ������ �� ����Ʈ�� �߰��ϰԲ�
    public ItemInfo EquippedItem;  // ���� ���� ������
    public UiStatus status;
    public UiInventory inventory;

    public void AddItem(ItemInfo nowItem)  // �� ���Կ� ������ �߰�, CHARACTER
    {
        if (itemList.Count >= inventory.initialSlotCount)
        {
        return;
        }

        nowItem.isEquipped = false;
        itemList.Add(nowItem);
        inventory.AddItem(nowItem);
    }

    public void RemoveItem(ItemSlot itemSlot)
    {
        if (itemSlot == null)
        {
            return;
        }

        itemList.Remove(itemSlot.nowItem);
        itemSlot.nowItem = null;
        itemSlot.RefreshUI();
        inventory.UpdateSlotCountTxt();
    }

    public void Equip(ItemInfo item)  // ������ ���� �޼���
    {
        EquippedItem = item;
        item.isEquipped = true;

        for (int i = 0; i < item.targetItem.equipables.Length; i++)
        {
            switch (item.targetItem.equipables[i].type)
            {
                case EquipableType.Attack:
                    bonusAttack += item.targetItem.equipables[i].value;
                    break;
                case EquipableType.Defense:
                    bonusShield += item.targetItem.equipables[i].value;
                    break;
                case EquipableType.CriticalHit:
                    bonusCriticalHit += item.targetItem.equipables[i].value;
                    break;
            }
        }
    }

    public void UnEquip(ItemInfo item)
    {
        EquippedItem = item;

        if (EquippedItem != null)
        {
            for (int i = 0; i < EquippedItem.targetItem.equipables.Length; i++)
            {
                switch (EquippedItem.targetItem.equipables[i].type)
                {
                    case EquipableType.Attack:
                        bonusAttack -= EquippedItem.targetItem.equipables[i].value;
                        break;
                    case EquipableType.Defense:
                        bonusShield -= EquippedItem.targetItem.equipables[i].value;
                        break;
                    case EquipableType.CriticalHit:
                        bonusCriticalHit -= EquippedItem.targetItem.equipables[i].value;
                        break;
                }
            }

            EquippedItem.isEquipped = false;
            EquippedItem = null;

        }
    }

    public void Heal(ItemInfo item)
    {
        for (int i = 0; i < item.targetItem.consumables.Length; i++)
        {
            bonusHealth += item.targetItem.consumables[i].value;
        }

    }
}
