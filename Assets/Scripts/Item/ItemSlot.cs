using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Button itemBtn; // ������ ������ Ŭ���� �� ���
    [SerializeField] private Image itemIcon; // �������� �̹����� ǥ��
    [SerializeField] private GameObject equipMark; // ���� ǥ�ø� ���� ������Ʈ
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

    public void SetSlot(ItemInfo itemInfo)  // �������� ���Կ� �߰�
    {
        nowItem = itemInfo;
        RefreshUI();
    }

    public void RefreshUI()  // ������ ������ ui���¸� ���� �����Ϳ� �°� ����
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

    public void UseItem()  // �������� ��������� ��û��.
    {
        inventory.UseItem(this);
    }

}
