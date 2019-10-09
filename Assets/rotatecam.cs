using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecam : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    public float speed;
    Vector3 to;
    Vector3 from;
    Vector3 originalposgameobject;
    Vector3 originalorientation;

    //pour le double tap
    int TapCount;
    public float MaxDubbleTapTime;
    float NewTime;

    // Start is called before the first frame update
    void Start()
    {
        to = new Vector3(0,0,0);
        originalposgameobject = transform.GetChild(0).transform.position;
        originalorientation = transform.eulerAngles;

        TapCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).position.y > Screen.height / 3)
        {

            /*
            Touch touch = Input.GetTouch(0);
            mPosDelta = touch.deltaPosition;
            //Debug.Log(mPosDelta);
            transform.Rotate(Vector3.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right) / 2, Space.World);
            */

            Touch touch = Input.GetTouch(0);
            if(touch.phase==TouchPhase.Moved)
            {
                Quaternion rotationy = Quaternion.Euler(0f, -touch.deltaPosition.x * 1f, 0f);
                transform.rotation = rotationy * transform.rotation;
            }



        }
        if(Input.touchCount==2)
        {
            Vector3 pointA = transform.position;
            Vector3 pointB = transform.GetChild(0).transform.position;
            //Vector3 direction = new Vector3(0, pointB.y - pointA.y, pointB.z - pointA.z);
            //Vector3 direction = new Vector3(0, pointB.y - pointB.y, pointB.z-pointA.z);
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            transform.GetChild(0).Translate(new Vector3(0,-0.75f,1) * difference*Vector3.Distance(pointA,Camera.main.transform.position)/100);
        }
        

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                TapCount += 1;
            }

            if (TapCount == 1)
            {

                NewTime = Time.time + MaxDubbleTapTime;
            }
            else if (TapCount == 2 && Time.time <= NewTime)
            {

                //Whatever you want after a dubble tap    
                //print("Dubble tap");
                transform.GetChild(0).transform.position = originalposgameobject;
                transform.eulerAngles = originalorientation;

                TapCount = 0;
            }

        }
        if (Time.time > NewTime)
        {
            TapCount = 0;
        }
    }

}

   

