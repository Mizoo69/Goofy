using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Slime")
        {
            Destroy(gameObject);
        }
    }
}
