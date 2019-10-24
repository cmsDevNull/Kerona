using System.Collections.Generic;
using UnityEngine;

/*
Dungeon Building Algorithm 
    1. calculate scaled depth 
    2. place entrance 
    3. place room with exits until depth = 0 
    4. for every exit left, place room without exit
    5. for the last exit, place boss room
*/
public class TestBuilder : MonoBehaviour
{
    public int players = 3;
    public int minDepth = 6;
    public DungeonType buildingAlgorithm;

    List<Vector3> globalExitPointPositions = new List<Vector3>();
    List<Vector3> globalExitPointRotations = new List<Vector3>();

    void Start() {
        Object[] res = Resources.LoadAll("");

        int scaledDepth = scaleDepth(minDepth, players);
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
        
        return room;
    }

    private void placeRoom(GameObject newRoom) {
        // TODO: adjust distances
        Vector3 nextMove = getVector();
        nextMove = overkill(nextMove, newRoom);
        newRoom.transform.position = cullFirstFromList(globalExitPointPositions);
        newRoom.transform.Rotate(cullFirstFromList(globalExitPointRotations));
        newRoom.transform.position += nextMove;
        Instantiate(newRoom);
        addExitPoints(newRoom.GetComponent<DungeonRoom>());
    }

    private Vector3 getVector() { 
        try {
            return globalExitPointPositions[0]; 
        } catch (System.Exception) {
            return new Vector3(0, 0, 0);
        }
    }

    private Vector3 overkill(Vector3 epp, GameObject room){
        // TODO: room is currently previous room, not new room
        // also, refactor
        if (epp.x != 0) {
            float x = room.transform.localScale.x / 2;
            epp += new Vector3(x, 0, 0);
        }
        if (epp.y != 0) {
            float y = room.transform.localScale.y / 2;
            epp += new Vector3(0, y, 0);
        }
        if (epp.z != 0) {
            float z = room.transform.localScale.z / 2;
            epp += new Vector3(0, 0, z);
        }
        return epp;
    }

    private Vector3 cullFirstFromList(List<Vector3> list){
        try {
            Vector3 firstVal = list[0];
            list.RemoveAt(0);
            return firstVal;
        } catch (System.Exception) {
            return new Vector3(0, 0, 0);
        }
    }
    
    private void addExitPoints(DungeonRoom room) {
        Vector3 roomPos = room.gameObject.transform.position;
        Vector3 roomRot = room.gameObject.transform.rotation.eulerAngles;
        foreach (Vector3 epp in room.exitPointPositions) globalExitPointPositions.Add(epp + roomPos);
        foreach (Vector3 epr in room.exitPointRotations) globalExitPointRotations.Add(epr + roomRot);
//        shuffleExitPoints();        
    }
/* 
    private void shuffleExitPoints() {
        globalExitPointPositions.Reverse();
        globalExitPointRotations.Reverse();
    }
*/
}

public enum DungeonType
{
    Demo,
    Cave
}