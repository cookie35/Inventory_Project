using UnityEngine;

// UiManager�� Character�� ����

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UiMainMenu uiMainMenu;
    public UiStatus uiStatus;
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
        character = new Character("��Ż���� ���� ������", 1, 10000, 10, 5, 100, 5);

        if (UiManager.Instance == null)
        {
            Debug.LogError("UiManager.Instance�� null�Դϴ�! UiManager�� ����� �ʱ�ȭ���� �ʾ��� ���ɼ��� Ů�ϴ�.");
            return;
        }

        uiMainMenu.SetCharacterInfo(character);
        uiStatus.SetStatusInfo(character);
    }

}
