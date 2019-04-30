// A script to control camera movement.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Zoom in and out
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position -= Vector3.forward * 0.05f;
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.position += Vector3.forward * 0.05f;
        }

        // Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * 0.05f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * 0.05f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.up * 0.05f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= Vector3.right * 0.05f;
        }
    }
}
