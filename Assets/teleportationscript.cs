using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportationscript : MonoBehaviour
{

    
    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.name=="theball")
        {
            GameObject.Find("theball").transform.position = destination.transform.position;
        }
    }
}
