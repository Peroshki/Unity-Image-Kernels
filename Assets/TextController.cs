// A script to correct for the movement in the text element.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    GameObject info;
    ImageController ic;
    Text textBox;

    public float moveSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        // Grab a GameObject to get access to its variables
        info = GameObject.Find("Sharpen");
        ic = info.GetComponent<ImageController>();

        // Grab the textbox component
        textBox = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Steps: " + ic.stepCount + "     Mix: " + ic.mix; // Update text


        // Counteract zoom from camera
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += (Vector3.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.position -= Vector3.forward * moveSpeed;
        }

        // Counteract movement from camera
        if (Input.GetKey(KeyCode.W))
        {
            transform.position -= Vector3.up * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed;
        }
    }
}
