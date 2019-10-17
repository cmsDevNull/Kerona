using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public int roomWidth;
    public int roomLength;
    public int roomHeight;
    public RoomType type;
    public Vector3 entrancePoint;
    public Vector3[] exitPointPositions;
    public Quaternion[] exitPointRotations;
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