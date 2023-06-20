using CG.ItemDatabaseSystem.Data;

namespace CG.InventorySystem.Utilities
{
    public sealed class Inventory : IInventory
    {
        private readonly string id;
        
        public Inventory()
        {
            id = Inventories.AccountInventory;
        }
        
        public Inventory(string id)
        {
            this.id = id;

            if (!Inventories.InventoryExists(id))
            {
                Inventories.CreateInventory(id);
            }
        }

        public int GetOwnedItemCount(string itemId)
        {
            return Inventories.GetOwnedItemCount(id, itemId);
        }

        public int GetOwnedItemCount(Item item)
        {
            return Inventories.GetOwnedItemCount(id, item);
        }

        public bool CanAdd(string itemId, int quantity = 1)
        {
            return Inventories.CanAdd(id, itemId, quantity);
        }

        public bool CanAdd(Item item, int quantity = 1)
        {
            return Inventories.CanAdd(id, item, quantity);
        }

        public bool CanRemove(string itemId, int quantity = 1)
        {
            return Inventories.CanRemove(id, itemId, quantity);
        }

        public bool CanRemove(Item item, int quantity = 1)
        {
            return Inventories.CanRemove(id, item, quantity);
        }

        public void Add(string itemId, int quantity = 1)
        {
            Inventories.Add(id, itemId, quantity);
        }

        public void Add(Item item, int quantity = 1)
        {
            Inventories.Add(id, item, quantity);
        }

        public void Remove(string itemId, int quantity = 1)
        {
            Inventories.Remove(id, itemId, quantity);
        }

        public void Remove(Item item, int quantity = 1)
        {
            Inventories.Remove(id, item, quantity);
        }
    }
}