using UnityEngine;

public class TestPlayerHealth : Bolt.EntityBehaviour<IcustomTestState>
{
    public int localHealth = 3;

    public override void Attached() {
        state.health = localHealth;

        state.AddCallback("health", healthCallback);
    }

    private void healthCallback() {
        localHealth = state.health;
        if (localHealth <= 0) BoltNetwork.Destroy(this.gameObject);
    }

// "you change the state variable; and then syncronize the local variable"
// "when a change is detected, a callback function is called"
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) state.health -= 1;
    }
}
