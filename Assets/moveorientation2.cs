using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveorientation2 : MonoBehaviour
{
    Vector3 direction;
    public Joystick joystick;
    public float maxdistance;
    

    // Update is called once per frame
    void Update()
    {
        /*
        direction = Camera.main.transform.position - transform.position;
        transform.RotateAround(transform.position, direction, 50*Time.deltaTime);
        */
        //transform.LookAt(new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z));

        //Quaternion rot2 = new Quaternion(joystick.Vertical * 45 + 0.1f, GameObject.Find("pointcam").transform.eulerAngles.y, -joystick.Horizontal * 45 - 0.1f,3*Time.deltaTime);

        //transform.eulerAngles = new Vector3(joystick.Vertical * 45+0.1f, GameObject.Find("pointcam").transform.eulerAngles.y, -joystick.Horizontal * 45 - 0.1f);

        //transform.eulerAngles = Quaternion.Lerp(transform.rotation, rot2, Time.deltaTime * 9);


        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, 9 * Time.deltaTime);
        if(SceneManager.GetActiveScene().name == "didacticiel")
        {
            Quaternion rotation2 = Quaternion.Euler(joystick.Vertical * 45 + 0.1f, 0, -joystick.Horizontal * 45 - 0.1f);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, 9 * Time.deltaTime);
        }
        else
        {
            if (GameObject.Find("theball"))
            {


                if (Vector3.Distance(GameObject.Find("theball").transform.position, transform.position) < maxdistance)
                {
                    Quaternion rotation2 = Quaternion.Euler(joystick.Vertical * 45 + 0.1f, GameObject.Find("pointcam").transform.eulerAngles.y, -joystick.Horizontal * 45 - 0.1f);

                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, 9 * Time.deltaTime);
                }
                else
                {
                    Quaternion rotation2 = Quaternion.Euler(0.1f, GameObject.Find("pointcam").transform.eulerAngles.y, -0.1f);

                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, 9 * Time.deltaTime);
                }
            }
        }
        
    }
}
