using UnityEngine;

public class TrapDamageFanblade : MonoBehaviour
{
    void Update() {
        transform.Rotate(0,5,0);
    }

    void OnCollisionEnter(Collision c) {
        Debug.Log(c.gameObject.name);
    }
}
