using UnityEngine;

namespace DemoPhoton.Scripts.UI
{
    public class UIService : MonoBehaviour
    {
        public GameObject[] ListWindow => _listWindow;
        
        [SerializeField] private GameObject[] _listWindow;
    }
}