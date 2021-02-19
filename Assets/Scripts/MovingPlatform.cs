using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] Vector3 destination;
    [SerializeField] Vector3 origin;
    [SerializeField] Vector3 direction;
    [SerializeField] Vector3 distance;

    Vector3 initialPos;
    Vector3 initialDes;

    [SerializeField] float delayTime;
    float timeStamp;

    bool playerOnPlatform;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        initialPos = transform.position;
        direction = (destination - origin).normalized;
        playerOnPlatform = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform)
        {
            if(Time.time - timeStamp > delayTime)
            {
                MovePlatform();
            }
        }
    }

    private void MovePlatform()
    {
        distance = destination - transform.position;
        transform.Translate(direction * speed * Time.deltaTime);
        if(distance.magnitude <= 0.01f)
        {
            transform.position = destination;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.parent = this.transform;
            playerOnPlatform = true;
            timeStamp = Time.time;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.parent = null;
            Vector3 newOrigin = destination;
            destination = origin;
            origin = newOrigin;
            direction = (destination - origin).normalized;
            playerOnPlatform = false;
        }

    }

    public void ResetPlatform()
    {

    }
}
