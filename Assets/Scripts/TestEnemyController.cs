using UnityEngine;

public class TestEnemyController : MonoBehaviour
{
    public GameObject jumpOnMe;

    void Update() {
        if (jumpOnMe.GetComponent<TestJumpable>().isJumpedOn) {
            transform.localScale -= new Vector3(0, 0.02f, 0);
            if (transform.localScale.y <= 0) Destroy(this.gameObject);
        }
    }
}
