using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FadeableElement))]
public class Fader : MonoBehaviour
{
	FadeableElement element;

	Coroutine fadeCoroutine = null;

	float currentOp;

	public bool StartOpaque = true;
	public float FadeSpeed = 1.0f;

    bool started = false;

	public void Start()
	{
        if(started)
        {
            return;
        }

        started = true;

		element = GetComponent<FadeableElement>();
		element.Start();
		if(StartOpaque)
		{
			currentOp = 1.0f;
		}
		else
		{
			currentOp = 0.0f;
		}
		element.SetOpacity(currentOp);
	}

	private void StopCoroutineIfValid()
	{
		if(fadeCoroutine != null)
    	{
    		StopCoroutine(fadeCoroutine);
    	}
	}

    public Coroutine FadeToOpaque()
    {
    	StopCoroutineIfValid();
    	fadeCoroutine = StartCoroutine(FadeCoroutine(1.0f));
    	return fadeCoroutine;
    }

    public Coroutine FadeToTransparent()
    {
		StopCoroutineIfValid();
    	fadeCoroutine = StartCoroutine(FadeCoroutine(0.0f));
    	return fadeCoroutine;
    }

    IEnumerator FadeCoroutine(float targetOp)
    {
    	bool done = false;
    	while(!done)
    	{
    		if(currentOp < targetOp)
    		{
    			currentOp += FadeSpeed * Time.deltaTime;
    			if(currentOp > targetOp)
    			{
    				currentOp = targetOp;
    				done = true;
    			}
    		}

    		if(currentOp > targetOp)
    		{
				currentOp -= FadeSpeed * Time.deltaTime;
    			if(currentOp < targetOp)
    			{
    				currentOp = targetOp;
    				done = true;
    			}
    		}

    		element.SetOpacity(currentOp);

    		yield return new WaitForEndOfFrame();

    	}
    }

}
