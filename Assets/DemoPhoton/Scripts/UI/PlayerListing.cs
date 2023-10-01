using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace DemoPhoton.Scripts.UI
{
    public class PlayerListing : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public Player Player { get; private set; }
        
        public void SetPlayerRoom(Player player)
        {
            Player = player;
            _text.text = player.NickName;
        }
    }
}