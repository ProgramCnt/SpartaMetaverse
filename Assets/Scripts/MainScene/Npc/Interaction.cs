using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == null)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
