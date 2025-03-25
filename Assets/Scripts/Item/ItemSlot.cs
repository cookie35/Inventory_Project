using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Button itemBtn; // 아이템 슬롯을 클릭할 때 사용
    [SerializeField] private Image itemIcon; // 아이템의 이미지를 표시
    [SerializeField] private GameObject equipMark; // 장착 표시를 띄우는 오브젝트
    [SerializeField] private Outline outline;

    public ItemInfo nowItem;
    public UiInventory inventory;
    public Character character;
    public UiStatus status;

    public void Start()
    {        
        itemBtn.onClick.AddListener(UseItem);
        Init();
    }

    private void Init()
    { 
        itemIcon.enabled = false;
        equipMark.SetActive(false);
        outline.enabled = false;

    }

    public void SetItem(ItemData itemData)  // 아이템을 슬롯에 추가
    {
        nowItem = new ItemInfo();
        nowItem.targetItem = itemData;
        nowItem.isEquipped = false;
        RefreshUI();
    }

    public void RefreshUI()  // 아이템 슬롯의 ui상태를 현재 데이터에 맞게 갱신
    {
        if (nowItem == null)
        {
            itemIcon.gameObject.SetActive(false);
            equipMark.SetActive(false);
            outline.enabled = false;
            return;
        }

        itemIcon.gameObject.SetActive(true);
        itemIcon.enabled = true;
        itemIcon.sprite = nowItem.targetItem.icon;
        equipMark.SetActive(nowItem.isEquipped);
        outline.enabled = nowItem.isEquipped;  
    }

    public void UseItem()
    {
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

            nowItem = null; // 아이템 소비 후 삭제
            inventory.filledSlotCount--;
            inventory.UpdateSlotCountTxt();
        }

        RefreshUI();
    }

}
