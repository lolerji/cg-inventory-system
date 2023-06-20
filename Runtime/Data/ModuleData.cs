using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CG.InventorySystem.Data
{
    [System.Serializable]
    public struct ModuleData
    {
        [FormerlySerializedAs("inventoryData")] [SerializeField] internal List<InventoryData> inventoryList;
    }
}