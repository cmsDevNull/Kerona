using UnityEngine;

public class TestJumpable : MonoBehaviour
{
    public bool isJumpedOn = false;

    void OnTriggerEnter(Collider o) {
        if (o.gameObject.tag == "Player") isJumpedOn = true;
    }
}
