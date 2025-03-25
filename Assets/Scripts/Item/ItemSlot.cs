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

    public void SetItem(ItemInfo target)  // 아이템을 슬롯에 추가
    {
        nowItem = target;
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

        // 장착하는 과정 
        // isEquipped true

        RefreshUI();
    }
}
