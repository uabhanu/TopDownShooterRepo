using DataPersistence.SerializableTypes;
using UnityEngine;

namespace DataPersistence.Data
{
    [System.Serializable]
    public class GameData
    {
        public SerializableDictionary<string , bool> ObjectsDestroyed;
        public int Score;
        public Quaternion PlayerRotation;
        public Vector2 PlayerPosition;

        //Constructor
        public GameData()
        {
            ObjectsDestroyed = new SerializableDictionary<string , bool>();
            PlayerPosition = new Vector2(0f , -4.47f);
            PlayerRotation = new Quaternion(0f , 0f , 0f , 0f);
            Score = 0;
        }
    }
}
