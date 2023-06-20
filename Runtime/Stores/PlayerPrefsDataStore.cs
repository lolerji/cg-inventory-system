using CG.InventorySystem.Data;
using UnityEngine;

namespace CG.InventorySystem.Stores
{
    public sealed class PlayerPrefsDataStore : IDataStore
    {
        private readonly string key;
        
        public PlayerPrefsDataStore(string key)
        {
            this.key = key;
        }
        
        public ModuleData Load()
        {
            var json = PlayerPrefs.GetString(key, "{}");
            var data = JsonUtility.FromJson<ModuleData>(json);
            return data;
        }

        public void Save(ModuleData data)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
        }
    }
}