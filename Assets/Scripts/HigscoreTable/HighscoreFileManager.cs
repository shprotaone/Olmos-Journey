using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighscoreFileManager : MonoBehaviour
{
    private const string _folderName = "Save File";
    private const string _fileName = "HighscoreData.json";

    private string _dataPath;

    public string DataPath { get { return _dataPath; } }

    private void Awake()
    {
        _dataPath = Path.Combine(Application.persistentDataPath, _folderName, _fileName);
        GamePreferencesManager.OnReset += ResetTable;
    }

    public void CreateNewHigscoreData(List<HighscoreEntry> highscoreEntryList)
    {
        if (!File.Exists(_dataPath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_dataPath));

            try
            {
                highscoreEntryList = new List<HighscoreEntry>();
                highscoreEntryList.Add(new HighscoreEntry(50, 50, "50/50/50", true));

                string json = JsonUtility.ToJson(highscoreEntryList);
                File.WriteAllText(_dataPath, json);

            }
            catch (System.Exception)
            {

                print("Exception");
            }
        }
    }

    private void ResetTable()
    {
        File.Delete(_dataPath);
        print("Reset Complete");
        GamePreferencesManager.OnReset -= ResetTable;
    }

    public void Save(string[] data)
    {
        File.WriteAllLines(_dataPath, data);
    }

    public string[] Load()
    {
        return File.ReadAllLines(_dataPath);
    }
}
