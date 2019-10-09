using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation2 : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 40;
    private Vector3 originalrot;
    public float distance = 4;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("theball").GetComponent<sphere>().restartevent.AddListener(restartviolet);
        originalrot = transform.eulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.Find("theball") != null)
            if (Vector3.Distance(GameObject.Find("theball").transform.position, transform.position) < distance)
                transform.Rotate(0, -joystick.Horizontal * Time.deltaTime * speed, 0, Space.Self);
    }

    public void restartviolet()
    {
        transform.eulerAngles = originalrot;
    }


}
