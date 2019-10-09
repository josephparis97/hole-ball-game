using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class jokerproprewards : MonoBehaviour
{
    public Canvas jokerprop;
    public Animator animatorobject;
    //private GameObject[] cards;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(task);
        //cards = GameObject.FindGameObjectsWithTag("cardlevel");
    }

    // Update is called once per frame
    void task()
    {
        if(PlayerPrefs.GetInt("joker")>0)
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            PlayerPrefs.SetInt("joker", PlayerPrefs.GetInt("joker") - 1);
            SceneManager.LoadScene("rewards");
            
            /*
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            PlayerPrefs.SetInt("joker", PlayerPrefs.GetInt("joker") - 1);
            jokerprop.gameObject.SetActive(false);

            cards[PlayerPrefs.GetInt("level")-1].transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            cards[PlayerPrefs.GetInt("level") - 1].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            */
        }
        else
        {
            animatorobject.Play("yesjokerrewards");
        }
    }
}
