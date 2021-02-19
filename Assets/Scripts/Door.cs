using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float openSpeed = 1;
    [SerializeField] float maxY;
    float startingPosY;

    // states for door
    private int state;

    const int STATE_OPEN = 1;
    const int STATE_OPENING = 2;
    const int STATE_CLOSED = 3;
    const int STATE_CLOSING = 4;

    [SerializeField] private bool isLocked;
    public bool IsLocked
    {
        get => isLocked;
        set => isLocked = value;
    }
    

    Vector3 doorVector;
    Vector3 startingDoorPos;

    // Start is called before the first frame update
    void Start()
    {
        state = STATE_CLOSED;

        doorVector = new Vector3(0, 1 * openSpeed, 0) * Time.deltaTime;
        startingPosY = door.transform.position.y;
        startingDoorPos = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == STATE_OPENING)
        {
            door.transform.Translate(doorVector);
            PositionRangeCheck(door.transform.position.y);
        }
        else if (state == STATE_CLOSING)
        {
            door.transform.Translate(-doorVector);
            PositionRangeCheck(door.transform.position.y);
        }
    }

    public void Open()
    {
        state = STATE_OPENING;
    }

    public void Close()
    {
        state = STATE_CLOSING;
    }

    private void PositionRangeCheck(float posY)
    {
        if (posY >= (startingPosY + maxY))
        {
            Debug.Log("maxY: " + maxY);
            state = STATE_OPEN;
            door.transform.position = new Vector3(startingDoorPos.x, startingDoorPos.y + maxY, startingDoorPos.z);
        }
        else if (posY < startingPosY)
        {
            state = STATE_CLOSED;
            door.transform.position = startingDoorPos;
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if(other.tag != "Door")
        {
            somethingInDoor = true;
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if(state == STATE_OPEN)
        {
            state = STATE_CLOSING;
        }
    }
}
