using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string id { get; private set; }
    public int level { get; private set; }
    public int gold { get; private set; }

    // 기본 스탯
    private int baseAttack;
    private int baseShield;
    private int baseHealth;
    public int baseCriticalHit;

    private int bonusHealth = 0; // Consumable 아이템으로 증가한 체력

    // 장비 장착에 따라 스탯 보너스 부여
    public int attack => baseAttack + GetEquipBonus(EquipableType.Attack);
    public int shield => baseShield + GetEquipBonus(EquipableType.Shield);
    public int health => baseHealth + bonusHealth;
    public int criticalHealth => baseCriticalHit + GetEquipBonus(EquipableType.CriticalHit);

    // 인벤토리 시스템
    public List<ItemInfo> Inventory { get; private set; }  // 아이템을 얻으면 이 리스트에 추가하게끔
    public ItemInfo EquippedItem { get; private set; }  // 현재 장착 아이템
    
    public Character(string id, int level, int gold, int attack, int shield, int health, int criticalHit)  // 초기값 설정을 위한 생성자
    {
        this.id = id;
        this.level = level;
        this.gold = gold;
        this.baseAttack = attack;
        this.baseShield = shield;
        this.baseHealth = health;
        this.baseCriticalHit = criticalHit;
        this.Inventory = new List<ItemInfo>();  // 인벤토리 초기화
    }

    public void Equip(ItemInfo item)  // 아이템 장착 메서드
    {
        EquippedItem = item;
        item.isEquipped = true;
    }

    public void UnEquip()
    {
        EquippedItem.isEquipped = false;
        EquippedItem = null;
    }

    public void Use(Character character)
    {
        if (targetItem.type == ItemType.Consumable)
        {
            character.Heal(consumable.value);
        }
    }

    public void Heal(float amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
    }

    publ

}
