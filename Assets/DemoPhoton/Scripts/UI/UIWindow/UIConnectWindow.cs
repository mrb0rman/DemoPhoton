using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace DemoPhoton.Scripts.UI.UIWindow
{
    public class UIConnectWindow : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputNickname;
        [SerializeField] private TMP_InputField _inputRoomName;
        [SerializeField] private UIService _uiService;
        
        public void OnClickButton()
        {
            if (!PhotonNetwork.IsConnected)
            {
                return;
            }

            if (!PhotonNetwork.InLobby)
            {
                return;
            }
            InputFieldNickname();
            InputFieldRoomName();
            
            _uiService.ListWindow[0].SetActive(false);
            _uiService.ListWindow[1].SetActive(true);
        }

        private void InputFieldNickname()
        {
            var nickname = _inputNickname.text;
            if (nickname == "")
            {
                return;
            }
            PhotonNetwork.LocalPlayer.NickName = nickname;
        }

        private void InputFieldRoomName()
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 4;
            
            var roomName = _inputRoomName.text;
            if (_inputRoomName.text == "")
            {
                roomName = "room " + (int)Random.Range(0, 999);
            }

            
            PhotonNetwork.CreateRoom(roomName, options, TypedLobby.Default);
        }
    }
}