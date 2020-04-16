using UnityEngine;

public class TrapDamageCrystal : MonoBehaviour
{
    void OnCollisionEnter(Collision c) {
        Debug.Log(c.gameObject.name);
    }
}
