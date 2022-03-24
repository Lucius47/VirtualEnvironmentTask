using UnityEngine;

public class SkittlesBallReseter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            SkittleManager.ins.ResetBallAfterThrow();
        }
    }
}
