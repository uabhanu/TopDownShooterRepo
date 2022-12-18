using DataPersistence;
using DataPersistence.Data;
using UnityEngine;

namespace Utils
{
    public class DestroyedCheckerUtil : MonoBehaviour , IDataPersistence
    {
        public bool IsDead = false;
        
        [SerializeField] private string uniqueID;

        [ContextMenu("Generate GUID for ID")]
        private void GenerateGUID()
        {
            uniqueID = System.Guid.NewGuid().ToString();
        }

        public void LoadData(GameData gameData)
        {
            gameData.ObjectsDestroyed.TryGetValue(uniqueID , out IsDead);

            if(IsDead)
            {
                gameObject.SetActive(false);
            }
        }

        public void SaveData(ref GameData gameData)
        {
            if(gameData.ObjectsDestroyed.ContainsKey(uniqueID))
            {
                gameData.ObjectsDestroyed.Remove(uniqueID);
            }
            
            gameData.ObjectsDestroyed.Add(uniqueID , IsDead);
        }
    }
}
