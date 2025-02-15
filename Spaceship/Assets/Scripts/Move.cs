using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Move : NetworkBehaviour
{

    //The Ship moves this amount every 0.02 Seconds.
    public float Speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<NetworkObject>().SetOwnershipStatus(NetworkObject.OwnershipStatus.Distributable);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(0,Speed), Space.Self);
    }

    [Rpc(SendTo.Server)]
    public void turnRpc(int Degrees)
    {
        transform.Rotate(new Vector3(0, 0, Degrees), Space.Self);
        print("turning");
    }

}
