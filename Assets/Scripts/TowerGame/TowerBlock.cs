using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBlock : MonoBehaviour
{
    [SerializeField] int number;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TowerBlock") && other.gameObject != this.gameObject)
        {
            if (other.gameObject.GetComponent<TowerBlock>().Number == this.Number + 1)
            {
                TowerGameManager.ins.AddBlock();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TowerBlock") && other.gameObject != this.gameObject)
        {
            if (other.gameObject.GetComponent<TowerBlock>().Number == this.Number + 1)
            {
                TowerGameManager.ins.RemoveBlock();
            }
        }
    }


    public int Number
    {
        get { return number; }
    }
}
