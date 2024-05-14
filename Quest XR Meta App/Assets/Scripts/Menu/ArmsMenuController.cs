using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponBlaster;
    [SerializeField]
    private GameObject weaponLauncher;

    [SerializeField]
    private GameObject menuItem1;
    [SerializeField]
    private GameObject menuItem2;
    [SerializeField]
    private GameObject menuItem3;


    public void MoveOnHover()
    {
        Debug.Log("MoveOnHover function was accessed");
        Vector3 driftVec = new (-0.1f, 0.1f, 0.0f);
        gameObject.transform.localPosition = gameObject.transform.localPosition + driftVec;
    }

    public void SetActiveMenuItems()
    {
        menuItem1.SetActive(true);
        menuItem2.SetActive(true);
        menuItem3.SetActive(true);
    }

    public void SetInactiveMenuItems()
    {
        menuItem1.SetActive(false);
        menuItem2.SetActive(false);
        menuItem3.SetActive(false);
    }

    

}
