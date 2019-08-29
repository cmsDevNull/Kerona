using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Awake() {
        joinServer();
        setPlayerPrefs();
    }

    private int findServer() {
        return 1;
    }

    private void joinServer() {
        int server = findServer();
    }

    private void setPlayerPrefs() {

    }
}
