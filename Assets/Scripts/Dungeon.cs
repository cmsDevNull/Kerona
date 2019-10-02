public class Dungeon
{
    public DungeonRoom[][][] rooms;
}

public class DungeonRoom
{
    public int roomWidth;
    public int roomLength;
    public int roomHeight;
    public int roomNumber;
    public Coordinate entrancePoint;
    public Coordinate[] exitPoints;
    public DungeonEvent[] events;
}

public class Coordinate
{
    public int x;
    public int y;
    public int z;
}

public class DungeonEvent
{
    // a function that is called after a certain requirement is fulfilled
}