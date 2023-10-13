using Photon.Pun;
using UnityEngine;

namespace DemoPhoton.Scripts.UI.UIWindow
{
    public class UIRoomWindow : MonoBehaviour
    {
        [SerializeField] private UIService _uiService;
        
        public void OnClickLeaveRoom()
        {
            PhotonNetwork.LeaveRoom(true);
            _uiService.ListWindow[1].SetActive(false);
            _uiService.ListWindow[0].SetActive(true);
        }
    }
}