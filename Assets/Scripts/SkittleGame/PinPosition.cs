using UnityEngine;

public class PinPosition : MonoBehaviour
{
    public bool pinDropped = false;

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("SkittlePin") && !pinDropped)
        {
            SkittleManager.ins.DropPin();
            pinDropped = true;
        }
    }
}
