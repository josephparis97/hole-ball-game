using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecylinder : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    Vector3 ori;
    Vector3 to;
    Vector3 oriplanche;
    Vector3 orirot;
    Vector3 oriball;
    public float deplacement = 2;
    public float distancemax = 4;

    // Start is called before the first frame update
    void Start()
    {
        ori = transform.position;
        if(GameObject.Find("grosseplaque")!=null)
        {
            oriplanche = GameObject.Find("grosseplaque").transform.position;
            orirot = GameObject.Find("grosseplaque").transform.eulerAngles;
        }
        
        oriball = GameObject.Find("theball").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("theball")!=null)
        {
            if(Vector3.Distance(GameObject.Find("theball").transform.position,transform.position)<distancemax)
            {
                to = transform.position + new Vector3(joystick.Horizontal * deplacement, 0, 0);
                // transform.Rotate(0, joystick.Horizontal,0 , Space.Self);
                transform.position = Vector3.Lerp(ori, to, Time.deltaTime * 3);
            }
            else
            {
                if(Vector3.Distance(transform.position,ori)>1)
                {
                    transform.position = Vector3.Lerp(transform.position, ori, Time.deltaTime * 3);
                }
                
            }
        }

        if (GameObject.Find("grosseplaque") != null)
            {
            if (Vector3.Distance(GameObject.Find("grosseplaque").transform.position, oriplanche) > 5 || Vector3.Distance(GameObject.Find("theball").transform.position, GameObject.Find("grosseplaque").transform.position) > 10)
            {
                GameObject.Find("grosseplaque").transform.position = oriplanche;
                GameObject.Find("grosseplaque").transform.eulerAngles = orirot;
                GameObject.Find("grosseplaque").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                GameObject.Find("grosseplaque").GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            }
        } 


    }
}
