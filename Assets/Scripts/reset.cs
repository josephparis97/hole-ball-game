using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class reset : MonoBehaviour
{

    public Button btn;
    public GameObject ball;
    private Vector3 origin;
    private Vector3 orimetal;
    private Vector3 originmoulinviolet;
    // Start is called before the first frame update
    void Start()
    {
        origin = ball.transform.position;
        if (GameObject.Find("metal") != null)
            orimetal = GameObject.Find("metal").transform.position;
        if(GameObject.Find("moulinviolet")!=null)
        {
            originmoulinviolet = GameObject.Find("moulinviolet").gameObject.transform.eulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        ball.transform.position = origin;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        if (GameObject.Find("metal") != null)
            GameObject.Find("metal").transform.position = orimetal;

        if(GameObject.Find("moulinviolet") != null){
            GameObject.Find("moulinviolet").gameObject.transform.eulerAngles = originmoulinviolet;
        }
        GameObject.Find("theball").GetComponent<sphere>().restartevent.Invoke();
    }
}
