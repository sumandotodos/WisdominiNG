using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Translation
{
    [System.Serializable]
    public class Dictionary
    {
        [System.Serializable]
        public class DictionaryEntry
        {
            public string key;
            public string value;
        }

        public string locale;
        public List<DictionaryEntry> entries = new List<DictionaryEntry>();
    }

    public List<Dictionary> dictionaries = new List<Dictionary>();
}
