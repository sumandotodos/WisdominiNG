using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizableText : MonoBehaviour
{
    public TranslationDictionary dictionary_A;
    Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        if(dictionary_A == null)
        {
            dictionary_A = FindObjectOfType<TranslationDictionary>();
        }
        textComponent = GetComponent<Text>();
        textComponent.text = dictionary_A.GetText(textComponent.text);
    }
}
