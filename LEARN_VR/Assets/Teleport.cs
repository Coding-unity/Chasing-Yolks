using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Basket;
    public Transform TeleportPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Basket"))
        {
            if(Vector2.Distance(Basket.transform.position ,this.transform.position) > 0.01f )
            {
                Basket.transform.position = TeleportPos.position;
                Debug.Log("fjkgkafg");
            }
        }
    }
}
