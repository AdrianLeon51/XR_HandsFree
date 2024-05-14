using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    public static bool room1 = true;
    public static bool room2 = true;
    public static bool room3 = true;
    public static bool generalRoom = true;

    private void Update()
    {
        
    }

    public void InRoom1()
    {
        if (room1 == true)
        {
            room1 = false;
        }
        else
        {
            room1 = true;
        }
        Debug.Log("Room1 is: " + room1);
    }

    public void InRoom2()
    {
        if (room2 == true)
        {
            room2 = false;
        }
        else
        {
            room2 = true;
        }
        Debug.Log("Room2 is: " + room2);
    }

    public void InRoom3()
    {
        if (room3 == true)
        {
            room3 = false;
        }
        else
        {
            room3 = true;
        }
        Debug.Log("Room3 is: " + room3);
    }

    public void InGeneralRoom()
    {
        if (generalRoom == true)
        {
            generalRoom = false;
        }
        else
        {
            generalRoom = true;
        }
    }

}
