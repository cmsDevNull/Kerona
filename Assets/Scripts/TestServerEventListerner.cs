using UnityEngine;

public class TestServerEventListerner : Bolt.GlobalEventListener
{
    public override void OnEvent(TestPlayerJoinedEvent evnt) {
        Debug.LogWarning(evnt.TestMessage);
    }
}
