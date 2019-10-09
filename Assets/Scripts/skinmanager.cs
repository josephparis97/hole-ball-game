using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skinmanager : MonoBehaviour
{
    public Button btn;
    public Button choisir;
    public Text txt;
    private GameObject[] skins;
    public GameObject dialogbox;
    public Button yes;
    public Button no;
    public Button enorme;
    
    // Start is called before the first frame update
    void Start()
    {
        
        dialogbox.gameObject.SetActive(false);
        if (PlayerPrefs.HasKey("skin1") == false) //à changer en false
        {

            PlayerPrefs.SetInt("skin1", 0);
            PlayerPrefs.SetInt("skin2", 10);
            PlayerPrefs.SetInt("skin3", 20);
            PlayerPrefs.SetInt("skin4", 30);
            PlayerPrefs.SetInt("skin5", 40);
            PlayerPrefs.SetInt("skin6", 50);
            PlayerPrefs.SetInt("skin7", 60);
            PlayerPrefs.SetInt("skin8", 70);
            PlayerPrefs.SetInt("skin9", 80);
            PlayerPrefs.SetInt("skin10", 90);
            PlayerPrefs.SetInt("skin11", 100);

            PlayerPrefs.SetInt("skin", 1);
        }

        transform.Rotate(0, 15 * PlayerPrefs.GetInt("skin"), 0, Space.Self);

        btn.onClick.AddListener(task);
        choisir.onClick.AddListener(task2);

        skins = GameObject.FindGameObjectsWithTag("skin");
        foreach (GameObject go in skins)
        {
            //1
            //Debug.Log(Mathf.RoundToInt(go.transform.parent.eulerAngles.y));
            if (go.transform.parent.name== "skinpoint1")
            {

                if (PlayerPrefs.GetInt("skin1") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            //2
            if (go.transform.parent.name == "skinpoint2")
            {

                if (PlayerPrefs.GetInt("skin2") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            //3
            if (go.transform.parent.name == "skinpoint3")
            {

                if (PlayerPrefs.GetInt("skin3") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            //4
            if (go.transform.parent.name == "skinpoint4")
            {

                if (PlayerPrefs.GetInt("skin4") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            //5
            if (go.transform.parent.name == "skinpoint5")
            {

                if (PlayerPrefs.GetInt("skin5") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            //6
            if (go.transform.parent.name == "skinpoint6")
            {

                if (PlayerPrefs.GetInt("skin6") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            //7
            if (go.transform.parent.name == "skinpoint7")
            {

                if (PlayerPrefs.GetInt("skin7") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            //8
            if (go.transform.parent.name == "skinpoint8")
            {

                if (PlayerPrefs.GetInt("skin8") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            if (go.transform.parent.name == "skinpoint9")
            {

                if (PlayerPrefs.GetInt("skin9") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            if (go.transform.parent.name == "skinpoint10")
            {

                if (PlayerPrefs.GetInt("skin10") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            if (go.transform.parent.name == "skinpoint11")
            {

                if (PlayerPrefs.GetInt("skin11") == 0)
                {
                    go.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        //transform.Rotate(0, 15 * PlayerPrefs.GetInt("skin"), 0, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.RoundToInt(transform.eulerAngles.y % 15));
        //HideIfClickedOutside(bluepanel);
        if (Mathf.RoundToInt(transform.eulerAngles.y % 15) == 0 || Mathf.RoundToInt(transform.eulerAngles.y % 15) == 15)
        {
            string skine = "skin" + Mathf.RoundToInt(transform.eulerAngles.y) / 15;
            btn.enabled = true;
            choisir.enabled = true;
            if (PlayerPrefs.GetInt(skine) == 0)
            {
                btn.gameObject.SetActive(false);
                choisir.gameObject.SetActive(true);

            }
            else
            {
                btn.gameObject.SetActive(true);
                choisir.gameObject.SetActive(false);
                txt.text = "" + PlayerPrefs.GetInt(skine);
            }


        }
        else
        {
            btn.enabled = false;
            choisir.enabled = false;
        }
    }

    public void task()
    {
        //Debug.Log("salut salut");
        //Debug.Log("parse" + int.Parse(txt.text));
        //Debug.Log("argent : " + PlayerPrefs.GetInt("argent"));
        if (int.Parse(txt.text) <= PlayerPrefs.GetInt("argent"))
        {
            dialogbox.gameObject.SetActive(true);
            yes.onClick.AddListener(taskyes);
            no.onClick.AddListener(taskno);
            //j'en étais là...
            enorme.onClick.AddListener(taskno);

        }

    }

    public void task2()
    {
        PlayerPrefs.SetInt("skin", Mathf.RoundToInt(transform.eulerAngles.y) / 15);
        Debug.Log("skin" + PlayerPrefs.GetInt("skin"));
    }

    public void taskyes()
    {
        string skin = "skin" + Mathf.RoundToInt(transform.eulerAngles.y) / 15;
        dialogbox.gameObject.SetActive(false);
        PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") - PlayerPrefs.GetInt(skin));
        PlayerPrefs.SetInt(skin, 0);
        PlayerPrefs.SetInt("skin", Mathf.RoundToInt(transform.eulerAngles.y) / 15);

        foreach (GameObject skn in skins)
        {
            //Debug.Log("nom du parent : " + skn.transform.parent.name);
            //Debug.Log("l'angle actuel : "+Mathf.RoundToInt(transform.eulerAngles.y));
            //Debug.Log("l'angle de la boule" + Mathf.RoundToInt(skn.transform.parent.eulerAngles.y));
            //Debug.Log("...");
            if(Mathf.RoundToInt(skn.transform.parent.eulerAngles.y)==360|| Mathf.RoundToInt(skn.transform.parent.eulerAngles.y) == 0)
            {
                skn.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    public void taskno()
    {
        dialogbox.gameObject.SetActive(false);
    }

    private void HideIfClickedOutside(GameObject panel)
    {
        if (Input.GetMouseButton(0) && panel.activeSelf &&
            RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main))
        {
            panel.SetActive(false);
        }
    }

}
