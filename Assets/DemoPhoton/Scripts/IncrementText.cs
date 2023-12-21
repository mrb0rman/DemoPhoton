using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class IncrementText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private PhotonView photonView;

    private int _number = 0;
    
    [PunRPC]
    public void Increment()
    {
        photonView.RPC("SetText", RpcTarget.All);
    }
    
    [PunRPC]
    private void SetText()
    {
        _number++;
        text.text = _number.ToString();
    }
}
