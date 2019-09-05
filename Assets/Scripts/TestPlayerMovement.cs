using UnityEngine;

public class TestPlayerMovement : Bolt.EntityBehaviour<IcustomTestState>
{
    // like Start(), but is executed when prefab is loaded into the game
    public override void Attached() {
        state.SetTransforms(state.customTestTransform, gameObject.transform);
    }

    // like Update(), but only called on the Owner's computer
    public override void SimulateOwner() {
        float speed = 4f;
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) movement.x -= 1f;
        if (Input.GetKey(KeyCode.D)) movement.x += 1f;
        if (Input.GetKey(KeyCode.S)) movement.z -= 1f;
        if (Input.GetKey(KeyCode.W)) movement.z += 1f;

        if (movement != Vector3.zero) transform.position = transform.position + (movement.normalized * speed * BoltNetwork.FrameDeltaTime);
    }
}
