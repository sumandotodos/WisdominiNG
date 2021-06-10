using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextTableItem : MonoBehaviour
{
    protected abstract void Start();

    public abstract int GetNumberOfQuestions();

    public abstract string GetItem(int row, int col);
}
