using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string id { get; private set; }
    public int level { get; private set; }
    public int gold { get; private set; }

    // �⺻ ����
    private int baseAttack;
    private int baseShield;
    private int baseHealth;
    public int baseCriticalHit;

    private int bonusHealth = 0; // Consumable ���������� ������ ü��

    // ��� ������ ���� ���� ���ʽ� �ο�
    public int attack => baseAttack + GetEquipBonus(EquipableType.Attack);
    public int shield => baseShield + GetEquipBonus(EquipableType.Shield);
    public int health => baseHealth + bonusHealth;
    public int criticalHealth => baseCriticalHit + GetEquipBonus(EquipableType.CriticalHit);

    // �κ��丮 �ý���
    public List<ItemInfo> Inventory { get; private set; }  // �������� ������ �� ����Ʈ�� �߰��ϰԲ�
    public ItemInfo EquippedItem { get; private set; }  // ���� ���� ������
    
    public Character(string id, int level, int gold, int attack, int shield, int health, int criticalHit)  // �ʱⰪ ������ ���� ������
    {
        this.id = id;
        this.level = level;
        this.gold = gold;
        this.baseAttack = attack;
        this.baseShield = shield;
        this.baseHealth = health;
        this.baseCriticalHit = criticalHit;
        this.Inventory = new List<ItemInfo>();  // �κ��丮 �ʱ�ȭ
    }

    public void Equip(ItemInfo item)  // ������ ���� �޼���
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
