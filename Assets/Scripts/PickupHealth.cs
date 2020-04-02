using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    void OnTriggerEnter(Collider c){
        Destroy(transform.parent.gameObject);
    }
}
