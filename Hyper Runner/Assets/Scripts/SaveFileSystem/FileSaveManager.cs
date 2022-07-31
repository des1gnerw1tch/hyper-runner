using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveFileSystem
{
    /// <summary>
    /// Deals with loading and saving user data (PlayerSaveData).
    /// Serializes/Deserializes instances of PlayerSaveData into binary file.
    /// Write and read save file at suggested local path. 
    /// </summary>
    public static class FileSaveManager
    {
        public static void SavePlayer(PlayerSaveData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/hp2d.data";
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static PlayerSaveData LoadPlayer()
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

        public static void DeletePlayer()
        {
            string path = Application.persistentDataPath + "/player.fun";
            File.Delete(path);
        }
    }
}
