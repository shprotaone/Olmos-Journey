using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    private const string _tableName = "HighscorePanel";   

    [SerializeField] private Transform _entryContainer;
    [SerializeField] private Transform _entryTemplate;

    private string _dataPath;

    private List<HighscoreEntry> _highscoreEntryList;
    private List<Transform> _highscoreEntryPosition;

    private void Awake()
    {
        _dataPath = Path.Combine(Application.persistentDataPath, "Save File", "HighscoreData.json");
        CreateHigscoreData();

        if (base.name == _tableName)
        {           
            _entryContainer = transform.Find("HighscoreContainer");
            _entryTemplate = _entryContainer.Find("HighscoreEntry");
            _entryTemplate.gameObject.SetActive(false);

            _highscoreEntryList = new List<HighscoreEntry>();

            Load();
            PrintTable();
        }
    }   

    /// <summary>
    /// Инициализация таблицы
    /// </summary>
    /// <param name="highscoreEntry"></param>
    /// <param name="container"></param>
    /// <param name="transformList"></param>
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry,Transform container,List<Transform> transformList)
    {        
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(_entryTemplate, container);
        Transform entryRectTransform = entryTransform.GetComponent<Transform>();
       
        entryRectTransform.localPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        float score = highscoreEntry.Score;
        float time = highscoreEntry.Distance;
        string dataScore = highscoreEntry.DataScore;

        TMP_Text[] fieldArray = FillLine(entryTransform);

        fieldArray[0].text = rank.ToString();
        fieldArray[1].text = score.ToString();
        fieldArray[2].text = time.ToString();
        fieldArray[3].text = dataScore;

        transformList.Add(entryTransform);
    }

    /// <summary>
    /// Добавляет новую запись
    /// </summary>
    /// <param name="score"></param>
    /// <param name="distance"></param>
    /// <param name="name"></param>
    public void AddHighscoreEntry(float score,float distance,string dataScore)
    {
        Load();
        HighscoreEntry highscoreEntry = new HighscoreEntry(score, distance, dataScore,true);
        _highscoreEntryList.Add(highscoreEntry);
        SortTable();

        Save();
    }
    /// <summary>
    /// Заполняет строку
    /// </summary>
    /// <param name="entryTransform"></param>
    /// <returns></returns>
    private TMP_Text[] FillLine(Transform entryTransform)
    {
        TMP_Text[] fieldArray =
        {
            entryTransform.Find("posText").GetComponent<TMP_Text>(),
            entryTransform.Find("posScore").GetComponent<TMP_Text>(),
            entryTransform.Find("posDistance").GetComponent<TMP_Text>(),
            entryTransform.Find("posData").GetComponent<TMP_Text>()
        };

        return fieldArray;
    }

    private void SortTable()
    {
        for (int i = 0; i < _highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < _highscoreEntryList.Count; j++)
            {
                if (_highscoreEntryList[j].Score > _highscoreEntryList[i].Score)
                {
                    HighscoreEntry tmp = _highscoreEntryList[i];
                    _highscoreEntryList[i] = _highscoreEntryList[j];
                    _highscoreEntryList[j] = tmp;
                }
            }
        }

        if (_highscoreEntryList.Count > 10)
        {
            int deleteList = _highscoreEntryList.Count - 10;
            _highscoreEntryList.RemoveRange(10, deleteList);
            Debug.Log("Check");
        }
    }

    private void Save()
    {
        string[] data = new string[_highscoreEntryList.Count];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = JsonUtility.ToJson(_highscoreEntryList[i]);
        }

        File.WriteAllLines(_dataPath, data);
    }

    private void Load()
    {
        string[] data = File.ReadAllLines(_dataPath);

        _highscoreEntryList = new List<HighscoreEntry>();
        HighscoreEntry highscoreEntry;

        for (int i = 0; i < data.Length; i++)
        {
            highscoreEntry = JsonUtility.FromJson<HighscoreEntry>(data[i]);
            _highscoreEntryList.Add(new HighscoreEntry(highscoreEntry.Score,highscoreEntry.Distance,highscoreEntry.DataScore,highscoreEntry.newEntry));
        }        
    }

    /// <summary>
    /// Вывод таблицы
    /// </summary>
    private void PrintTable()
    {
        _highscoreEntryPosition = new List<Transform>();

        foreach (HighscoreEntry higscoreEntry in _highscoreEntryList)
        {
            CreateHighscoreEntryTransform(higscoreEntry, _entryContainer, _highscoreEntryPosition);
        }

        Save();
    }

    private void CreateHigscoreData()
    {
        if (!Directory.Exists(Path.GetDirectoryName(_dataPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_dataPath));

            try
            {
                _highscoreEntryList = new List<HighscoreEntry>();
                _highscoreEntryList.Add(new HighscoreEntry(50, 50, "50/50/50", true));

                string json = JsonUtility.ToJson(_highscoreEntryList);
                File.WriteAllText(_dataPath, json);

            }
            catch (System.Exception)
            {

                print("Exception");
            }

        }
    }
}




