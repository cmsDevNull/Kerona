using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public int roomWidth;
    public int roomLength;
    public int roomHeight;
    public RoomType type;
    public Coordinate entrancePoint;
    public Coordinate[] exitPoints;
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