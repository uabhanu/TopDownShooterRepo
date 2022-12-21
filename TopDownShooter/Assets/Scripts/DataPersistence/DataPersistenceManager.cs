using System.Collections.Generic;
using System.Linq;
using DataPersistence.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DataPersistence
{
    public class DataPersistenceManager : MonoBehaviour
    {
        #region Variables
        
        private FileDataHandler _fileDataHandler;
        
        private GameData _gameData;

        private List<IDataPersistence> _dataPersistenceInterfacesList;

        [Header("Encrypt or not?")] [SerializeField] private bool useEncryption;
        
        [Header("For Debugging")] [SerializeField] private bool initializeDataIfNull;

        [Header("File Storage Config")] [SerializeField] private string fileName;
        public static DataPersistenceManager Instance { get; private set; }

        public GameData GameData => _gameData;

        #endregion

        #region Functions

        private void Awake()
        {
            if(Instance != null)
            {
                Debug.LogError("Found more than one Data Persistence Manager in the scene so destroying the newest one");
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            _fileDataHandler = new FileDataHandler(Application.persistentDataPath , fileName , useEncryption);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        //This is called after OnEnable but before Start as per the Unity Docs
        private void OnSceneLoaded(Scene scene , LoadSceneMode mode)
        {
            _dataPersistenceInterfacesList = FindAllDataPersistenceInterfaces();
            LoadGame();
        }

        private void OnSceneUnloaded(Scene scene)
        {
            SaveGame();
        }

        //Just in case if user quits accidentally
        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceInterfaces()
        {
            IEnumerable<IDataPersistence> dataPersistenceInterfaces = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataPersistenceInterfaces);
        }

        public void LoadGame()
        {
            _gameData = _fileDataHandler.Load();

            if(_gameData == null && initializeDataIfNull)
            {
                NewGame();
            }
            
            if(_gameData == null)
            {
                Debug.LogWarning("No data was found. A new game needs to be started before data can be loaded");
                return;
            }

            foreach(IDataPersistence dataPersistenceInterface in _dataPersistenceInterfacesList)
            {
                dataPersistenceInterface.LoadData(_gameData);
            }
        }
        
        public void NewGame()
        {
            _gameData = new GameData();
        }

        public void SaveGame()
        {
            if(_gameData == null)
            {
                Debug.LogWarning("No data was found. A new game needs to be started before data can be saved");
                return;
            }
            
            foreach(IDataPersistence dataPersistenceInterface in _dataPersistenceInterfacesList)
            {
                dataPersistenceInterface.SaveData(ref _gameData);
            }

            _fileDataHandler.Save(_gameData);
        }

        #endregion
    }
}
