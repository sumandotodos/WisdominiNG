using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextTable
{ 
    List<List<string>> columns;

    int nCols;

    public int GetNumberOfRows()
    {
        return columns.Count;
    }

    public int GetNumberOfColumns()
    {
        return nCols;
    }

    public void Initialize(int nColumns)
    {
        nCols = nColumns;
        columns = new List<List<string>>();
    }

    public void AddRow()
    {
        columns.Add(new List<string>());
    }

    public void AddColumn(string content)
    {
        columns[columns.Count - 1].Add(content);
    }

    public List<List<string>> GetContents()
    {
        return columns;
    }

    public string GetItem(int row, int col)
    {
        return columns[row][col];
    }
}
