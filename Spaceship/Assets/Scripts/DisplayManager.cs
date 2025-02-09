using UnityEngine;
using Unity.Netcode;

public class DisplayManager : MonoBehaviour
{
    private static NetworkManager MyNetworkManager;

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
