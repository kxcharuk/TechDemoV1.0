using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningCollectible : MonoBehaviour
{
    [SerializeField] float respawnTime;
    private float timeStamp;
    private float timeElapsed;

    private bool startTimer;
    public bool StartTimer
    {
        set => startTimer = value;
    }
    private bool isRespawning;

    BoxCollider myCol;
    MeshRenderer myMesh;

    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<BoxCollider>();
        myMesh = GetComponent<MeshRenderer>();
        startTimer = false;
        isRespawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            if (!isRespawning)
            {
                timeStamp = Time.time;
                myCol.enabled = false;
                myMesh.enabled = false;
                isRespawning = true;
            }
            if (isRespawning)
            {
                timeElapsed = Time.time - timeStamp;
                if (timeElapsed >= respawnTime)
                {
                    ReactivateCollectible();
                }
            }
        }
    }


    private void ReactivateCollectible()
    {
        startTimer = false;
        isRespawning = false;
        myCol.enabled = true;
        myMesh.enabled = true;
    }
}
