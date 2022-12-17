using Events;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DataPersistence
{
    public class GameDataManager : MonoBehaviour
    {
        #region Variables
        
        public static GameData GameData { get; private set; }
        
        public static GameDataManager Instance;
        public static string PersistentPath { get; private set; } = "";
        

        #endregion

        #region Functions
        
        private void Start()
        {
            CreateGameData();
            SetPaths();

            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);   
            }
            
            else if(Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void CreateGameData()
        {
            GameData = new GameData(0);
        }

        private void SetPaths()
        {
            PersistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        }

        public static void Load()
        {
            if(File.Exists(PersistentPath))
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    FileStream fileStream = File.Open(PersistentPath , FileMode.Open);
                    GameData = binaryFormatter.Deserialize(fileStream) as GameData;
                    fileStream.Close();
                }
                catch(Exception e)
                {
                    Debug.Log("Failed to load file : " + e);
                }
            }
            
            GameEventsManager.Invoke(GameEvent.Load);
        }

        public static void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Create(PersistentPath);
            binaryFormatter.Serialize(fileStream , GameData);
            fileStream.Close();
        }
        
        #endregion
    }
}
