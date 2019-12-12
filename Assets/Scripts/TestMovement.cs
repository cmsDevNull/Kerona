using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float movSpeed = 3f;

    void Update() {
        if (Input.GetKey(KeyCode.A)) transform.position += new Vector3(-movSpeed/50, 0, 0); 
        if (Input.GetKey(KeyCode.D)) transform.position += new Vector3(movSpeed/50, 0, 0); 
        if (Input.GetKey(KeyCode.W)) transform.position += new Vector3(0, 0, movSpeed/50); 
        if (Input.GetKey(KeyCode.S)) transform.position += new Vector3(0, 0, -movSpeed/50); 
        if (Input.GetKeyUp(KeyCode.Space)) GetComponent<Rigidbody>().AddForce(0, movSpeed * 100, 0);
    }
}
