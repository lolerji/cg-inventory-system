using System;
using CG.ItemDatabaseSystem.Data;
using UnityEngine;

namespace CG.InventorySystem.Utilities
{
    [CreateAssetMenu(menuName = "CG/Inventory")]
    public class ScriptableInventory : ScriptableObject, IInventory
    {
        [SerializeField] private string id;

        private Inventory inventory;

        public int GetOwnedItemCount(string itemId)
        {
            inventory ??= new Inventory(id);
            return inventory.GetOwnedItemCount(itemId);
        }

        public int GetOwnedItemCount(Item item)
        {
            inventory ??= new Inventory(id);
            return inventory.GetOwnedItemCount(item);
        }

        public bool CanAdd(string itemId, int quantity = 1)
        {
            inventory ??= new Inventory(id);
            return inventory.CanAdd(itemId, quantity);
        }

        public bool CanAdd(Item item, int quantity = 1)
        {
            inventory ??= new Inventory(id);
            return inventory.CanAdd(item, quantity);
        }

        public bool CanRemove(string itemId, int quantity = 1)
        {
            inventory ??= new Inventory(id);
            return inventory.CanRemove(itemId, quantity);
        }

        public bool CanRemove(Item item, int quantity = 1)
        {
            inventory ??= new Inventory(id);
            return inventory.CanRemove(item, quantity);
        }

        public void Add(string itemId, int quantity = 1)
        {
            inventory ??= new Inventory(id);
            inventory.Add(itemId, quantity);
        }

        public void Add(Item item, int quantity = 1)
        {
            inventory ??= new Inventory(id);
            inventory.Add(item, quantity);
        }

        public void Remove(string itemId, int quantity = 1)
        {
            inventory ??= new Inventory(id);
            inventory.Remove(itemId, quantity);
        }

        public void Remove(Item item, int quantity = 1)
        {
            inventory ??= new Inventory(id);
            inventory.Remove(item, quantity);
        }
    }
}