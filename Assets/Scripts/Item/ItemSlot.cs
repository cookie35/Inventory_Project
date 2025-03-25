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

    public void SetItem(ItemData itemData)  // �������� ���Կ� �߰�
    {
        nowItem = new ItemInfo();
        nowItem.targetItem = itemData;
        nowItem.isEquipped = false;
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

    public void UseItem()
    {
        if (nowItem == null) return;

        if (nowItem.IsEquipable())
        {
            if (nowItem.isEquipped)
            {
                character.UnEquip(); // ���� ����
                nowItem = null;
            }
            else
            {
                character.Equip(nowItem); // ���� ��û
                status.UpdateStatus(nowItem, character);
            }
        }

        if (nowItem.IsConsumable())
        {
            character.Heal(nowItem);
            status.UpdateStatus(nowItem, character);  // �Һ� ������ ��� �� ���� ������Ʈ

            nowItem = null; // ������ �Һ� �� ����
            inventory.filledSlotCount--;
            inventory.UpdateSlotCountTxt();
        }

        RefreshUI();
    }

}
