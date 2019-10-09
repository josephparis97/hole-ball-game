using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvevertorienttobogand : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    Vector3 originalPos;
    Vector3 originalrotation;


    public void Start()
    {
        originalPos = gameObject.transform.position;
        originalrotation = transform.eulerAngles;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("distance : " + Vector3.Distance(GameObject.Find("theball").transform.position, transform.position));
        if (GameObject.Find("theball") != null)
        {
            if (Vector3.Distance(GameObject.Find("theball").transform.position, transform.position) < 5)
            {
                Quaternion rotation2 = Quaternion.Euler(originalrotation.x, originalrotation.y, originalrotation.z + joystick.Vertical * 45 - 0.1f);
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
