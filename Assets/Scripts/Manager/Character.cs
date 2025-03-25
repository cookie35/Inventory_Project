using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string id { get; set; }
    public int level { get; set; }
    public int gold { get; set; }

    // 기본 스탯
    public int baseAttack;
    public int baseShield;
    public int baseCriticalHit;
    public int baseHealth;

    public int bonusAttack;  // 장비 장착 후 증가된 수치
    public int bonusShield;
    public int bonusCriticalHit;
    public int bonusHealth; // 소비 아이템 섭취 후 증가된 수치

    // 인벤토리 시스템
    public List<ItemInfo> Inventory { get; set; }  // 아이템을 얻으면 이 리스트에 추가하게끔
    public ItemInfo EquippedItem;  // 현재 장착 아이템
    public UiStatus status;
    public UiInventory inventory;

    public void Equip(ItemInfo item)  // 아이템 장착 메서드
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
