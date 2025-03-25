using UnityEngine;

// 캐릭터 정보 저장
// 캐릭터의 이름, 레벨, 골드를 저장하는 클래스
// GameManager에서 관리

public class Character : MonoBehaviour
{
    public string id { get; private set; }
    public int level { get; private set; }
    public int gold { get; private set; }
    public int attack { get; private set; }
    public int shield { get; private set; }
    public int health { get; private set; }
    public int criticalHit { get; private set; }

    public Character(string id, int level, int gold, int attack, int shield, int health, int criticalHit)  // 초기값 설정을 위한 생성자
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
