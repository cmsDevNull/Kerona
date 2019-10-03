public class DungeonRoom
{
    public int roomID;
    public int roomWidth;
    public int roomLength;
    public int roomHeight;
    public Coordinate entrancePoint;
    public Coordinate[] exitPoints;
    public RoomType type;
    public DungeonEvent[] events;
}

public enum RoomType {
    entrance,
    safe,
    fight,
    treasure,
    boss
}