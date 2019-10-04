using UnityEngine;

// To be placed on a child object of a Room that has a Collider that is a Trigger
public class DungeonSpawnEvent : DungeonEvent
{
    public SpawnType type;

    private void OnTriggerEnter(Collider other) {
        if (!isTriggered && other.gameObject.tag == "Player") {
            switch (this.type) {
                case SpawnType.spawnEnemies:
                    Debug.Log("SPAWN ENEMIES");
                    break;
                case SpawnType.spawnTreasure:
                    Debug.Log("SPAWN TREASURE");
                    break;
                case SpawnType.spawnBoss:
                    Debug.Log("SPAWN BOSS");
                    break;
            }
            isTriggered = true;
        }
    }
}

public enum SpawnType
{
    spawnEnemies,
    spawnTreasure,
    spawnBoss
}