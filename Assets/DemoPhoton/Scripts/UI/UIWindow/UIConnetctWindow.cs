using UnityEngine;
using UnityEngine.UI;

namespace DemoPhoton.Scripts.UI.UIWindow
{
    public class UIConnetctWindow : UIWindow
    {
        public Button ConnectButton => _connectButton;
        
        [SerializeField] private Button _connectButton;
        
        public override void Show()
        {
        }

        public override void Hide()
        {
        }
    }
}