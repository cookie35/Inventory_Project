using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiInventory : MonoBehaviour
{
    [SerializeField] private TMP_Text currentCount;
    [SerializeField] private Button btnBack;

    void Start()
    {
        btnBack.onClick.AddListener(() => UiManager.Instance.ShowMainMenu());   
    }
}
