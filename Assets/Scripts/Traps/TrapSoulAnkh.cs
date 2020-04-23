using UnityEngine;

public class TrapSoulAnkh : MonoBehaviour
{
    void OnTriggerEnter(Collider c) {
        Debug.Log(c.gameObject.name);
    }
}
