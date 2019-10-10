using UnityEngine;

public class TestBuilder : MonoBehaviour
{
    public int players = 3;
    public int minDepth = 6;

    private Dungeon testDungeon;

    void Start() {
        /* algorithm: 
        --> calculate scaled depth 
        --> initiate empty hypermatrix 
        --> place entrance 
        --> place arena or empty room until depth = 0 
        --> for every exit left, place treasure, special or dead-end room 
        --> for the last exit, place boss room
        */
        int dungeonDepth = scaleDepth(minDepth, players);
        for (int i = 0; i < dungeonDepth; i++) {
            Object room = pickRoom(i, dungeonDepth - 1);
            placeRoom(room);
        }
    }

    private int scaleDepth(int baseDepth, int playerCount) => baseDepth + (baseDepth / 2 * (playerCount - 1));

    private Object pickRoom(int roomIndex, int lastRoomIndex) {
        switch (roomIndex) {
            case 1:
                break;
            default:
                break;
        }
        Object[] possibleRooms = Resources.LoadAll("Demo/Entrances");
        return possibleRooms[Random.Range(0, possibleRooms.Length + 1)];
    }

    private void placeRoom(Object room){
        Instantiate(room);
    }
}
