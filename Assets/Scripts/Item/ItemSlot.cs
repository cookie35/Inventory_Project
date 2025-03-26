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

    public void SetSlot(ItemInfo itemInfo)  // 아이템을 슬롯에 추가
    {
        nowItem = itemInfo;
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

    public void UseItem()  // 아이템을 사용해줘라는 요청만.
    {
        inventory.UseItem(this);
    }

}
