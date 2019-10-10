using UnityEngine;

public class Dungeon : MonoBehaviour
{
    public DungeonType type;
    public DungeonRoom[] rooms;
}

public enum DungeonType
{
    demo,
    cave
}