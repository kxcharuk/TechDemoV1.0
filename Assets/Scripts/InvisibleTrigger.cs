using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTrigger : MonoBehaviour
{
    //[SerializeField] GameObject plane;
    Collider planeCol;
    MeshRenderer planeMesh;

    // Start is called before the first frame update
    void Start()
    {
        planeMesh = this.GetComponent<MeshRenderer>();
        planeCol = this.GetComponent<MeshCollider>();
        planeMesh.enabled = false;
        planeCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            planeMesh.enabled = true;
            planeCol.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            planeMesh.enabled = false;
            planeCol.enabled = false;
        }
    }
}
