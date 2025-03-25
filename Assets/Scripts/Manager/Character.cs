using UnityEngine;

// ĳ���� ���� ����
// ĳ������ �̸�, ����, ��带 �����ϴ� Ŭ����
// GameManager���� ����

public class Character : MonoBehaviour
{
    public string id { get; private set; }
    public int level { get; private set; }
    public int gold { get; private set; }
    public int attack { get; private set; }
    public int shield { get; private set; }
    public int health { get; private set; }
    public int criticalHit { get; private set; }

    public Character(string id, int level, int gold, int attack, int shield, int health, int criticalHit)  // �ʱⰪ ������ ���� ������
    {
        this.id = id;
        this.level = level;
        this.gold = gold;
        this.attack = attack;
        this.shield = shield;
        this.health = health;
        this.criticalHit = criticalHit;
    }
}
