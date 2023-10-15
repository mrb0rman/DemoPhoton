using System;
using System.Collections.Generic;
using DemoPhoton.Scripts.UI.UIWindow;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace DemoPhoton.Scripts.UI
{
    public class PlayerListingsMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform _content; 
        [SerializeField] private PlayerListing _playerListing;
        [SerializeField] private TMP_Text _readyUpText;
        [SerializeField] private UIRoomWindow _uiRoomWindow;
        
        private List<PlayerListing> _listPlayer = new List<PlayerListing>();
        private bool _ready = false;
        
        public override void OnEnable()
        {
            base.OnEnable();
            SetReadyUp(false);
            GetCurrentRoomPlayer();
        }

        public override void OnDisable()
        {
            base.OnDisable();

            for (int i = 0; i < _listPlayer.Count; i++)
            {
                Destroy(_listPlayer[i].gameObject);
            }
            _listPlayer.Clear();
        }
        
        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            _uiRoomWindow.OnClickLeaveRoom();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            AddPlayerListing(newPlayer);
            GetCurrentRoomPlayer();
        }

        public override void OnJoinedRoom()
        {
            GetCurrentRoomPlayer();
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            int index = _listPlayer.FindIndex(x => x.Player == otherPlayer);
            if (index != -1)
            {
                Destroy(_listPlayer[index].gameObject);
                _listPlayer.RemoveAt(index);
            }
        }
        
        public void OnClickStartGame()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (var player in _listPlayer)
                {
                    if (player.Player != PhotonNetwork.LocalPlayer)
                    {
                        if (!player.Ready)
                        {
                            return;
                        }
                    }
                }
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                PhotonNetwork.LoadLevel(1);
            }
        }

        public void OnClickReadyUp()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                SetReadyUp(!_ready);
                base.photonView.RPC(
                    "RPCChangeReadyState", 
                    RpcTarget.MasterClient,
                    PhotonNetwork.LocalPlayer, 
                    _ready);
                
                /*base.photonView.RpcSecure(
                    "RPCChangeReadyState",
                    RpcTarget.MasterClient,
                    false,
                    PhotonNetwork.LocalPlayer,
                    _ready);*/
            }
        }
        
        private void SetReadyUp(bool state)
        {
            _ready = state;
            if (!_ready)
            {
                _readyUpText.text = "Not ready up";
            }
            else
            {
                _readyUpText.text = "Ready up";
            }
        }
        
        private void GetCurrentRoomPlayer()
        {
            if (!PhotonNetwork.IsConnected)
            {
                return;
            }

            if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            {
                return;
            }

            foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
            {
                AddPlayerListing(playerInfo.Value);
            }
        }
        
        private void AddPlayerListing(Player newPlayer)
        {
            int index = _listPlayer.FindIndex(x => x.Player == newPlayer);
            if (index != -1)
            {
                _listPlayer[index].SetPlayerRoom(newPlayer);
            }
            else
            {
                var listing = Instantiate(_playerListing, _content);
                if (listing != null)
                {
                    listing.SetPlayerRoom(newPlayer);
                    _listPlayer.Add(listing);
                } 
            }
            
        }

        [PunRPC]
        private void RPCChangeReadyState(Player player, bool ready)
        {
            int index = _listPlayer.FindIndex(x => x.Player == player);
            if (index != -1)
            {
                _listPlayer[index].Ready = ready;
            }
        }
    }
}