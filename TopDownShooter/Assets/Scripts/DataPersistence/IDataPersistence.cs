namespace DataPersistence
{
    public interface IDataPersistence
    {
        void LoadData(GameData gameData); //Passing by value as here we care about just reading the data
        void SaveData(ref GameData gameData); //Passing by reference so the implementing script can modify the data
    }
}
