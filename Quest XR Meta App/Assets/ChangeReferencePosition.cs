using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeReferencePosition : MonoBehaviour
{
    public GameObject gazeObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = gazeObject.transform.position + gazeObject.transform.forward*2f;
    }
}
