using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour
{
    public float rotationSpeed = 0.2f;

    void Update() => transform.Rotate(new Vector3(0, rotationSpeed, 0));
}
