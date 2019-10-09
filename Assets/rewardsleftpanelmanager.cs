using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewardsleftpanelmanager : MonoBehaviour
{

    public GameObject scroll;
    public Button up;
    public Button down;

    public Button tro1;
    public Button tro2;
    public Button tro3;
    public Button tro4;
    public Button tro5;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("level")==100)
        {
            GameObject.Find("trophe5").GetComponent<Image>().color = new Color32(255, 255, 255,255);
            GameObject.Find("trophe4").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("trophe3").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("trophe2").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("trophe1").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if(PlayerPrefs.GetInt("level") >= 75&& PlayerPrefs.GetInt("level") < 100)
        {
            GameObject.Find("trophe4").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("trophe3").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("trophe2").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("trophe1").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (PlayerPrefs.GetInt("level") >= 50 && PlayerPrefs.GetInt("level") < 75)
        {
            GameObject.Find("trophe3").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("trophe2").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("trophe1").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (PlayerPrefs.GetInt("level") >= 25 && PlayerPrefs.GetInt("level") < 50)
        {
            GameObject.Find("trophe2").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("trophe1").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (PlayerPrefs.GetInt("level") >= 10 && PlayerPrefs.GetInt("level") < 25)
        {
            GameObject.Find("trophe1").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }


        up.onClick.AddListener(task1);
        down.onClick.AddListener(task2);
        tro1.onClick.AddListener(tro1task);
        tro2.onClick.AddListener(tro2task);
        tro3.onClick.AddListener(tro3task);
        tro4.onClick.AddListener(tro4task);
        tro5.onClick.AddListener(tro5task);
        scroll.transform.localPosition=new Vector3(0, 20493.25f-420*(PlayerPrefs.GetInt("level")-1), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void task1()
    {
       if(scroll.transform.localPosition == new Vector3(0, 20493.25f - 420 * (PlayerPrefs.GetInt("level") - 1), 0))
        {
            scroll.transform.localPosition = new Vector3(0, 20493.25f - 420 * (98), 0);
        }
       else if(scroll.transform.localPosition.y > 20493.25f - 420 * (PlayerPrefs.GetInt("level") - 1))
       {
            scroll.transform.localPosition = new Vector3(0, 20493.25f - 420 * (PlayerPrefs.GetInt("level") - 1), 0);
        }
        
    }

    public void task2()
    {
        if (scroll.transform.localPosition == new Vector3(0, 20493.25f - 420 * (PlayerPrefs.GetInt("level") - 1), 0))
        {
            scroll.transform.localPosition = new Vector3(0, 20493.25f, 0);
        }
        else if(scroll.transform.localPosition.y < 20493.25f - 420 * (PlayerPrefs.GetInt("level") - 1))
        {
            scroll.transform.localPosition = new Vector3(0, 20493.25f - 420 * (PlayerPrefs.GetInt("level") - 1), 0);
        }
    }

    public void tro1task()
    {
        scroll.transform.localPosition = new Vector3(0, 20493.25f - 420 * (9), 0);
    }

    public void tro2task()
    {
        scroll.transform.localPosition = new Vector3(0, 20493.25f - 420 * (24), 0);
    }

    public void tro3task()
    {
        scroll.transform.localPosition = new Vector3(0, 20493.25f - 420 * (49), 0);
    }

    public void tro4task()
    {
        scroll.transform.localPosition = new Vector3(0, 20493.25f - 420 * (74), 0);
    }

    public void tro5task()
    {
        scroll.transform.localPosition = new Vector3(0, 20493.25f - 420 * (98), 0);
    }


}
