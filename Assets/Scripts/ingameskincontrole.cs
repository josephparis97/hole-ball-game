using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameskincontrole : MonoBehaviour
{
    public Material[] mat = new Material[8];
    private GameObject[] ball;
        // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("skin") == false)
        {
            PlayerPrefs.SetInt("skin", 1);
        }
        ball =GameObject.FindGameObjectsWithTag("Player");

        ball[0].GetComponent<Renderer>().material = mat[PlayerPrefs.GetInt("skin") - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
