using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextTableParser : MonoBehaviour
{
    public TextAsset rawText;

    public abstract TextTable ParseTable();

}
