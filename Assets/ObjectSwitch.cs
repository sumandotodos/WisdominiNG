using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitch : MonoBehaviour
{
    public GameObject[] objects_A;

    public int currentChannel = 0;

    void Awake()
    {
        //objects_A = System.Array.ConvertAll(GetComponentsInChildren<MonoBehaviour>(), t => t.gameObject);
        List<GameObject> gameobjects = new List<GameObject>();
        foreach (Transform child in transform)
        {
            gameobjects.Add(child.gameObject);
        }
        objects_A = gameobjects.ToArray();
        
    }

    public void SetChannel(int channel)
    {
        this.currentChannel = channel;
    }

    public GameObject GetGameObject()
    {
        return GetGameObject(currentChannel);
    }

    public GameObject GetGameObject(int channel)
    {
        if (channel < objects_A.Length)
        {
            return objects_A[channel];
        }
        else
        {
            return null;
        }
    }

    public T GetGameObject<T>(int channel)
    {
        return GetGameObject(channel).GetComponent<T>();
    }

    public T GetGameObject<T>()
    {
        return GetGameObject(currentChannel).GetComponent<T>();
    }
}
