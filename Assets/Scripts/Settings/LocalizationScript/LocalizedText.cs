using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedText : MonoBehaviour
{
    private string key;

    private TMP_Text text;
    

    private void Awake()
    {
        if(text == null)
        {
            text = GetComponent<TMP_Text>();
        }
        key = this.name;

        if(key != null)
        {
            LocalizationManager.OnLanguageChanged += UpdateText;
            UpdateText();
        }  
    }

    private void UpdateText()
    {
        text.text = LocalizationManager.GetLocalizedValue(key);
    }

    private void OnDestroy() 
    {
        LocalizationManager.OnLanguageChanged -= UpdateText;
    }
}
