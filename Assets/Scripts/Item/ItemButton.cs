using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Button itemSword;
    [SerializeField] private Button itemShield;
    [SerializeField] private Button itemApple;

    [SerializeField] private ItemData sword; // ScriptableObject ������
    [SerializeField] private ItemData shield;
    [SerializeField] private ItemData apple;

    [SerializeField] private ItemSlot itemSlot; // �������� ������ ����
    [SerializeField] private UiInventory uiInventory;

    public void Start()
    {
        itemSword.onClick.AddListener(() => OnClickItem(sword));
        itemShield.onClick.AddListener(() => OnClickItem(shield));
        itemApple.onClick.AddListener(() => OnClickItem(apple));
    }

    public void OnClickItem(ItemData itemData) // Ŭ���� �ϸ� ItemSlot�� �����Ǿ��ٰ� ��ȣ�� ��
    {
        if (itemData == null) return;

        uiInventory.AddItemToSlot(itemData);
    }

}
