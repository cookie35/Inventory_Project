using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UiInventory : MonoBehaviour
{
    [SerializeField] private Transform contentParent; // scrollview의 content 연결
    [SerializeField] private GameObject itemSlotPrefab; // 슬롯 프리팹
    [SerializeField] private int initialSlotCount = 20;  // 초기 생성되는 슬롯의 개수
    [SerializeField] private TMP_Text slotCountTxt;  // 슬롯에 들어간 아이템의 숫자

    [SerializeField] private List<ItemSlot> newItemSlotList = new List<ItemSlot>(); // 생성될 슬롯 리스트
    public int filledSlotCount = 0; // 아이템이 들어간 슬롯

    [SerializeField] private Button btnBack;

    public Character character;
    public UiStatus status;
    public UiInventory inventory;

    void Start()
    {
        btnBack.onClick.AddListener(() => UiManager.Instance.ShowMainMenu());
        InitInventoryUi();  // Start에서 Init 호출
    }

    public void InitInventoryUi()
    {
        for (int i = 0; i < initialSlotCount; i++)
        {
            CreateNewSlot();
        }
        UpdateSlotCountTxt();
    }

    public void CreateNewSlot()  // 20개 빈 슬롯을 만드는 메서드
    {
        GameObject newSlot = Instantiate(itemSlotPrefab,Vector3.zero, Quaternion.identity);
        newSlot.transform.SetParent(contentParent);
        ItemSlot slotScript = newSlot.GetComponent<ItemSlot>(); 
        newItemSlotList.Add(slotScript); // slot을 list에 추가
        slotScript.character = character;
        slotScript.status = status;
        slotScript.inventory = inventory;
    }

    public void AddItemToSlot(ItemData itemData)  // 빈 슬롯에 아이템 추가
    {
        if (filledSlotCount >= initialSlotCount)
        {
            return;
        }

        ItemSlot emptySlot = newItemSlotList.Find(slot => slot.nowItem == null);  // slot.Item이 null인 슬롯을 찾아줌

        if (emptySlot != null)
        {
            emptySlot.SetItem(itemData);
            filledSlotCount++;  // 슬롯에 아이템이 들어갔으므로 슬롯 수 갱신
            UpdateSlotCountTxt();
        }

    }

    public void UpdateSlotCountTxt()  // 아이템의 숫자가 텍스트에 반영
    {
        slotCountTxt.text = $"{filledSlotCount}/{initialSlotCount}";
    }


}
