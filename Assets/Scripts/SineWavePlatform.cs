using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWavePlatform : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period;

    float movementFactor;
    Vector3 startingPos;


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau); // this goes from -1, 1

        movementFactor = (rawSinWave / 2f) + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }
}
