using Photon.Pun;
using UnityEngine;
using NetworkPlayer = BNG.NetworkPlayer;

public class MySceneManager : MonoBehaviourPunCallbacks
{
    private string RemotePlayerObjectName = "RemotePlayer";

    private void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(RemotePlayerObjectName, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
        NetworkPlayer np = player.GetComponent<NetworkPlayer>();
        if (np) {
            np.transform.name = "MyRemotePlayer";
            np.AssignPlayerObjects();
        }
    }
}
