using UnityEngine;

public class DroppedItemCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("FactoryItem"))
        {
            Destroy(collider.gameObject);
        }
    }
}
