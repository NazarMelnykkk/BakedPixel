using UnityEngine.EventSystems;

public interface IDraggable : IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public new void OnBeginDrag(PointerEventData eventData)
    {
    }

    public new void OnDrag(PointerEventData eventData)
    {
    }

    public new void OnEndDrag(PointerEventData eventData)
    {
    }
}
