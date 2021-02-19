using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Vector3 direction;
    private float horizontal;
    private float vertical;

    private float speed;

    Vector3 respawnPosition;
    Vector3 originalScale;
    [SerializeField] Vector3 minimizeScale = new Vector3(0.5f, 0.5f, 0.5f);

    private bool isSmall;

    [SerializeField] private int keys;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        direction = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

    }
}
