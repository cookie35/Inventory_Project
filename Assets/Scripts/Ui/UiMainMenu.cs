using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiMainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text txtId;
    [SerializeField] private TMP_Text txtLvNum;
    [SerializeField] private TMP_Text txtCoinNum;
    [SerializeField] private Button statusBtn;
    [SerializeField] private Button inventoryBtn;

    private void Start()
    {
        statusBtn.onClick.AddListener(() => UiManager.Instance.ShowStatus());
        inventoryBtn.onClick.AddListener(() => UiManager.Instance.ShowInventory());
    }

    public void SetCharacterInfo(Character character)
    {

        txtId.text = $"{character.id}";
        txtLvNum.text = $"{character.level}";
        txtCoinNum.text = $"{character.gold}";
    }

}
