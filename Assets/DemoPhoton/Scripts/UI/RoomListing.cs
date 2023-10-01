using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace DemoPhoton.Scripts.UI
{
    public class RoomListing : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public RoomInfo RoomInfo { get; private set; }
        
        public void SetInfoRoom(RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;
            _text.text = roomInfo.Name + ", " + roomInfo.MaxPlayers;
        }

        public void OnClickButton()
        {
            PhotonNetwork.JoinRoom(RoomInfo.Name);
            var uiService = FindObjectOfType<UIService>();
            uiService.ListWindow[0].SetActive(false);
            uiService.ListWindow[1].SetActive(true);
        }
    }
}