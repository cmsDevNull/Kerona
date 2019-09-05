using UnityEngine;

public class TestPlayerJoined : Bolt.EntityBehaviour<IcustomTestState>
{
    public override void Attached() {
        var evnt = TestPlayerJoinedEvent.Create();
        evnt.TestMessage = "Hi!";
        evnt.Send();
    }
}