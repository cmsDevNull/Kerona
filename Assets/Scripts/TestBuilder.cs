using System.Collections.Generic;
using UnityEngine;

/*
Dungeon Building Algorithm 
    1. calculate scaled depth 
    2. initiate empty hypermatrix 
    3. place entrance 
    4. place arena or empty room until depth = 0 
    5. for every exit left, place treasure, special or dead-end room 
    6. for the last exit, place boss room
*/
public class TestBuilder : MonoBehaviour
{
    public int players = 3;
    public int minDepth = 6;
    public DungeonType buildingAlgorithm;
    List<Vector3> globalExitPointPositions = new List<Vector3>();
    List<Quaternion> globalExitPointRotations = new List<Quaternion>();

    void Start() {
        int scaledDepth = scaleDepth(minDepth, players);

        Object[] res = Resources.LoadAll("");

        for (int i = 0; i < scaledDepth; i++) {
            
            GameObject room = pickRoom(res, i);

            placeRoom(room);
        }
    }

    private int scaleDepth(int baseDepth, int playerCount) => baseDepth + (baseDepth / 2 * (playerCount - 1));

    private GameObject pickRoom(Object[] res, int roomIndex) {
        string roomName = buildingAlgorithm.ToString();

        switch (roomIndex) {
            case 0:
                roomName += "Entrance";
                break;
            default:
                roomName += "Room";
                switch (Random.Range(0, 2)) {
                    case 0:
                        roomName += "Empty";
                        break;
                    default:
                        roomName += "Arena";
                        break;
                }
                break;
        }

        List<GameObject> rooms = new List<GameObject>();
        foreach (var r in res) if (r.name.Contains(roomName)) rooms.Add((GameObject)r);
        GameObject room = rooms[Random.Range(0, rooms.Count)];
        addExitPoint(room.GetComponent<DungeonRoom>());
        
        return room;
    }

    private void placeRoom(GameObject room){
        Instantiate(room);
    }

    private void addExitPoint(DungeonRoom room) {
        foreach (Vector3 epp in room.exitPointPositions) globalExitPointPositions.Add(epp);
        foreach (Quaternion epr in room.exitPointRotations) globalExitPointRotations.Add(epr);        
    }
}

public enum DungeonType
{
    Demo,
    Cave
}