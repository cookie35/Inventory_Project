using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UiInventory : MonoBehaviour
{
    [SerializeField] private Transform contentParent; // scrollview�� content ����
    [SerializeField] private GameObject itemSlotPrefab; // ���� ������
    public int initialSlotCount = 20;  // �ʱ� �����Ǵ� ������ ����
    [SerializeField] private TMP_Text slotCountTxt;  // ���Կ� �� �������� ����

    [SerializeField] private List<ItemSlot> newItemSlotList = new List<ItemSlot>(); // ������ ���� ����Ʈ

    [SerializeField] private Button btnBack;

    public Character character;
    public UiStatus status;
    public UiInventory inventory;

    void Start()
    {
        btnBack.onClick.AddListener(() => UiManager.Instance.ShowMainMenu());
        InitInventoryUi();  // Start���� Init ȣ��
    }

    public void InitInventoryUi()
    {
        for (int i = 0; i < initialSlotCount; i++)
        {
            CreateNewSlot();
        }
        UpdateSlotCountTxt();
    }

    public void CreateNewSlot()  // 20�� �� ������ ����� �޼���
    {
        GameObject newSlot = Instantiate(itemSlotPrefab,Vector3.zero, Quaternion.identity);
        newSlot.transform.SetParent(contentParent);
        ItemSlot slotScript = newSlot.GetComponent<ItemSlot>(); 
        newItemSlotList.Add(slotScript); // slot�� list�� �߰�
        slotScript.inventory = inventory;
    }

    public void AddItem(ItemInfo itemInfo)  // �� ���Կ� ������ �߰�, CHARACTER
    {
        ItemSlot emptySlot = newItemSlotList.Find(slot => slot.nowItem == null);  // slot.Item�� null�� ������ ã����

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
                character.UnEquip(nowItem); // ���� ����
                nowItem.isEquipped = false;
                status.UpdateStatus(nowItem, character);
            }
            else
            {
                character.Equip(nowItem); // ���� ��û
                nowItem.isEquipped = true;
                status.UpdateStatus(nowItem, character);
            }
        }

        if (nowItem.IsConsumable())
        {
            character.Heal(nowItem);
            status.UpdateStatus(nowItem, character);  // �Һ� ������ ��� �� ���� ������Ʈ
            character.RemoveItem(itemSlot);
        }

        itemSlot.RefreshUI();
    }

    public void UpdateSlotCountTxt()  // �������� ���ڰ� �ؽ�Ʈ�� �ݿ�
    {
        if (slotCountTxt == null)
        {
            Debug.LogError("UpdateSlotCountTxt: slotCountTxt�� null�Դϴ�.");
            return;
        }

        if (character == null)
        {
            Debug.LogError("UpdateSlotCountTxt: character�� null�Դϴ�.");
            return;
        }

        if (character.itemList == null)
        {
            Debug.LogError("UpdateSlotCountTxt: character.itemList�� null�Դϴ�.");
            return;
        }

        slotCountTxt.text = $"{character.itemList.Count}/{initialSlotCount}";
    }

}
