using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetmetal : MonoBehaviour
{
    private Vector3 oripos;
    private Vector3 oritobori;
    // Start is called before the first frame update
    void Start()
    {
        oripos = transform.position;
        oritobori = GameObject.Find("tobogan7 Variant").transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, oripos) > 12)
        {
            transform.position = oripos;
            GameObject.Find("tobogan7 Variant").transform.eulerAngles = oritobori;
        }
            
    }
}
