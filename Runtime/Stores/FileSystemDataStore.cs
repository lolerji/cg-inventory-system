using System;
using System.IO;
using CG.InventorySystem.Data;
using UnityEngine;

namespace CG.InventorySystem.Stores
{
    public class FileSystemDataStore : IDataStore
    {
        private readonly string fileName;

        public FileSystemDataStore(string fileName)
        {
            this.fileName = fileName;
        }

        public ModuleData Load()
        {
            StreamReader reader = null;

            try
            {
                CreateDirectoryIfNonExistent();

                reader = new StreamReader(fileName);
                var json = reader.ReadToEnd();
                var data = JsonUtility.FromJson<ModuleData>(json);
                return data;
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                reader?.Close();
                reader?.Dispose();
            }

            return default;
        }

        public void Save(ModuleData data)
        {
            StreamWriter writer = null;

            try
            {
                var json = JsonUtility.ToJson(data);
                
                CreateDirectoryIfNonExistent();
                
                writer = new StreamWriter(fileName);
                writer.WriteLine(json);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                writer?.Close();
                writer?.Dispose();
            }
        }

        private void CreateDirectoryIfNonExistent()
        {
            var directory = Path.GetDirectoryName(fileName);

            if (!Directory.Exists(directory))
                if (directory != null)
                    Directory.CreateDirectory(directory);
        }
    }
}