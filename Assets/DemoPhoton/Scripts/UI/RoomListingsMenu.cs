using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace DemoPhoton.Scripts.UI
{
    public class RoomListingsMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform _content;
        [SerializeField] private RoomListing _roomListing;

        private List<RoomListing> _listRoom = new List<RoomListing>();

        public override void OnJoinedRoom()
        {
            _content.DestroyChildren();
            _listRoom.Clear();
        }

        // Обновление списка созданных комнат
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            foreach (var info in roomList)
            {
                if (info.RemovedFromList)
                {
                    int index = _listRoom.FindIndex(x => x.RoomInfo.Name == info.Name);
                    if (index != -1)
                    {
                        Destroy(_listRoom[index].gameObject);
                        _listRoom.RemoveAt(index);
                    }
                }
                else
                {
                    int index = _listRoom.FindIndex(x => x.RoomInfo.Name == info.Name);
                    if (index == -1)
                    {
                        var listing = Instantiate(_roomListing, _content);
                        if (listing != null)
                        {
                            listing.SetInfoRoom(info);
                            _listRoom.Add(listing);
                        }
                    }
                }
            }
        }
    }
}