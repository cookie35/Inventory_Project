using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Button itemSword;
    [SerializeField] private Button itemShield;
    [SerializeField] private Button itemApple;

    [SerializeField] private ItemData sword; // ScriptableObject 아이템
    [SerializeField] private ItemData shield;
    [SerializeField] private ItemData apple;

    [SerializeField] private ItemSlot itemSlot; // 아이템을 장착할 슬롯
    [SerializeField] private UiInventory uiInventory;

    public void Start()
    {
        itemSword.onClick.AddListener(() => OnClickItem(sword));
        itemShield.onClick.AddListener(() => OnClickItem(shield));
        itemApple.onClick.AddListener(() => OnClickItem(apple));
    }

    public void OnClickItem(ItemData itemData) // 클릭을 하면 ItemSlot에 장착되었다고 신호가 들어감
    {
        if (itemData == null) return;

        uiInventory.AddItemToSlot(itemData);
    }

}
