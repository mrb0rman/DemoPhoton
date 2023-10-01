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

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            var listing = Instantiate(_playerListing, _content);
            if (listing != null)
            {
                listing.SetPlayerRoom(newPlayer);
                _listPlayer.Add(listing);
            }
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
    }
}