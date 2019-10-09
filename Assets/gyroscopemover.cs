using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gyroscopemover : MonoBehaviour
{
    Gyroscope m_Gyro;
    public float ampli = 10;
    private Quaternion origin;
    public float maxdist = 4;
    // Start is called before the first frame update
    void Start()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
        origin = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(m_Gyro.attitude.eulerAngles);
        m_Gyro = Input.gyro;
        if (Vector3.Distance(transform.position,GameObject.Find("theball").transform.position)<maxdist)
        {
            Quaternion rotation2 = Quaternion.Euler(-m_Gyro.attitude.eulerAngles.x, GameObject.Find("pointcam").transform.eulerAngles.y, -m_Gyro.attitude.eulerAngles.y);
            //Quaternion rotation2 = Quaternion.Euler(m_Gyro.attitude.eulerAngles.x, m_Gyro.attitude.eulerAngles.y, m_Gyro.attitude.eulerAngles.z);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, 9 * Time.deltaTime);
            //transform.Rotate(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
        }
        else
        {
            origin = Quaternion.Euler(origin.x, GameObject.Find("pointcam").transform.eulerAngles.y, origin.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, origin, 9 * Time.deltaTime);
        }

    }  
}
