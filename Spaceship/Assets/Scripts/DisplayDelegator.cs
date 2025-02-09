using UnityEngine;
using Unity.Netcode;

public class DisplayDelegator : MonoBehaviour
{
    private Camera[] realAllCameras;

    public void Awake()
    {
        realAllCameras = Camera.allCameras;
    }
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));

        if (GUILayout.Button("Host Display"))
        {
            print("Setting display to host");
            SwitchCamera("HostCamera");
        }
        if (GUILayout.Button("Map Display"))
        {
            print("Setting display to map");
            SwitchCamera("MapCamera");
        }
        if (GUILayout.Button("Radar Display"))
        {
            print("Setting display to radar");
            SwitchCamera("RadarCamera");
        }

        GUILayout.EndArea();
    }

    //Enables the camera with the given name, and disables all others.
    private void SwitchCamera(string DesiredCam)
    {
        foreach (Camera curCam in realAllCameras)
        {
            if (string.Equals(curCam.gameObject.name, DesiredCam))
            {
                curCam.enabled = true;
            }
            else
            {
                curCam.enabled = false;
            }
        }
    }
}
