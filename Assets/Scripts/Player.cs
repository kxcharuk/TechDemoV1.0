using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 direction;
    private float horizontal;
    private float vertical;

    private float speed;
    [SerializeField] private float canTeleportDelay;

    [SerializeField] Vector3 minimizeScale = new Vector3(0.5f, 0.5f, 0.5f);

    Vector3 respawnPosition;
    Vector3 originalScale;
    Vector3 teleportPos;

    private bool isSmall;
    private bool isBusy;
    private bool canTeleport;

    Door door;
    MeshRenderer myMesh;
    CapsuleCollider myCol;
    Rigidbody myRb;

    [SerializeField] private int keys;

    // init
    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
        myCol = GetComponent<CapsuleCollider>();
        myRb = GetComponent<Rigidbody>();

        isSmall = false;
        isBusy = false;
        canTeleport = true;
        speed = 4;
        respawnPosition = transform.position;
        originalScale = transform.localScale;
    }

    // ------------------------------------------------------------------ Private Methods
    void Update()
    {
        if (!isBusy)
        {
            Move();
        }
    }
    

    private void Move()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        direction = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Respawn()
    {
        transform.position = respawnPosition;
    }
    

    // ------------------------------------------------------------------ Public Methods

    

    // ------------------------------------------------------------------ Collision/Trigger Detection

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KillBox")
        {
            Respawn();
        }
        else if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
        else if(other.tag == "Key")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<BoxCollider>().enabled = false;
            keys++;
        }
        else if(other.tag == "Health")
        {
            // add heal function here onces healthsytem is created
        }
        else if (other.tag == "Collectible(Respawning)")
        {
            other.GetComponent<RespawningCollectible>().StartTimer = true;
        }
        else if(other.tag == "Teleporter" && canTeleport)
        {
            // get the destination position and move towards it, also locking the player controls.
            transform.position = other.GetComponent<Teleporter>().ReturnDestinationPos();
            StartCoroutine(DelayReteleportation());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "DoorTrigger")
        {
            // press a button to open door
            door = other.GetComponent<Door>();
            if (Input.GetButton("Submit"))
            {
                if (door.IsLocked)
                {
                    //player key check
                    if (keys > 0)
                    {
                        door.IsLocked = false;
                        door.Open();
                    }
                    else return;
                }
                else
                {
                    other.GetComponent<Door>().Open();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Minimizer")
        {
            StartCoroutine(ChangeScale());
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Pushable")
        {
            if (Input.GetButton("Submit"))
            {
                collision.gameObject.transform.parent = transform;

            }
        }
    }

    IEnumerator ChangeScale()
    {
        if (!isSmall)
        {
            transform.localScale = minimizeScale;
            yield return new WaitForSeconds(0.5f);
            isSmall = true;
        }
        else if (isSmall)
        {
            transform.localScale = originalScale;
            yield return new WaitForSeconds(0.5f);
            isSmall = false;
        }
    }

    IEnumerator DelayReteleportation()
    {
        canTeleport = false;
        yield return new WaitForSeconds(canTeleportDelay);
        canTeleport = true;
    }


}
