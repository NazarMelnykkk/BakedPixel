using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotView : MonoBehaviour, IItemContainer , IPointerClickHandler
{
    [field: SerializeField] public SlotData SlotData { get; private set; }
    [field: SerializeField] public Image Icon { get; private set; }
    [field: SerializeField] public Image LockedIcon { get; private set; }
    [field: SerializeField] public TextMeshProUGUI LockedPrice { get; private set; }

    [SerializeField] private List<Image> RayCastBlockers;

    private ItemView _item;

    public void Initialize(SlotData slotData)
    {
        SlotData = slotData;
        if (SlotData.ItemData?.Type != ItemType.None && SlotData.ItemData != null)
        {
            AddItem(SlotData.ItemData);         
        }
        UpdateView();

    }

    public void UpdateView()
    {
        LockedIcon.gameObject.SetActive(SlotData.Protected.IsLocked);
        LockedPrice.gameObject.SetActive(SlotData.Protected.IsLocked);
        LockedPrice.SetText($"{SlotData.Protected.CostToUnlock}$");

    }

    public bool IsEmpty()
    {
        return SlotData.ItemData == null || SlotData.ItemData.Type == ItemType.None;
    }

    public void AddItem(ItemData itemData)
    {
        SlotData.ItemData = itemData;
        var item = Instantiate(ProjectReferencesContainer.Instance.GlobalDataBase.ItemViewPrefab, transform);
        item.Initialize(itemData);
        item.Container = this;
        _item = item;

    }

    public bool CanAddItem() => IsEmpty() && !SlotData.Protected.IsLocked;

    public bool CanRemoveItem(ItemData itemData) => SlotData.ItemData != null && SlotData.ItemData == itemData;

    public bool ContainsItem(ItemData itemData) => SlotData.ItemData == itemData;

    public void RemoveItem()
    {
        SlotData.ItemData = null;
        if (_item != null)
        {
            Destroy(_item.gameObject);
            _item = null;
        }

        UpdateView();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SlotData.Protected.IsLocked == true /*&& SlotData.Protected.CostToUnlock >= UrWallet*/)//todo
        {
            SlotData.Protected = new Protected(false, 0);
            UpdateView();
        }
    }
}
