using UnityEngine;

public class Sticker : MonoBehaviour
{
    public GameObject parent;
    public float zValue = 0;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y,zValue);
    }
}
