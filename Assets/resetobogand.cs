using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetobogand : MonoBehaviour
{
    public Button btn;
    public GameObject tobogand;
    public Vector3 ori;
    private Vector3 origin;
    
    Vector3 posori;
    // Start is called before the first frame update
    void Start()
    {
        origin = GameObject.Find("theball").transform.position;
        
        
        btn.onClick.AddListener(task);
        if(tobogand!=null)
        {
            ori = tobogand.transform.eulerAngles;
            posori = tobogand.transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length>0)
        {
            if (GameObject.Find("theball").transform.position.y < origin.y - 9 && tobogand !=null)
            {
                tobogand.transform.eulerAngles = ori;
                
            }
        }
        
    }
    public void task()
    {
        tobogand.transform.eulerAngles = ori;
        tobogand.transform.position = posori;
        
    }
}
