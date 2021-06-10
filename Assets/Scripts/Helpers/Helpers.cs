using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers : MonoBehaviour
{
    protected static bool TouchingScreen = false;
    protected static Helpers instance;

    void Start()
    {
        instance = this;
    }

    public static IEnumerator CancellableWait(float delay)
    {
        if (Helpers.instance == null)
        {
            Debug.Log("Warning: no instance of Helpers in scene. Touch information unavailable");
        }
    	float elapsed = 0.0f;
    	while ((elapsed < delay) && (!Helpers.TouchingScreen))
    	{
    		yield return new WaitForEndOfFrame();  
    		elapsed += Time.deltaTime;
    	}
    }

    void Update()
    {
        TouchingScreen = Input.GetMouseButton(0);
    }

    public static T FindItemInList<T>(List<T> list, System.Func<T, bool> test)
    {
        foreach (T t in list)
        {
            if (test(t))
            {
                return t;
            }
        }
        return default(T);
    }

    public static T FindItemInArray<T>(T[] list, System.Func<T, bool> test)
    {
        foreach (T t in list)
        {
            if (test(t))
            {
                return t;
            }
        }
        return default(T);
    }

}
