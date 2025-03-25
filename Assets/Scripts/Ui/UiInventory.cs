using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UiInventory : MonoBehaviour
{
    [SerializeField] private Transform contentParent; // scrollview�� content ����
    [SerializeField] private GameObject itemSlotPrefab; // ���� ������
    [SerializeField] private int initialSlotCount = 20;  // �ʱ� �����Ǵ� ������ ����
    [SerializeField] private TMP_Text slotCountTxt;  // ���Կ� �� �������� ����

    [SerializeField] private List<ItemSlot> newItemSlotList = new List<ItemSlot>(); // ������ ���� ����Ʈ
    [SerializeField] private int filledSlotCount = 0; // �������� �� ����

    [SerializeField] private Button btnBack;

    public Character character;

    void Start()
    {
        btnBack.onClick.AddListener(() => UiManager.Instance.ShowMainMenu());
        InitInventoryUi();  // Start���� Init ȣ��
    }

    private void InitInventoryUi()
    {
        for (int i = 0; i < initialSlotCount; i++)
        {
            CreateNewSlot();
        }
        UpdateSlotCountTxt();
    }

    private void CreateNewSlot()  // 20�� �� ������ ����� �޼���
    {
        GameObject newSlot = Instantiate(itemSlotPrefab,Vector3.zero, Quaternion.identity);
        newSlot.transform.SetParent(contentParent);
        ItemSlot slotScript = newSlot.GetComponent<ItemSlot>(); 
        newItemSlotList.Add(slotScript); // slot�� list�� �߰�
        slotScript.character = character;
    }

    public void AddItemToSlot(ItemData itemData)  // �� ���Կ� ������ �߰�
    {
        if (filledSlotCount >= initialSlotCount)
        {
            return;
        }

        ItemSlot emptySlot = newItemSlotList.Find(slot => slot.nowItem == null);  // slot.Item�� null�� ������ ã����

        if (emptySlot != null)
        {
            emptySlot.SetItem(itemData);
            filledSlotCount++;
            UpdateSlotCountTxt();
        }
    }

    private void UpdateSlotCountTxt()  // �������� ���ڰ� �ؽ�Ʈ�� �ݿ�
    {
        slotCountTxt.text = $"{filledSlotCount}/{initialSlotCount}";
    }


}
