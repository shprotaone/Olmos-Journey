using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LocalizationManager : MonoBehaviour
{
    private const int EnglishID = 0;
    private const int RussianID = 1;
    public delegate void ChangeLanguageText();
    public static event ChangeLanguageText OnLanguageChanged;

    private static Dictionary<string, List<string>> _localizedText;

    [SerializeField] private TextAsset localizathionList;

    private static int _currentLanguage;

    public static int CurrentLanguage { get { return _currentLanguage; } }

    private void Start()
    {
        _currentLanguage = PlayerPrefs.GetInt("Language");
        if (_localizedText == null)
            LoadLocalizationText();

        FirstOpen();
        print(_currentLanguage);
    }

    private void LoadLocalizationText()
    {
        _localizedText = new Dictionary<string, List<string>>();

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(localizathionList.text);

        foreach (XmlNode key in xmlDocument["Keys"].ChildNodes)
        {
            string keyStr = key.Attributes["Name"].Value;

            var values = new List<string>();

            foreach (XmlNode translate in key["Translates"].ChildNodes)
            {
                values.Add(translate.InnerText);
            }

            _localizedText[keyStr] = values;

        }

        OnLanguageChanged?.Invoke();
    }

    public static string GetLocalizedValue(string key, int languageId = -1)
    {
        if (languageId == -1)
            languageId = _currentLanguage;

        if (_localizedText.ContainsKey(key))
            return _localizedText[key][languageId];

        return key;
    }

    public void SwitchLanguage()
    {
        if (_currentLanguage == RussianID)
        {
            _currentLanguage = EnglishID;       
        }
        else
        {
            _currentLanguage = RussianID;
        }

        OnLanguageChanged?.Invoke();
        PlayerPrefs.SetInt("Language", _currentLanguage);
    }

    private void FirstOpen()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian ||
               Application.systemLanguage == SystemLanguage.Ukrainian ||
               Application.systemLanguage == SystemLanguage.Belarusian)
            {
                PlayerPrefs.SetInt("Language", RussianID);
            }
            else
            {
                PlayerPrefs.SetInt("Language", EnglishID);
                _currentLanguage = 0;
            }
        }
    }
}


