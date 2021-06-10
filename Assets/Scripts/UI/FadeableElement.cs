using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeableElement : MonoBehaviour
{
	Image[] imageComponents;
	RawImage[] rawImageComponents;
	Text[] textComponents;

    bool started = false;

    // Start is called before the first frame update
    public void Start()
    {
        if(started)
        {
            return;
        }

        started = true;

        imageComponents = GetComponentsInChildren<Image>();
        rawImageComponents = GetComponentsInChildren<RawImage>();
        textComponents = GetComponentsInChildren<Text>();
    }

    public void SetOpacity(float op)
    {
    	foreach(Image img in imageComponents)
    	{
    		Color prevColor = img.color;
    		img.color = new Color(prevColor.r, prevColor.g, prevColor.b, op);
            img.enabled = (op > 0.0f);
    	}

    	foreach(RawImage rimg in rawImageComponents)
    	{
			Color prevColor = rimg.color;
    		rimg.color = new Color(prevColor.r, prevColor.g, prevColor.b, op);
            rimg.enabled = (op > 0.0f);
    	}

    	foreach(Text txt in textComponents)
    	{
			Color prevColor = txt.color;
    		txt.color = new Color(prevColor.r, prevColor.g, prevColor.b, op);
            txt.enabled = (op > 0.0f);
    	}
    }
}
