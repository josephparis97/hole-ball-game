using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toboganrosegyro : MonoBehaviour
{
    Gyroscope mongyro;
    private Vector3 orifinrot;
    public float maxdist = 4;
    // Start is called before the first frame update
    void Start()
    {
        mongyro = Input.gyro;
        orifinrot = transform.eulerAngles;
        //GameObject.Find("theball").GetComponent<sphere>().restartevent.AddListener(task);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.Find("theball").transform.position) < maxdist)
        {
            Quaternion rotation2 = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, orifinrot.z - mongyro.attitude.eulerAngles.x);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, 9 * Time.deltaTime);
        }
        else
        {
            Quaternion rotation2 = Quaternion.Euler(orifinrot.x, orifinrot.y, orifinrot.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, 9 * Time.deltaTime);
        }
        
    }

    public void task()
    {
        transform.eulerAngles = orifinrot;
        Debug.Log("bonjour");
    }
}
