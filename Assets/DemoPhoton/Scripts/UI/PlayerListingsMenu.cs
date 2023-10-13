using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Serialization;

namespace DemoPhoton.Scripts.UI
{
    public class PlayerListingsMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform _content; 
        [SerializeField] private PlayerListing _playerListing;

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

        private void SetReadyUp(bool state)
        {
            _ready = state;
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
        
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            AddPlayerListing(newPlayer);
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
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                PhotonNetwork.LoadLevel(1);
            }
        }
    }
}