using UnityEngine;

public class TestEnemySpawnEvent : MonoBehaviour
{
    public GameObject enemies;

    void Start() => enemies.SetActive(false);

    void OnTriggerEnter(Collider other) {
        enemies.SetActive(true);
        Destroy(this.gameObject);
    }
}
