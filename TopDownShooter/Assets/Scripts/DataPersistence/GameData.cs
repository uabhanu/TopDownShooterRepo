using UnityEngine;

namespace DataPersistence
{
    [System.Serializable]
    public class GameData
    {
        public int Score;
        public Quaternion PlayerRotation;
        public Vector2 PlayerPosition;

        //Constructor
        public GameData()
        {
            PlayerPosition = new Vector2(0f , -4.47f);
            PlayerRotation = new Quaternion(0f , 0f , 0f , 0f);
            Score = 0;
        }
    }
}
