using UnityEngine;

public class TestMenu : Bolt.GlobalEventListener
{
    public void StartServer() {
        BoltLauncher.StartServer();
    }    
    
    public void StartClient() {
        BoltLauncher.StartClient();
    }

    public override void BoltStartDone() {
        if (BoltNetwork.IsServer) {
            string matchName = "Test Match";
            Bolt.Matchmaking.BoltMatchmaking.CreateSession(matchName, null, "BoltDemo");
            //BoltNetwork.SetServerInfo(matchName, null);
            //BoltNetwork.LoadScene("BoltDemo");
        }
    }

    public override void SessionListUpdated(UdpKit.Map<System.Guid, UdpKit.UdpSession> sessionList) {
        foreach (var session in sessionList) {
            UdpKit.UdpSession photonSession = session.Value as UdpKit.UdpSession;
            if (photonSession.Source == UdpKit.UdpSessionSource.Photon) BoltNetwork.Connect(photonSession);
        }
    }
}
