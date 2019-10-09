using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jokerconfmanag : MonoBehaviour
{
    public Button btn;
    public GameObject confmessage;
    public Button btnyes;
    public Button btnno;
    public Button enorme;
    
    

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("joker")==false)
        {
            PlayerPrefs.SetInt("joker", 0);
        }
        confmessage.gameObject.SetActive(false);
        btn.onClick.AddListener(task);
        btnyes.onClick.AddListener(taskyes);
        btnno.onClick.AddListener(taskno);
        enorme.onClick.AddListener(enormetask);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void task()
    {
        if(PlayerPrefs.GetInt("argent")>=20)
        {
            confmessage.gameObject.SetActive(true);
            btn.GetComponent<Animator>().Play("pushbtnanim");
            FindObjectOfType<AudioManager>().Play("btnpositif");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("btnnegatif");
            btn.GetComponent<Animator>().Play("btnnegatifjokerrewars");
           
        }
        
        
    }
    private void taskyes()
    {
        FindObjectOfType<AudioManager>().Play("btnpositif");
        PlayerPrefs.SetInt("joker", PlayerPrefs.GetInt("joker") + 1);
        PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") - 20);
        confmessage.SetActive(false);

    }
    private void taskno()
    {
        confmessage.SetActive(false);
    }
    private void enormetask()
    {
        confmessage.SetActive(false);
    }

}
