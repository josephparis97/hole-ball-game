using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvementup : MonoBehaviour
{
    Vector3 from;
    Vector3 to;
    Vector3 ori;
    Vector3 oriball;
    public Joystick joystick;
    public float speed;
    public float maxdistance = 5;
    // Start is called before the first frame update
    void Start()
    {
        ori = transform.position;
        oriball = GameObject.Find("theball").transform.position;

        
            GameObject.Find("theball").GetComponent<sphere>().restartevent.AddListener(restart);
        
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(GameObject.Find("theball")!=null)
        {
            if (Vector3.Distance(GameObject.Find("theball").transform.position, transform.position) < maxdistance)
            {
                //Debug.Log("distance" + Vector3.Distance(GameObject.Find("theball").transform.position, transform.position));
                from = transform.position;
                to = transform.position + new Vector3(0, joystick.Vertical, 0);
                transform.position = Vector3.Lerp(from, to, Time.deltaTime * speed);
            }
            else if (Vector3.Distance(ori, transform.position) > 8)
            {
                transform.position = ori;
            }
            else if(Vector3.Distance(GameObject.Find("theball").transform.position, transform.position) > maxdistance)
            {
                transform.position = Vector3.Lerp(transform.position, ori, Time.deltaTime * speed);
                //transform.position = ori;
            }
        }
    }
    public void restart()
    {
        transform.position = ori;
    }
}
