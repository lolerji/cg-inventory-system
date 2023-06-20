using CG.ItemDatabaseSystem.Data;

namespace CG.InventorySystem.Utilities
{
    public interface IInventory
    {
        public int GetOwnedItemCount(string itemId);

        public int GetOwnedItemCount(Item item);

        public bool CanAdd(string itemId, int quantity = 1);

        public bool CanAdd(Item item, int quantity = 1);

        public bool CanRemove(string itemId, int quantity = 1);

        public bool CanRemove(Item item, int quantity = 1);

        public void Add(string itemId, int quantity = 1);

        public void Add(Item item, int quantity = 1);

        public void Remove(string itemId, int quantity = 1);

        public void Remove(Item item, int quantity = 1);
    }
}