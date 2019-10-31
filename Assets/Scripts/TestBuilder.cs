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

/*
Current issue:
Exitpoints of rotated rooms are set incorrectly (OR: offset calculation is way wrong)
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

        for (int i = 0; i < scaleDepth(minDepth, players); i++) {  
            GameObject room = pickRoom(res, generateRoomName(i, "start"));
            if (i == 0) spawnRoom(room); 
            else placeRoom(room);
        }

        for (int i = globalExitPointPositions.Count; i > 0; i--) {
            GameObject room = pickRoom(res, generateRoomName(i, "end"));
            placeRoom(room);
        }
    }

    private int scaleDepth(int baseDepth, int playerCount) => baseDepth + (baseDepth / 2 * (playerCount - 1));

    private GameObject pickRoom(Object[] res, string roomName) {
        List<GameObject> rooms = new List<GameObject>();
        foreach (var r in res) if (r.name.Contains(roomName)) rooms.Add((GameObject)r);
        return rooms[Random.Range(0, rooms.Count)];
    }

    private string generateRoomName(int index, string option) {
        string roomName = buildingAlgorithm.ToString();

        switch (option) {
            case "start":
                switch (index) {
                    case 0:
                        roomName += "Entrance";
                        break;
                    default:
                        roomName += "Room";
                        switch (Random.Range(0, 2)) {
                            case 0:
                                roomName += "Empty";
                                break;
                            case 1:
                                roomName += "Arena";
                                break;
                        }
                    break;
                }
                break;
            case "end":
                switch (index) {
                    case 1:
                        roomName += "Boss";
                        break;
                    default:
                        roomName += "Room";
                        switch (Random.Range(0, 3)) {
                            case 0:
                                roomName += "Puzzle";
                                break;
                            case 1:
                                roomName += "Treasure";
                                break;
                            case 2:
                                roomName += "Trap";
                                break;
                        }
                    break;
                }
                break;
        }

        return roomName;
    }

    private void spawnRoom(GameObject room) {
        Instantiate(room);
        addExitPoints(room.GetComponent<DungeonRoom>());
    }

    private void placeRoom(GameObject newRoom) {
        newRoom.transform.position = cullFirstFromList(globalExitPointPositions);

        Vector3 roomOffset = newRoom.GetComponent<DungeonRoom>().entrancePointPosition;
        roomOffset = inverseVector(roomOffset);

        Vector3 rot = cullFirstFromList(globalExitPointRotations);
        if (rot != new Vector3()){
            newRoom.transform.Rotate(rot);
            roomOffset = mapVectorToRoomRotation(newRoom, roomOffset);
        }

        newRoom.transform.localPosition += roomOffset;
        spawnRoom(newRoom);
    }

    private Vector3 inverseVector(Vector3 v) { return new Vector3(-v.x, -v.y, -v.z); }

    private Vector3 mapVectorToRoomRotation(GameObject room, Vector3 offset) {
        int rotAngle = Mathf.RoundToInt(room.transform.localEulerAngles.y);
        while (rotAngle > 360) rotAngle -= 360;
        if (rotAngle < 0) rotAngle += 360;

        if (rotAngle == 270) return new Vector3(-offset.z, 0, -offset.x);
        else if (rotAngle == 180) return inverseVector(offset);
        else if (rotAngle == 90) return new Vector3(offset.z, 0, offset.x);
        else return offset;
    }

    private Vector3 cullFirstFromList(List<Vector3> list){
        Vector3 firstVal = list[0];
        list.RemoveAt(0);
        return firstVal;
    }
    
    private void addExitPoints(DungeonRoom room) {
        Vector3 roomPos = room.gameObject.transform.position;
        Vector3 roomRot = room.gameObject.transform.rotation.eulerAngles;
        foreach (Vector3 epp in room.exitPointPositions) globalExitPointPositions.Add(epp + roomPos);
        foreach (Vector3 epr in room.exitPointRotations) globalExitPointRotations.Add(epr + roomRot);
    }
}

public enum DungeonType
{
    Demo,
    Cave
}