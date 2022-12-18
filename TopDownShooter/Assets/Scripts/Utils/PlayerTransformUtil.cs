using DataPersistence;
using UnityEngine;

namespace Utils
{
    public class PlayerTransformUtil : MonoBehaviour , IDataPersistence
    {
        public void LoadData(GameData gameData)
        {
            transform.position = gameData.PlayerPosition;
            transform.rotation = gameData.PlayerRotation;
        }

        public void SaveData(ref GameData gameData)
        {
            gameData.PlayerPosition = transform.position;
            gameData.PlayerRotation = transform.rotation;
        }
    }
}
