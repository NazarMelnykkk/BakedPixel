using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemView : MonoBehaviour, IDraggable
{
    [field: SerializeField] public ItemData ItemData { get; set; }
    [SerializeField] public IItemContainer Container;
    [SerializeField] private List<Image> RayCastBlockers;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _count; //add count
    [SerializeField] private Transform _originalParent; //add count

    public void Initialize(ItemData itemData)
    {
        ItemData = itemData;
        ItemData.Stackable.OnValueChangeEvent += UpdateView;
        UpdateView();
    }

    public void UpdateView()
    {
        _icon.sprite = ItemData.Icon;
        _count.SetText(ItemData.Stackable.Amount.ToString());
        _count.gameObject.SetActive(ItemData.Stackable.IsStackable);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _originalParent = transform.parent;
        transform.SetParent(ProjectReferencesContainer.Instance.GlobalSceneTransformHolder.transform);

        foreach (var image in RayCastBlockers)
        {
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
        {
            IItemContainer targetContainer = eventData.pointerEnter.GetComponent<IItemContainer>();
            if (targetContainer != null)
            {

                if (targetContainer.CanAddItem())
                {
                    Container.RemoveItem();
                    targetContainer.AddItem(ItemData);

                    Destroy(gameObject);
                    return;
                }
            }
        }

        transform.SetParent(_originalParent, false);
        transform.localPosition = Vector3.zero;

        foreach (var image in RayCastBlockers)
        {
            image.raycastTarget = true;
        }

    }

    public void OnDestroy()
    {
        ItemData.Stackable.OnValueChangeEvent -= UpdateView;
    }
}
