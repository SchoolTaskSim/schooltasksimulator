using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// k.v


public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    Transform parent;
    Transform cam;
    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        rotate();
        // rotate cam and orientation


        }


     public void rotate()
    {
         // mahdollistaa kameran rotaation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    public void rotateoff()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }



    public void kamerap‰‰lle()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            sensX = 400;
            sensY = 400;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}