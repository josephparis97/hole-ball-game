using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveorientation : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    Vector3 originalPos;
    Vector3 originalrotation;
    public float maxdistance = 4;
    

    public void Start()
    {
         originalPos= gameObject.transform.position;
        originalrotation = transform.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("distance : " + Vector3.Distance(GameObject.Find("theball").transform.position, transform.position));
       if(GameObject.Find("theball")!=null)
        {
            if (Vector3.Distance(GameObject.Find("theball").transform.position, transform.position) < maxdistance)
            {
                Quaternion rotation2 = Quaternion.Euler(originalrotation.x+joystick.Vertical * 45 + 0.1f, originalrotation.y, originalrotation.z - joystick.Horizontal * 45 - 0.1f);
                
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, speed * Time.deltaTime);
            }
            else
            {

                Quaternion rotation2 = Quaternion.Euler(originalrotation.x, originalrotation.y, originalrotation.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, speed * Time.deltaTime);
            }
        }
        
        else
        {
            
            Quaternion rotation2 = Quaternion.Euler(originalrotation.x, originalrotation.y, originalrotation.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, speed * Time.deltaTime);
        }
            
        
         
    }
    
}
