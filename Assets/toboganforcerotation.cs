using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toboganforcerotation : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    // Start is called before the first frame update
    private Vector3 originrot;
    private Quaternion originrot2;

    
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originrot = transform.eulerAngles;
        originrot2 = transform.rotation;
        GameObject.Find("theball").GetComponent<sphere>().restartevent.AddListener(resettob);
    }
    // Update is called once per frame
    
    void Update()
    {
        //float turn = Input.GetAxis("Horizontal");
        //rb.AddTorque(transform.up * joystick.Horizontal * turn*100);
        //rb.AddTorque(11, 0, 0, ForceMode.Force);
        if (GameObject.Find("theball") != null)
            if (Vector3.Distance(GameObject.Find("theball").transform.position, transform.position) < 4)
                transform.Rotate(0, joystick.Horizontal * Time.deltaTime * speed, 0, Space.World);
            else
            {
                Debug.Log("hey !!!!");
                transform.rotation=Quaternion.Lerp(transform.rotation, originrot2,Time.deltaTime*4);
            }        

        if (GameObject.Find("metal") != null)
            if (Vector3.Distance(GameObject.Find("metal").transform.position, transform.position) < 4)
                transform.Rotate(0, joystick.Horizontal * Time.deltaTime * speed, 0, Space.World);

    }

    public void resettob()
    {
        transform.eulerAngles = originrot;
    }
}
