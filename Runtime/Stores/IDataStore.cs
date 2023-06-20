using System.Collections.Generic;
using CG.InventorySystem.Data;

namespace CG.InventorySystem.Stores
{
    public interface IDataStore
    {
        ModuleData Load();
        void Save(ModuleData data);
    }
}