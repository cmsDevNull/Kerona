using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{
    public DungeonRoom[][][] rooms;
}

public class DungeonRoom
{
    public Coordinate entrancePoint;
    public Coordinate exitPoint;
}

public class Coordinate
{
    public int x;
    public int y;
    public int z;
}
