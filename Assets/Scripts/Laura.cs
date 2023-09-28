using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Laura : MonoBehaviour
{

    Transform cam;
    [SerializeField] LayerMask lauraLayer;
    [SerializeField] GameObject lauraUI;

    [SerializeField] TextMeshProUGUI txt_laura;
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 2, lauraLayer))
        {
            txt_laura.text = $"Paina F avataksesi";

            if (Input.GetKeyDown(KeyCode.F))
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Time.timeScale = 0f;
                lauraUI.SetActive(true);
            }

            else if (lauraUI.activeInHierarchy && Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
                lauraUI.SetActive(false);
            }



        }
        else
        {
            txt_laura.text = string.Empty;
        }
    }
}
