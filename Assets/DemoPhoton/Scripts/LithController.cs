using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LithController : MonoBehaviour
{
    [SerializeField] private Light[] lights;

    public void OnLight(bool state)
    {
        foreach(var light in lights)
        {
            light.gameObject.SetActive(state);
        }
    }
}
