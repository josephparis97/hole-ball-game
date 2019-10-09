using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rouedelafortune : MonoBehaviour
{
    public float amount = 50f;
    public Rigidbody2D rigidbody;
    public Button btn;
    private float rand=0;
    private float ero;
    private float attendrre;
    private int angle;
    private bool isturning;
    private float deltav;
    private float last;
    private int lastime;
    private int deltat;
    private DateTime now;
    public Text txt;
    public GameObject cristalobj;



    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(task);
        isturning = false;
        if(PlayerPrefs.HasKey("essai")==false)
        {
            PlayerPrefs.SetInt("essai",3);
            btn.enabled = true;
        }
        else if(PlayerPrefs.GetInt("essai")==0)
        {
            btn.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        deltav = GetComponent<Rigidbody2D>().angularVelocity - last;
        last = GetComponent<Rigidbody2D>().angularVelocity;

        //Debug.Log(isturning);
        //Debug.Log(deltav);
        //Debug.Log(GetComponent<Rigidbody2D > ().angularVelocity);
        angle= Mathf.Abs(Mathf.RoundToInt(transform.eulerAngles.z) % 60);
        //btn.onClick.AddListener(task);
        if (isturning == true && GetComponent<Rigidbody2D>().angularVelocity <1)
        {

            //Debug.Log("OUI vous avez gagné !!!!!");
            //PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") + 10);
            isturning = false;
            //btn.enabled = true;
            if ((transform.eulerAngles.z>30&& transform.eulerAngles.z<90)|| (transform.eulerAngles.z<-270&& transform.eulerAngles.z>-230))
            {
                if(PlayerPrefs.GetInt("argent")>=20)
                {
                    PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") - 20);
                    //Debug.Log("vous avez perdu 20");
                    GameObject.Find("roue animations").GetComponent<Animator>().Play("cristaux perdus");
                }
                else
                {
                    PlayerPrefs.SetInt("argent", 0);
                }  
            }
            else if((transform.eulerAngles.z>90&& transform.eulerAngles.z<150)||(transform.eulerAngles.z<-270&& transform.eulerAngles.z>-270))
            {
                //PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") + 20);

                //Debug.Log("vous avez gagné 10 !!!");
                GameObject.Find("roue animations").GetComponent<Animator>().Play("cristalgagne1");
                StartCoroutine(cristalmove());
            }
            else if((transform.eulerAngles.z>150&& transform.eulerAngles.z<210)||(transform.eulerAngles.z<-150&& transform.eulerAngles.z>-210))
            {
                if (PlayerPrefs.GetInt("argent") >= 20)
                {
                    PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") - 20);
                    Debug.Log("vous avez perdu 20");
                    GameObject.Find("roue animations").GetComponent<Animator>().Play("cristaux perdus");
                }
                else
                {
                    PlayerPrefs.SetInt("argent", 0);
                }

            }
            else if((transform.eulerAngles.z>210&& transform.eulerAngles.z<270)||(transform.eulerAngles.z<-90)&& transform.eulerAngles.z>-150)
            {
                PlayerPrefs.SetInt("joker", PlayerPrefs.GetInt("joker") + 1);
                //Debug.Log("vous avez gagné 1 joker!!!!");
                GameObject.Find("roue animations").GetComponent<Animator>().Play("jokerbonus");
                
            }
            else if((transform.eulerAngles.z>270&& transform.eulerAngles.z<330)|| transform.eulerAngles.z<-30&& transform.eulerAngles.z>-90)
            {

                //PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") + 20);

                //Debug.Log("vous avez gagné 10 !!!");
                GameObject.Find("roue animations").GetComponent<Animator>().Play("cristalgagne1");
                StartCoroutine(cristalmove());

            }
            else if((transform.eulerAngles.z>330 && transform.eulerAngles.z<390)||(transform.eulerAngles.z>-30&& transform.eulerAngles.z<30))
            {
                //PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") + 20);

                //Debug.Log("vous avez gagné 10 !!!");
                GameObject.Find("roue animations").GetComponent<Animator>().Play("cristalgagne1");
                StartCoroutine(cristalmove());
            }
        }
        else if (angle < 30)
        {
            //Debug.Log("angle :"+angle);
            rigidbody.AddTorque(-angle / 20);
            //Debug.Log("<<<<< à 30" + -angle / 20);
        }
        else if (angle > 30)
        {
            //Debug.Log("angle :" + angle);
            rigidbody.AddTorque((60 - angle) / 20);
            //Debug.Log(">>>>> à 30" + (60 - angle) / 20);
        }
        else if (GetComponent<Rigidbody2D>().angularVelocity > 0)
        {
            isturning = true;
        }
        /*
        else if(GetComponent<Rigidbody2D>().angularVelocity < 1)
        {
            isturning = false;
        }
        */
        if(GetComponent<Rigidbody2D>().angularVelocity==0&&PlayerPrefs.GetInt("essai")>0&&isturning==false)
        {
            btn.enabled = true;
        }
        else if(GetComponent<Rigidbody2D>().angularVelocity > 0)
        {
            btn.enabled = false;
        }
        now = System.DateTime.Now;
        
        if(PlayerPrefs.HasKey("lastime"))
        {
            deltat = convertDateTimeToSeconds(now) - PlayerPrefs.GetInt("lastime");
            //Debug.Log(deltat / 60);
            if(deltat/60>=3)
            {
                PlayerPrefs.SetInt("essai", 3);
                //GameObject.Find("roue animations").transform.GetChild(6).gameObject.SetActive(false);
                GameObject[] cartes = GameObject.FindGameObjectsWithTag("carte");

                foreach (GameObject carte in cartes)
                {
                    carte.gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                }
            }
            
            if(PlayerPrefs.GetInt("essai")>0)
            {
                txt.text = "Essais restants : " + PlayerPrefs.GetInt("essai");
            }
            else
            {
                int nbsecquireste = 180 - deltat;
                txt.text = (Mathf.RoundToInt(nbsecquireste/60))+" mn "+ (nbsecquireste%60)+" s";
            }
            
            
        }

        if(PlayerPrefs.GetInt("essai")==0)
        {
            StartCoroutine(task2());
            
            
            //transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color= new Color32(255, 255, 255, 50);
            //new Color32(133, 133, 133, 133);
        }


    }


    public static int convertDateTimeToSeconds(DateTime dateTimeToConvert)
    {
        int secsInAMin = 60;
        int secsInAnHour = 60 * secsInAMin;
        int secsInADay = 24 * secsInAnHour;
        double secsInAYear = (int)365.25 * secsInADay;

        int totalSeconds = (int)(dateTimeToConvert.Year * secsInAYear) +
                       (dateTimeToConvert.DayOfYear * secsInADay) +
                       (dateTimeToConvert.Hour * secsInAnHour) +
                       (dateTimeToConvert.Minute * secsInAMin) +
                       dateTimeToConvert.Second;

        return totalSeconds;
    }

    public void task()
    {
        // Debug.Log("salut c'est moi");
        btn.enabled = false;
        PlayerPrefs.SetInt("lastime", convertDateTimeToSeconds(System.DateTime.Now));
        if(PlayerPrefs.HasKey("essai"))
            if(PlayerPrefs.GetInt("essai")>0)
                PlayerPrefs.SetInt("essai", PlayerPrefs.GetInt("essai") - 1);


        rand = UnityEngine.Random.Range(10f, 1000000f);
        Debug.Log(rand);
        GetComponent<Rigidbody2D>().angularDrag= UnityEngine.Random.Range(0.5f, 5f);
        rigidbody.AddTorque(rand);
        
        Debug.Log(System.DateTime.Now);
        

    }

    IEnumerator task2()
    {
        yield return new WaitForSeconds(1f);
        if (GetComponent<Rigidbody2D>().angularVelocity == 0)
        {
            GameObject[] cartes = GameObject.FindGameObjectsWithTag("carte");

            foreach (GameObject carte in cartes)
            {
                carte.gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, 100);
            }
        }
    }

    IEnumerator cristalmove()
    {

        for(int i=0; i<20; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(cristalobj, GameObject.Find("pointA").transform);
            //Debug.Log("cristal pose");
        }
    }

}
