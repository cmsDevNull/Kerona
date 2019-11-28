using UnityEngine;

/*
    keeps track of placed DungeonRooms and avoids collisions
*/
public class DungeonSpace : MonoBehaviour
{
    public Vector3[] space;

    public bool checkSpace(Vector3 newRoomPos) {
        return true;
    }
}
