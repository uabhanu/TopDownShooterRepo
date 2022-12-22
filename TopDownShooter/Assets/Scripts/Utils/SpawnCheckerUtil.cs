using DataPersistence;
using DataPersistence.Data;
using UnityEngine;

namespace Utils
{
    public class SpawnCheckerUtil : MonoBehaviour , IDataPersistence
    {
        public bool IsInstantiated;
    
        [SerializeField] private string uniqueID;

        [ContextMenu("Generate GUID for ID")]
        private void GenerateGUID()
        {
            uniqueID = System.Guid.NewGuid().ToString();
        }

        public void LoadData(GameData gameData)
        {
            gameData.ObjectsInstantiated.TryGetValue(uniqueID , out IsInstantiated);

            if(IsInstantiated)
            {
                GetComponent<ObjectSpawnerUtil>().SpawnObject();
            }
        }

        public void SaveData(ref GameData gameData)
        {
            if(gameData.ObjectsInstantiated.ContainsKey(uniqueID))
            {
                gameData.ObjectsInstantiated.Remove(uniqueID);
            }
            
            gameData.ObjectsInstantiated.Add(uniqueID , IsInstantiated);
        }
    }
}
