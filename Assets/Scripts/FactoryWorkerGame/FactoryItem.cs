using UnityEngine;

public class FactoryItem : MonoBehaviour
{
    [HideInInspector] public FactoryWorkerGameManager.ItemType type;

    void Start()
    {
        int random = Random.Range(1, 3);
        
        if (random == 1)
        {
            type = FactoryWorkerGameManager.ItemType.Green;
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (random == 2)
        {
            type = FactoryWorkerGameManager.ItemType.Red;
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
