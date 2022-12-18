using System.Collections.Generic;
using System.Linq;
using DataPersistence.Data;
using UnityEngine;

namespace DataPersistence
{
    public class DataPersistenceManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private bool useEncryption;
        
        [Header("File Storage Config")] 
        [SerializeField] private string fileName;

        private FileDataHandler _fileDataHandler;
        private GameData _gameData;

        private List<IDataPersistence> _dataPersistenceInterfacesList;
        public static DataPersistenceManager Instance { get; private set; }

        public string FileName => fileName;

        #endregion

        #region Functions

        private void Awake()
        {
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

        private void Start()
        {
            _dataPersistenceInterfacesList = FindAllDataPersistenceInterfaces();
            _fileDataHandler = new FileDataHandler(Application.persistentDataPath , fileName , useEncryption);
            LoadGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceInterfaces()
        {
            IEnumerable<IDataPersistence> dataPersistenceInterfaces = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataPersistenceInterfaces);
        }

        public void LoadGame()
        {
            _gameData = _fileDataHandler.Load();
            
            if(_gameData == null)
            {
                NewGame();
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
            foreach(IDataPersistence dataPersistenceInterface in _dataPersistenceInterfacesList)
            {
                dataPersistenceInterface.SaveData(ref _gameData);
            }

            _fileDataHandler.Save(_gameData);
        }
        
        #endregion
    }
}
