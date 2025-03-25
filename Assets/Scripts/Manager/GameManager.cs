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

    private void SetData()  // �ʱⰪ ����
    {
        // character = new Character("��Ż���� ���� ������", 1, 10000, 10, 5, 100, 5);
        character.id = "��Ż���� ���� ������";
        character.level = 1;
        character.gold = 10000;
        character.baseAttack = 10;
        character.baseShield = 5;
        character.baseHealth = 100;
        character.baseCriticalHit = 10;

        if (UiManager.Instance == null)
        {
            Debug.LogError("UiManager.Instance�� null�Դϴ�! UiManager�� ����� �ʱ�ȭ���� �ʾ��� ���ɼ��� Ů�ϴ�.");
            return;
        }

        uiMainMenu.SetCharacterInfo(character);
        uiStatus.SetStatusInfo(character);
    }

}
