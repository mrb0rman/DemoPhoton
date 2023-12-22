using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LithController : MonoBehaviour
{
    [SerializeField] private Light[] lights;
    [SerializeField] private PhotonView photonView;
    [SerializeField] private AudioSource audioSource;
    [PunRPC]
    public void EnabledLight(bool state)
    {
        photonView.RPC("OnOffLight", RpcTarget.All, state);
        if(!audioSource.isPlaying)
        {
            photonView.RPC("PlaySound", RpcTarget.All);
        }
    }

    [PunRPC]
    private void OnOffLight(bool state)
    {
        foreach(var light in lights)
        {
            light.gameObject.SetActive(state);
        }
    }

    [PunRPC]
    private void PlaySound()
    {
        audioSource.Play();
    }
}
