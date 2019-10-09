using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class adcontroller : MonoBehaviour
{
    string gameId = "3235396";
    bool testMode = false;

    private string video_ad="video";
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Sphere (1)").GetComponent<wintrigger>().winning.AddListener(showad);
        Advertisement.Initialize(gameId, testMode);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void showad()
    {
        
        Debug.Log("SHOW");
        
        Advertisement.Show();
        if (Advertisement.IsReady(video_ad))
        {

            Advertisement.Show();
        }
    }
}
