using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LauraOpenBtn : MonoBehaviour
{
    [SerializeField] GameObject lauraUI;
    [SerializeField] GameObject LauraUIMain;

    public void uusibutton()
    {
        lauraUI.SetActive(false);
        LauraUIMain.SetActive(true);
    }
}
