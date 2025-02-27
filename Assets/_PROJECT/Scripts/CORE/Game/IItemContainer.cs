public interface IItemContainer
{
    bool IsEmpty();
    bool CanAddItem();  
    void AddItem(ItemData ItemData);    
    bool CanRemoveItem(ItemData ItemData); 
    void RemoveItem();  
    bool ContainsItem(ItemData ItemData);
}