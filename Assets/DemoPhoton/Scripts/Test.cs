using Photon.Pun;
using UnityEngine;

namespace DemoPhoton.Scripts
{
    public class Test : MonoBehaviour
    {
        private void Update()
        {
            if (PhotonNetwork.IsMasterClient && Input.GetKeyDown(KeyCode.Space))
            {
                PhotonNetwork.Instantiate("Cube",
                    new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5)), Quaternion.identity);
            }
        }
    }
}