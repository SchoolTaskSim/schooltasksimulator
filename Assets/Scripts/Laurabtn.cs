using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laurabtn : MonoBehaviour
{
    [SerializeField] GameObject lauraUI;

    public void uusibutton()
    {
        lauraUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
