using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConrtoller : MonoBehaviour
{
    public float force;
    [SerializeField] private Gun[] gun;
    [SerializeField] private Bullet bullet;

    public void Fire()
    {
        for (int i = 0; i < gun.Length; i++)
        {
            var bulletObject = Instantiate(bullet.gameObject, gun[i].SpawnPountBullet);
            bulletObject.GetComponent<Bullet>().Rigidbody.AddForce(bulletObject.transform.up * force);
        }
    }
}
