using System.Threading.Tasks;
using DemoPhoton.Scripts.UI.UIWindow;
using Photon.Pun;

public class UIConnectWindowController
{
    private readonly UIService _uiService;

    public UIConnectWindowController(UIService uiService)
    {
        _uiService = uiService;
        _uiService.Get<UIConnetctWindow>().ConnectButton.onClick.AddListener(ShowProgressConnect);
        _uiService.Get<UIConnetctWindow>().ConnectButton.onClick.AddListener(Connect);
    }

    private void ShowProgressConnect()
    {
        _uiService.Hide<UIConnetctWindow>();
    }
    
    private void Connect()
    {
         PhotonNetwork.ConnectUsingSettings();
    }
}
