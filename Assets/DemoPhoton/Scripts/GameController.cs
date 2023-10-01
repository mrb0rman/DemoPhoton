using DemoPhoton.Scripts.UI.UIWindow;
using UnityEngine;

namespace DemoPhoton.Scripts
{
    public class GameController : MonoBehaviour
    {
        private UIService _uiService;
        private UIConnectWindowController _uiConnectWindowController;
        private UIProgressConnectWindowController _uiProgressConnectWindowController;
        private UIRoomListWindowController _uiRoomListWindowController;
        
        private void Start()
        {
            InitUI();
            StartGame();
        }

        private void InitUI()
        {
            _uiService = new UIService(ResourcesConst.UILauncherScene);
            
            _uiConnectWindowController = new UIConnectWindowController(_uiService);
            _uiProgressConnectWindowController = new UIProgressConnectWindowController(_uiService);
            _uiRoomListWindowController = new UIRoomListWindowController(_uiService);
        }

        private void StartGame()
        {
            _uiService.Show<UIConnetctWindow>();
        }
    }
}