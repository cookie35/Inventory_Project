using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UiInventory : MonoBehaviour
{
    [SerializeField] private Transform contentParent; // scrollview의 content 연결
    [SerializeField] private GameObject itemSlotPrefab; // 슬롯 프리팹
    public int initialSlotCount = 20;  // 초기 생성되는 슬롯의 개수
    [SerializeField] private TMP_Text slotCountTxt;  // 슬롯에 들어간 아이템의 숫자

    [SerializeField] private List<ItemSlot> newItemSlotList = new List<ItemSlot>(); // 생성될 슬롯 리스트

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
        slotScript.inventory = inventory;
    }

    public void AddItem(ItemInfo itemInfo)  // 빈 슬롯에 아이템 추가, CHARACTER
    {
        ItemSlot emptySlot = newItemSlotList.Find(slot => slot.nowItem == null);  // slot.Item이 null인 슬롯을 찾아줌

        if (emptySlot != null)
        {
            emptySlot.SetSlot(itemInfo);
            UpdateSlotCountTxt();
        }

    }

    public void UseItem(ItemSlot itemSlot)
    {
        ItemInfo nowItem = itemSlot.nowItem;

        if (nowItem == null) return;

        if (nowItem.IsEquipable())
        {
            if (nowItem.isEquipped)
            {
                character.UnEquip(nowItem); // 장착 해제
                nowItem.isEquipped = false;
                status.UpdateStatus(nowItem, character);
            }
            else
            {
                character.Equip(nowItem); // 장착 요청
                nowItem.isEquipped = true;
                status.UpdateStatus(nowItem, character);
            }
        }

        if (nowItem.IsConsumable())
        {
            character.Heal(nowItem);
            status.UpdateStatus(nowItem, character);  // 소비 아이템 사용 후 상태 업데이트
            character.RemoveItem(itemSlot);
        }

        itemSlot.RefreshUI();
    }

    public void UpdateSlotCountTxt()  // 아이템의 숫자가 텍스트에 반영
    {
        if (slotCountTxt == null)
        {
            Debug.LogError("UpdateSlotCountTxt: slotCountTxt가 null입니다.");
            return;
        }

        if (character == null)
        {
            Debug.LogError("UpdateSlotCountTxt: character가 null입니다.");
            return;
        }

        if (character.itemList == null)
        {
            Debug.LogError("UpdateSlotCountTxt: character.itemList가 null입니다.");
            return;
        }

        slotCountTxt.text = $"{character.itemList.Count}/{initialSlotCount}";
    }

}
