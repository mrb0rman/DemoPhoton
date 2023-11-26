using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PingController : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            text.text = PhotonNetwork.GetPing().ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
