// A script to control the amount of image processing steps applied to the images in the scene
// as well as the mix between the original image and the processed image.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    Renderer render;

    // Image processing variables
    public int stepCount;
    public float mix;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables to preset values
        stepCount = 0;
        mix = 0.3f;

        // Find renderer for the object and set initial values
        render = GetComponent<Renderer>();

        if (gameObject.tag == "Sharpen")
        {
            render.material.shader = Shader.Find("Custom/Sharpen");
        }
        else if (gameObject.tag == "Blur")
        {
            render.material.shader = Shader.Find("Custom/Blur");
        }
        render.material.SetInt("_Steps", stepCount);
        render.material.SetFloat("_Mix", mix);
    }

    // Update is called once per frame
    void Update()
    {
        // Change amount of processing steps, limited between 0 and 20
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            stepCount++;
            
            if (stepCount > 20) 
            {
                stepCount = 20;
            }
            
            render.material.SetInt("_Steps", stepCount);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stepCount--;

            if (stepCount < 0) 
            {
                stepCount = 0;
            }

            render.material.SetInt("_Steps", stepCount);
        }

        // Change blend between non processed and processed image
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mix += 0.01f;

            if (mix > 1.0f) 
            {
                mix = 1.0f;
            }

            render.material.SetFloat("_Mix", mix);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mix -= 0.01f;

            if (mix < 0.0f) 
            {
                mix = 0.0f;
            }

            render.material.SetFloat("_Mix", mix);
        }
    }
}
