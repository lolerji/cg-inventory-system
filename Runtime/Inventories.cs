using System;
using System.Collections.Generic;
using CG.InventorySystem.Data;
using CG.InventorySystem.Stores;
using CG.ItemDatabaseSystem;
using CG.ItemDatabaseSystem.Data;
using UnityEngine;

namespace CG.InventorySystem
{
    public static class Inventories
    {
        public static string AccountInventory => "account";

        private static Dictionary<string, InventoryData> inventories = new Dictionary<string, InventoryData>();

        static Inventories()
        {
            // Initialize default inventory
            inventories.Add(AccountInventory, new InventoryData(AccountInventory));
        }

        public static void Load(IDataStore store)
        {
            // Load saved data from storage
            var moduleData = store.Load();

            if (moduleData.inventoryList is { Count: > 0 })
            {
                inventories = new Dictionary<string, InventoryData>();
                
                // Add each inventory entry to inventories dictionary from loaded module data
                foreach (var inventory in moduleData.inventoryList)
                {
                    inventories.Add(inventory.id, inventory);
                }
            }
        }

        public static bool InventoryExists(string id)
        {
            return inventories.ContainsKey(id);
        }

        public static void CreateInventory(string id)
        {
            inventories.Add(id, new InventoryData(id));
        }

        public static int GetOwnedItemCount(string inventoryId, string itemId)
        {
            return GetOwnedItemCount(inventoryId, ItemDatabase.GetItem(itemId));
        }

        public static int GetOwnedItemCount(string inventoryId, Item item)
        {
            if (!inventories.TryGetValue(inventoryId, out var inventory))
            {
                throw new KeyNotFoundException($"Inventory {inventoryId} does NOT exist!");
            }

            if (!inventory.entries.TryGetValue(item.Key, out var entry))
            {
                return 0;
            }

            return entry.quantity;
        }

        public static bool CanAdd(string inventoryId, string itemId, int quantity = 1)
        {
            return CanAdd(inventoryId, ItemDatabase.GetItem(itemId));
        }

        public static bool CanAdd(string inventoryId, Item item, int quantity = 1)
        {
            return GetOwnedItemCount(inventoryId, item) + quantity <= item.MaxQuantity;
        }

        public static bool CanRemove(string inventoryId, string itemId, int quantity = 1)
        {
            return CanRemove(inventoryId, ItemDatabase.GetItem(itemId));
        }

        public static bool CanRemove(string inventoryId, Item item, int quantity = 1)
        {
            return GetOwnedItemCount(inventoryId, item) - quantity > 0;
        }

        public static void Add(string inventoryId, string itemId, int quantity = 1)
        {
            Add(inventoryId, ItemDatabase.GetItem(itemId), quantity);
        }

        public static void Add(string inventoryId, Item item, int quantity = 1)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("quantity cannot be negative!");
            }
            
            if (!inventories.TryGetValue(inventoryId, out var inventory))
            {
                throw new KeyNotFoundException($"Inventory {inventoryId} does NOT exist!");
            }
            
            if (!inventory.entries.TryGetValue(item.Key, out var entry))
            {
                entry = new ItemEntry();
                entry.id = item.Key;
                inventory.entries.Add(entry.id, entry);
            }

            if (item.MaxQuantity > 0)
            {
                entry.quantity = Mathf.Clamp(entry.quantity + quantity, 0, item.MaxQuantity);
            }
            else
            {
                entry.quantity = Mathf.Clamp(entry.quantity + quantity, 0, int.MaxValue);
            }
        }

        public static void Remove(string inventoryId, string itemId, int quantity = 1)
        {
            Remove(inventoryId, ItemDatabase.GetItem(itemId), quantity);
        }

        public static void Remove(string inventoryId, Item item, int quantity = 1)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("quantity cannot be negative!");
            }
            
            if (!inventories.TryGetValue(inventoryId, out var inventory))
            {
                throw new KeyNotFoundException($"Inventory {inventoryId} does NOT exist!");
            }
            
            if (!inventory.entries.TryGetValue(item.Key, out var entry))
            {
                return;
            }
            
            entry.quantity = Mathf.Clamp(entry.quantity - quantity, 0, int.MaxValue);
        }

        public static void Save(IDataStore store)
        {
            var data = new ModuleData();
            data.inventoryList = new List<InventoryData>();

            foreach (var key in inventories.Keys)
            {
                data.inventoryList.Add(inventories[key]);
            }
            
            store.Save(data);
        }
    }
}