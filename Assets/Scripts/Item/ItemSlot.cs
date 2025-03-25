using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Button itemBtn; // 아이템 슬롯을 클릭할 때 사용
    [SerializeField] private Image itemIcon; // 아이템의 이미지를 표시
    [SerializeField] private GameObject equipMark; // 장착 표시를 띄우는 오브젝트
    [SerializeField] private Outline outline;

    public ItemInfo nowItem;
    public Character character;

    public void Start()
    {        
        itemBtn.onClick.AddListener(EquipItem);
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
        nowItem.itemUpgradeNum = 0;  // 새 아이템의 경우 아직 강화횟수 없음
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

        itemIcon.enabled = true;
        itemIcon.sprite = nowItem.targetItem.icon;
        equipMark.SetActive(nowItem.isEquipped);
        outline.enabled = nowItem.isEquipped;  
    }

    public void EquipItem()
    {
        if (nowItem == null) return;

        if (nowItem.isEquipped)
        {
            character.UnEquip(); // 장착 해제 
        }
        else
        {
            character.Equip(nowItem); // 장착 요청
        }

        RefreshUI();
    }
}
