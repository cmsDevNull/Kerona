using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public RoomType type;
    public Vector3[] exitPointPositions;
    public Vector3[] exitPointRotations;
    public DungeonEvent[] events;
}

public enum RoomType 
{
    entrance,
    empty,
    puzzle,
    arena,
    treasure,
    boss
}