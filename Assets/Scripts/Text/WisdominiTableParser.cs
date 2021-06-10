using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WisdominiTableParser : TextTableParser
{
    public override TextTable ParseTable()
    {
        TextTable result = new TextTable();
        string contents = rawText.text;
        string[] lines = contents.Split('\n');
        int nColumns = 2;
        result.Initialize(nColumns);
        for (int i = 0; i < lines.Length; i+=3)
        {
            result.AddRow();
            result.AddColumn(lines[i + 1]);
            result.AddColumn(lines[i + 2]);
        }
        return result;
    }
}
