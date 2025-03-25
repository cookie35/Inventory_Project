using UnityEngine;

// Ui 전환해주는 역할

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    [SerializeField] private GameObject uiMainMenu;
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private GameObject uiInventory;
    [SerializeField] private GameObject itemName;
    [SerializeField] private GameObject uiMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowMainMenu()
    {
        uiMainMenu.SetActive(true);
        uiStatus.SetActive(false);
        uiInventory.SetActive(false);

    }

    public void ShowStatus()
    {
        uiMainMenu.SetActive(true);
        uiStatus.SetActive(true);
        uiInventory.SetActive(false);
    }

    public void ShowInventory()
    {
        uiMainMenu.SetActive(true);
        uiStatus.SetActive(false);
        uiInventory.SetActive(true);
    }

}
