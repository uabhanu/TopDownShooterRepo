using DataPersistence.SerializableTypes;
using UnityEngine;

namespace DataPersistence.Data
{
    [System.Serializable]
    public class GameData
    {
        public SerializableDictionary<string , bool> ObjectsDestroyed;
        public int FullObstacleHealth;
        public int MovingEnemyHealth;
        public int PlayerHealth;
        public int StationaryEnemyHealth;
        public int Score;
        public Quaternion PlayerRotation;
        public Vector2 PlayerPosition;

        //Constructor
        public GameData()
        {
            FullObstacleHealth = 75;
            MovingEnemyHealth = 80;
            ObjectsDestroyed = new SerializableDictionary<string , bool>();
            PlayerHealth = 50;
            PlayerPosition = new Vector2(0f , -4.47f);
            PlayerRotation = new Quaternion(0f , 0f , 0f , 0f);
            Score = 0;
            StationaryEnemyHealth = 100;
        }
    }
}
