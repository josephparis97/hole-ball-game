using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skinrotate : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    public float speed;
    
    //public Button btn;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.touchCount > 0 && Input.GetTouch(0).position.y > Screen.height / 2)
        {
            Touch touch = Input.GetTouch(0);
            mPosDelta = touch.deltaPosition;
            //Debug.Log(mPosDelta);
            transform.Rotate(Vector3.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right) / 20, Space.World);

        }

        //Debug.Log(Mathf.RoundToInt(transform.rotation.y) % 15);

        //Debug.Log(transform.rotation.y);
        else
        {


            //Debug.Log(Mathf.RoundToInt(transform.eulerAngles.y) % 15);
            if (Mathf.RoundToInt(transform.eulerAngles.y) % 15 < 7.5)
            {
                Vector3 to = new Vector3(0, transform.eulerAngles.y - Mathf.RoundToInt(transform.eulerAngles.y) % 15, 0);
                if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
                {
                    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime*speed);
                }
                else
                {
                    transform.eulerAngles = to;

                }
            }
            else
            {
                Vector3 to = new Vector3(0, transform.eulerAngles.y - Mathf.RoundToInt(transform.eulerAngles.y) % 15 + 15, 0);
                if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
                {
                    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime*speed);
                }
                else
                {
                    transform.eulerAngles = to;

                }
            }

        }

        
    }
   
}
