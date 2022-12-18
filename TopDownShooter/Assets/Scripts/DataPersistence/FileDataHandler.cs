using DataPersistence;
using System;
using System.IO;
using UnityEngine;

public class FileDataHandler
{
    #region Variables
    
    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "Word"; 
    private string _dataDirPath = "";
    private string _dataFileName = "";

    public FileDataHandler(string dataDirPath , string dataFileName)
    {
        _dataDirPath = dataDirPath;
        _dataFileName = dataFileName;
    }
    
    #endregion

    #region Functions
    
    public GameData Load()
    {
        string fullpath = Path.Combine(_dataDirPath , _dataFileName);
        GameData gameData = null;

        if(File.Exists(fullpath))
        {
            try
            {
                string dataToLoad = "";

                using(FileStream fileStream = new FileStream(fullpath , FileMode.Open))
                {
                    using(StreamReader streamReader = new StreamReader(fileStream))
                    {
                        dataToLoad = streamReader.ReadToEnd();
                    }
                }

                gameData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        return gameData;
    }

    public void Save(GameData gameData)
    {
        string fullPath = Path.Combine(_dataDirPath , _dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToSave = JsonUtility.ToJson(gameData , true);

            using(FileStream fileStream = new FileStream(fullPath , FileMode.Create))
            {
                using(StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(dataToSave);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file : " + fullPath + "\n" + e);
        }
    }
    
    #endregion
}
