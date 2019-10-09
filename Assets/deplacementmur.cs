using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementmur : MonoBehaviour
{
    public Joystick joystick;
    public Vector3 originalpos;
    private Vector3 dest;
    public float distance=5;
    public float speed = 40;
    public float maxdist = 4;
    public bool unsensunique;
    private bool alleretour;
    private bool sauterer;
    // Start is called before the first frame update
    void Start()
    {
        originalpos = transform.position;
        //dest = new Vector3(transform.localPosition.x + distance, transform.localPosition.y, transform.localPosition.z);
        dest = Vector3.forward * distance;
        alleretour = true;
    }

    public void sauter()
    {
        Debug.Log("sauter");
       
    }
    

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("theball")!=null)
        {
            if(Vector3.Distance(transform.position,GameObject.Find("theball").transform.position)<maxdist&&Vector3.Distance(transform.position,originalpos)<distance&&alleretour)
            {
                if(unsensunique)
                {
                    if (joystick.Vertical > 0)
                    {
                        Debug.Log("je suis là");
                        //transform.position=Vector3.Lerp(transform.position, dest,Time.deltaTime*speed);
                        transform.Translate(Vector3.forward * Time.deltaTime*speed);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, originalpos, Time.deltaTime * speed);
                    }

                   
                }
                else
                {
                    if (joystick.Vertical > 0)
                    {
                        //transform.position=Vector3.Lerp(transform.position, dest,Time.deltaTime*speed);
                        transform.Translate(Vector3.forward * Time.deltaTime*speed);
                    }
                    else if (joystick.Vertical < 0)
                    {
                        //transform.position = Vector3.Lerp(transform.position, originalpos, Time.deltaTime * speed);
                        transform.Translate(Vector3.back * Time.deltaTime*speed);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, originalpos, Time.deltaTime * speed);
                    }
                }
                
            }
            else
            {
                alleretour = false;
                transform.position = Vector3.Lerp(transform.position, originalpos, Time.deltaTime * speed);
            }

        }
        

        if (Vector3.Distance(originalpos,transform.position)<0.1f)
        {
            alleretour = true;
            Debug.Log("je redeviens true");
        }
        //Debug.Log("alleretour : "+alleretour);
    }
}
