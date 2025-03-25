using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UiMainMenu uiMainMenu;
    public UiStatus uiStatus;
    public UiInventory uiInventory;
    public Character character;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetData();
    }

    private void SetData()  // 초기값 설정
    {
        // character = new Character("멘탈터진 신입 개발자", 1, 10000, 10, 5, 100, 5);
        character.id = "멘탈터진 신입 개발자";
        character.level = 1;
        character.gold = 10000;
        character.baseAttack = 10;
        character.baseShield = 5;
        character.baseHealth = 100;
        character.baseCriticalHit = 10;

        if (UiManager.Instance == null)
        {
            Debug.LogError("UiManager.Instance가 null입니다! UiManager가 제대로 초기화되지 않았을 가능성이 큽니다.");
            return;
        }

        uiMainMenu.SetCharacterInfo(character);
        uiStatus.SetStatusInfo(character);
    }

}
