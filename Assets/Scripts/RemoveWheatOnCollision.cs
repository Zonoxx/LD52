using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWheatOnCollision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Tank"))
        {
            Debug.Log("Player collided with wheat");
            Destroy(gameObject);
        }
    }
}
