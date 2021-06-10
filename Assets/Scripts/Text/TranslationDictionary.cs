using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationDictionary : MonoBehaviour
{
    public TextAsset textAsset;
    public Translation translation = null;
    public string DefaultLocale = "en";
    string CurrentLocale = "en";
    // Start is called before the first frame update
    
    void Start()
    {
        DeserializeTextAsset();
    }

    public void SetLocale(string locale)
    {
        CurrentLocale = locale;
    }

    private void DeserializeTextAsset()
    {
        Debug.Log(textAsset.text);
        translation = JsonUtility.FromJson<Translation>(textAsset.text);
        if (translation == null)
        {
            Debug.Log("<color=red>FAIL</color>");
        }
    }

    public string GetText(string key, string locale)
    {
        if(translation == null)
        {
            Start();
        }
        Translation.Dictionary dict = Helpers.FindItemInList<Translation.Dictionary>(translation.dictionaries, (d) => d.locale == locale);
        return Helpers.FindItemInList<Translation.Dictionary.DictionaryEntry>(dict.entries, (e) => e.key == key).value;
    }

    public string GetText(string key)
    {
        return GetText(key, CurrentLocale);
    }
}
