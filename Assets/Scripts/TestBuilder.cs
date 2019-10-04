using UnityEngine;

public class TestBuilder : MonoBehaviour
{
    public int players = 3;
    public int minRooms = 6;

    private Dungeon testDungeon;

    void Start() {
        // algorithm: calculate scaling --> initiate empty hypermatrix --> for every room, pick one randomly out of a list and place (instantiate) it in the hypermatrix
        int rooms = scaleRoomBase(minRooms, players);
        initiateDungeon(testDungeon, rooms);
        for (int i = 0; i < rooms; i++) {
            Object room = pickRoom(i, rooms - 1);
            placeRoom();
        }
    }

    private void initiateDungeon(Dungeon dungeon, int roomCount) {
        int dungeonWidth = roomCount * 3;
        int dungeonLength = roomCount * 3;
        int dungeonHeight = roomCount * 2;
        for (int x = 0; x < dungeonWidth; x++) {
            for (int y = 0; y < dungeonLength; y++) {
                for (int z = 0; z < dungeonHeight; z++) {
                    dungeon.rooms[x][y][z] = null;
                }
            }
        }
    }

    private int scaleRoomBase(int roomBase, int playerCount) => roomBase + (roomBase / 2 * (playerCount - 1));

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

    private void placeRoom(){

    }
}
