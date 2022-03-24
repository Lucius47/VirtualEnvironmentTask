using UnityEngine;

public class ItemTargetPosition : MonoBehaviour
{
    [SerializeField] FactoryWorkerGameManager.ItemType itemType;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("FactoryItem"))
        {
            if (collider.gameObject.GetComponent<FactoryItem>().type == this.itemType)
            {
                FactoryWorkerGameManager.ins.CorrectItemPlaced();
            }
            else if (collider.gameObject.GetComponent<FactoryItem>().type != this.itemType)
            {
                FactoryWorkerGameManager.ins.WrongItemPlaced();
            }

            Destroy(collider.gameObject, 1);
        }
    }
}
