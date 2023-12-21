using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    private int _timer;
    
    private void Start()
    {
        _timer = 0;
        StartCoroutine(Tick());
    }
    
    private IEnumerator Tick()
    {
        while (_timer < 10)
        {
            _timer++;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}
