using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GunConrtoller : MonoBehaviour
{
    public float force;
    [SerializeField] private Gun[] gun;

    public void Fire()
    {
        for (int i = 0; i < gun.Length; i++)
        {
            var bulletObject = PhotonNetwork.Instantiate("Bullet", gun[i].SpawnPountBullet.position, Quaternion.identity, 0);
            bulletObject.GetComponent<Bullet>().Rigidbody.AddForce(bulletObject.transform.up * force);
        }
    }
}
