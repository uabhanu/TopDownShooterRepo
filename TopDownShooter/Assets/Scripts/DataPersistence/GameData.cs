namespace DataPersistence
{
    [System.Serializable]
    public class GameData
    {
        public int Score;

        //Constructor
        public GameData(int score)
        {
            Score = score;
        }
    }
}
