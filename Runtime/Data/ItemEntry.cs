using CG.ItemDatabaseSystem;
using CG.ItemDatabaseSystem.Data;

namespace CG.InventorySystem.Data
{
    [System.Serializable]
    internal class ItemEntry
    {
        public string id;
        public int quantity;

        private Item item;

        public Item Item => item ??= ItemDatabase.GetItem(id);
    }
}