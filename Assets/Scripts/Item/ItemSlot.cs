using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Button itemBtn; // ������ ������ Ŭ���� �� ���
    [SerializeField] private Image itemIcon; // �������� �̹����� ǥ��
    [SerializeField] private GameObject equipMark; // ���� ǥ�ø� ���� ������Ʈ
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

    public void SetItem(ItemData itemData)  // �������� ���Կ� �߰�
    {
        nowItem = new ItemInfo();
        nowItem.targetItem = itemData;
        nowItem.itemUpgradeNum = 0;  // �� �������� ��� ���� ��ȭȽ�� ����
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
            character.UnEquip(); // ���� ���� 
        }
        else
        {
            character.Equip(nowItem); // ���� ��û
        }

        RefreshUI();
    }
}
