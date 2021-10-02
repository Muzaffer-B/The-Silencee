using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;

    public float speedH = 1f;
    public float speedV = 1f;
    public Vector3 distance;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        // distance = new Vector3(0, 1.655f, -1.12f);
        distance = transform.position - player.transform.position;
    }

    
    void Update()
    {
        transform.position = player.transform.position + distance;

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedH * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        player.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}
