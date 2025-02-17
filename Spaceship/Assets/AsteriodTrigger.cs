using UnityEngine;

public class AsteriodTrigger : MonoBehaviour
{
    public float TriggerRange = 2;
    public void Update()
    {
        if (Vector2.Distance(Move.InstanceShip.transform.position, gameObject.transform.position) < TriggerRange)
        {
            Destroy(gameObject);
        }
    }
}
