using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockyrot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation= Quaternion.Euler(transform.rotation.x, 0.0f, transform.rotation.z);
    }
}
