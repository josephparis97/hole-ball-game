using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rewarslevelmanager : MonoBehaviour
{
    private GameObject[] cards;
    public GameObject dialogbox;
    public Button yes;
    public Button no;
    public Button enorme;
    private int nextlevel;
    private int nextlevelconfirmed;
    public Canvas jokerprop;




    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("level") == false) { PlayerPrefs.SetInt("level", 1); }
        no.onClick.AddListener(noclick);
        enorme.onClick.AddListener(enormeclick);
        int i = 0;
        cards = GameObject.FindGameObjectsWithTag("cardlevel");
        foreach (GameObject card in cards)
        {

            if (PlayerPrefs.GetInt("level") < int.Parse(card.name))
            {
                //Debug.Log("level :" + PlayerPrefs.GetInt("level"));
                card.GetComponent<Button>().interactable = false;
                card.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(100, 255, 255, 100);
                card.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(133, 133, 133, 133);
            }

            if(PlayerPrefs.GetInt("level")!= int.Parse(card.name)&& PlayerPrefs.GetInt("level") !=100)
            {
                card.transform.GetChild(6).gameObject.SetActive(false);
            }


           

            //card.GetComponent<Button>().onClick.AddListener(task(str));

            //test 2 lignes en dessous
            card.GetComponent<Button>().onClick.AddListener(delegate {task(card.name); });
            card.transform.GetChild(2).GetComponent<Text>().text=card.name;

            

            int sous = int.Parse(card.name) - 1;
            //Debug.Log("pierre1" + sous+" : "+ PlayerPrefs.GetInt("pierre1" + sous));
            int sum = PlayerPrefs.GetInt("pierre1" + sous)+ PlayerPrefs.GetInt("pierre2" + sous)+ PlayerPrefs.GetInt("pierre3" + sous);
            if (sum==2)
            {
                card.transform.GetChild(5).gameObject.SetActive(false);
            }
            if (sum == 1)
            {
                card.transform.GetChild(4).gameObject.SetActive(false);
                card.transform.GetChild(5).gameObject.SetActive(false);
            }
            if (sum==0)
            {
                card.transform.GetChild(3).gameObject.SetActive(false);
                card.transform.GetChild(4).gameObject.SetActive(false);
                card.transform.GetChild(5).gameObject.SetActive(false);
            }

           
        }
        
           
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void task(string name)
    {

        dialogbox.gameObject.SetActive(true);
        yes.onClick.AddListener(delegate { task2(name); });
    }

    public void task2(string name)
    {
        if(name=="1")
        {
            PlayerPrefs.SetString("jeviensdesrewards", "oui");
        }
        SceneManager.LoadScene("level" + name);
    }
    public void noclick()
    {
        dialogbox.SetActive(false);

    }
    public void enormeclick()
    {
        dialogbox.SetActive(false);
    }

    public void joker()
    {
        jokerprop.gameObject.SetActive(true);
    }

    public void jokerdialogappear()
    {
        jokerprop.gameObject.SetActive(true);
    }
}
