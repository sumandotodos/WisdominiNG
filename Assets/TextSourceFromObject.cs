using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSourceFromObject : TextTableItem
{
    [SerializeField] ObjectSwitch objectSwitch;

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    public override int GetNumberOfQuestions()
    {
        return objectSwitch.GetGameObject<TextTableItem>().GetNumberOfQuestions();
    }

    public override string GetItem(int row, int col)
    {
        Debug.Log("TextSourceFromObject=> row: " + row + ", col: " + col);
        return objectSwitch.GetGameObject<TextTableItem>().GetItem(row, col);
    }


}
