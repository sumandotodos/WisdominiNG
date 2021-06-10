using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextTableFromParser : TextTableItem
{
    public TextTableParser source;
    TextTable itemTable; // should not be public

    protected override void Start()
    {
        itemTable = source.ParseTable();
    }

    public override int GetNumberOfQuestions()
    {
        return itemTable.GetContents().Count;
    }

    public override string GetItem(int row, int col)
    {
        Debug.Log(source.name + " : TextTableFromParser=> row: " + row + ", col: " + col);
        return itemTable.GetContents()[row][col];
    }

}
