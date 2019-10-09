using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jokerpropappear : MonoBehaviour
{
    private GameObject go;
    // Start is called before the first frame update
    void Awake()
    {
        go = GameObject.Find("dialogboxprefab (1)");
    }
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(task);
        
    }

    // Update is called once per frame
    void task()
    {
        GameObject.Find("rewardlevelmanager").GetComponent<rewarslevelmanager>().jokerdialogappear();

            //dialogboxprefab (1)
    }
}
