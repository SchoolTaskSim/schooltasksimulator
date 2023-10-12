using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public void UseItem(int id)
    {
        switch (id)
        {
            case 0: //työkalupakki
                print("pakki kasassa");
                break;
            case 1: 
                break;
            case 2: 
                break;
            case 3: 
                break;

            default:
                break;
               
        }
    }

}
