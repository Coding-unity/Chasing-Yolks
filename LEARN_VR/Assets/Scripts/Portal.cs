using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform PortalA, PortalB;
    public GameObject Basket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            Basket.transform.position = PortalB.transform.position;
            Basket.transform.localScale = Vector3.one * 0.04f;
            PortalB.gameObject.SetActive(false); 
        }
    }
 
}
