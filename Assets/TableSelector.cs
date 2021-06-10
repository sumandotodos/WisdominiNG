using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSelector : TextTableItem
{
    [SerializeField] List<TextTableItem> subtables_A;
    public int CurrentChannel = 0;
    // Start is called before the first frame update
    void Awake()
    {
        subtables_A = new List<TextTableItem>();
        TextTableItem[] children = GetComponentsInChildren<TextTableItem>();
        foreach(TextTableItem child in children)
        {
            if(child != this)
            {
                subtables_A.Add(child);
            }
        }
    }

    protected override void Start()
    {
        
    }

    public override string GetItem(int row, int col)
    {
        Debug.Log("GetItem=> row: " + row + ", col: " + col);
        return subtables_A[CurrentChannel].GetItem(row, col);
    }

    public override int GetNumberOfQuestions()
    {
        return subtables_A[CurrentChannel].GetNumberOfQuestions();
    }

    public void SetChannel(int channel)
    {
        CurrentChannel = channel;
    }
}
