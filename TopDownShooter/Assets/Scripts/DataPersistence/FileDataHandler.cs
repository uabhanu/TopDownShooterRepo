using System;
using System.IO;
using DataPersistence.Data;
using UnityEngine;

public class FileDataHandler
{
    #region Variables
    
    private bool _useEncryption = false;
    private readonly string _encryptionCodeWord = "Word"; 
    private string _dataDirPath = "";
    private string _dataFileName = "";

    public FileDataHandler(string dataDirPath , string dataFileName , bool useEncryption)
    {
        _dataDirPath = dataDirPath;
        _dataFileName = dataFileName;
        _useEncryption = useEncryption;
    }
    
    #endregion

    #region Functions
    
    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";

        for(int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ _encryptionCodeWord[i % _encryptionCodeWord.Length]);
        }

        return modifiedData;
    }
    
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

                if(_useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
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

            if(_useEncryption)
            {
                dataToSave = EncryptDecrypt(dataToSave);
            }

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
