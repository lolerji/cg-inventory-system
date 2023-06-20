using System.Collections.Generic;
using UnityEngine;

namespace CG.InventorySystem.Data
{
    [System.Serializable]
    public class InventoryData
    {
        [SerializeField] internal string id;
        [SerializeField] internal SerializableDictionary<string, ItemEntry> entries;

        public InventoryData()
        {
            id = Inventories.AccountInventory;
            entries = new SerializableDictionary<string, ItemEntry>();
        }

        public InventoryData(string id)
        {
            this.id = id;
            entries = new SerializableDictionary<string, ItemEntry>();
        }
    }
}