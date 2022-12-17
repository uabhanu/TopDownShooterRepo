using Events;
using System.IO;
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
            using StreamReader streamReader = new StreamReader(PersistentPath);
            string json = streamReader.ReadToEnd();
            GameData = JsonUtility.FromJson<GameData>(json);
            GameEventsManager.Invoke(GameEvent.Load);
        }

        public static void Save()
        {
            string savePath = PersistentPath;
            string json = JsonUtility.ToJson(GameData);
            using StreamWriter streamWriter = new StreamWriter(savePath);
            streamWriter.Write(json);
            GameEventsManager.Invoke(GameEvent.Save);
        }
        
        #endregion
    }
}
