using UnityEngine;
using Unity.Netcode;

public class DisplayManager : MonoBehaviour
{
    private static NetworkManager MyNetworkManager;
    private string IPAddress = "";

    private void Awake()
    {
        MyNetworkManager = GetComponent<NetworkManager>();
    }
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if(!MyNetworkManager.IsClient && !MyNetworkManager.IsServer)
        {
            StartButtons();

            GUILayout.Label("IP Address");
            IPAddress = GUILayout.TextField(IPAddress);
            gameObject.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>().SetConnectionData(IPAddress, 7777);
        }
        GUILayout.EndArea();
    }

    static void StartButtons()
    {
        if (GUILayout.Button("Host"))
        {
            MyNetworkManager.StartHost();
        }
        if (GUILayout.Button("Client"))
        {
            MyNetworkManager.StartClient();
        }

    }


}
