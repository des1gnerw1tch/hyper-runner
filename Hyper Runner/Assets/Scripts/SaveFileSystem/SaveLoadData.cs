using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Currency;

namespace SaveFileSystem
{
    /// <summary>
    /// Loads and saves PlayerSaveData to file. 
    /// </summary>
    public class SaveLoadData : MonoBehaviour
    {
        private PlayerSaveData currentSaveData;
        
        public static SaveLoadData Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            Instance = this;
            
            currentSaveData = LoadPlayer();
            
            if (currentSaveData == null)
            {
                Debug.Log("Save file not found. Creating new save.");
                currentSaveData = new PlayerSaveData();
                SavePlayer();
            }
        }

        public int GetNumTokens() => currentSaveData.GetNumTokens();

        public void SetNewTokenBalance(int numTokens)
        {
            currentSaveData.SetPlayTokens(numTokens);
            SavePlayer();
        }

        private void SavePlayer()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            string path = Application.persistentDataPath + "/hp2d.data";
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, currentSaveData);
            stream.Close();
        }

        private PlayerSaveData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/hp2d.data";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerSaveData data = formatter.Deserialize(stream) as PlayerSaveData;
                stream.Close();
                
                Debug.Log("Save file found at " + path);
                
                return data;
            }
            else
            {
                Debug.Log("Player Save file not found in " + path);
                return null;
            }
        }

        private void DeletePlayer()
        {
            string path = Application.persistentDataPath + "/player.fun";
            File.Delete(path);
        }
    }
}