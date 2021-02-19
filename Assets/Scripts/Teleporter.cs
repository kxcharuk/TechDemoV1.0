using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform destination;
    Vector3 destinationPos;

    [SerializeField] private float teleportSpeed;
    public float TeleportSpeed
    {
        get => teleportSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        destinationPos = destination.position;
    }

    public Vector3 ReturnDestinationPos()
    {
        return destinationPos;
    }
}
