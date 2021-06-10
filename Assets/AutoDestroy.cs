using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float Delay;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Delay);
        Destroy(this.gameObject);
    }
}
