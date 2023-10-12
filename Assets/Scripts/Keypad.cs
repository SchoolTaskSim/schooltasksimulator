using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keypad : MonoBehaviour
{

    Transform cam;
    [SerializeField] LayerMask KeypadLayer;
    [SerializeField] GameObject Keypadui;

    [SerializeField] TextMeshProUGUI txt_keypad;
    void Start()
    {
        cam = Camera.main.transform;
    }


    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 2, KeypadLayer))
        {
            txt_keypad.text = $"Paina F avataksesi";

            if (Input.GetKeyDown(KeyCode.F))
            {

                Keypadui.SetActive(true);
            }

            else if (Keypadui.activeInHierarchy && Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
                Keypadui.SetActive(false);
            }



        }
        else
        {
            txt_keypad.text = string.Empty;
        }
    }
}
