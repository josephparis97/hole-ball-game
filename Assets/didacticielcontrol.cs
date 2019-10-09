using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class didacticielcontrol : MonoBehaviour
{
    public GameObject plateforme;
    public Button zeparti;
    public Canvas end;
    public Canvas actuel;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        zeparti.onClick.AddListener(task);
    }

    // Update is called once per frame
    void Update()
    {

        if(joystick.Horizontal>0.5f)
        {
            StartCoroutine(task2());
        }
        /*
        if (plateforme.transform.eulerAngles.magnitude > 0)
        {
            StartCoroutine(task2());
            
        }
        */
    }

    public void task()
    {
        PlayerPrefs.SetString("didacticiel", "done");
        SceneManager.LoadScene("level1");
    }
    IEnumerator task2()
    {
        yield return new WaitForSeconds(3f);
        actuel.gameObject.SetActive(false);
        end.gameObject.SetActive(true);
        plateforme.gameObject.SetActive(false);
        Debug.Log("Bravo, vous avez réussi à faire bouger la plateforme !");
    }
}
