using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Nose"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            other.GetComponentInParent<Player>().isAboveWater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Nose"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponentInParent<Player>().isAboveWater = false;
        }
    }
}
