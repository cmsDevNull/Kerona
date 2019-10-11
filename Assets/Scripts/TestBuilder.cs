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
            GameObject room = pickRoom(i);
            placeRoom(room);
        }
    }

    private int scaleDepth(int baseDepth, int playerCount) => baseDepth + (baseDepth / 2 * (playerCount - 1));

    private GameObject pickRoom(int roomIndex) {
        string roomDir = "Demo";
        switch (roomIndex) {
            case 0:
                roomDir += "/Entrances";
                break;
            default:
                roomDir += "/Empty";
                break;
        }
        GameObject possibleRooms = Instantiate(Resources.Load("DemoEntrance1", typeof(GameObject))) as GameObject;
        //Debug.Log(possibleRooms.transform.localScale.x);
        return possibleRooms; //[Random.Range(0, possibleRooms.Length)];
    }

    private void placeRoom(Object room){
        Debug.Log(room);
    }
}
