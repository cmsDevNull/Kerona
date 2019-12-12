using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject player;

    private Vector3 spawnPos = new Vector3(0, 1, 0);
    private bool isSpawned = false;

    void Update() {
        if (!isSpawned && !GetComponent<TestBuilder>().getIsBuilding()) {
            Instantiate(player, spawnPos, Quaternion.identity);
            isSpawned = true;
        }
    }
}
