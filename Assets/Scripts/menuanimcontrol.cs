using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuanimcontrol : MonoBehaviour
{
    public Button menu;
    //public Animator joker;
    public GameObject jkr;
    public GameObject medaille;
    public GameObject magasin;
    public GameObject circle;
    public GameObject cube;
    public GameObject dialogbox;
    public Button enorme;
    
    
    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        Time.timeScale = 1f;
        menu.onClick.AddListener(task);
        jkr.GetComponent<Button>().onClick.AddListener(dialogtask);
        enorme.onClick.AddListener(referme);
        //jkr.GetComponent<Animator>().updateMode=Unsc
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void task()
    {
        if (pause)
            taskplay(); 
        else
            taskpause();
    }
    public void taskpause()
    {
        
            Time.timeScale = 0f;
            pause = true;
            //joker.Play("jokerintra");
            jkr.GetComponent<Animator>().Play("jokerextra");
            medaille.GetComponent<Animator>().Play("medailleextra");
            magasin.GetComponent<Animator>().Play("magasinextra");
            circle.GetComponent<Animator>().Play("circlein");
            cube.GetComponent<Animator>().Play("cuberotationin");
            FindObjectOfType<AudioManager>().Play("menuentrer");

    }

    public void taskplay()
    {
        
            Time.timeScale = 1f;
            pause = false;
            jkr.GetComponent<Animator>().Play("jokerintra");
            medaille.GetComponent<Animator>().Play("medailleintra");
            magasin.GetComponent<Animator>().Play("magasinintra");
            circle.GetComponent<Animator>().Play("circleout");
            cube.GetComponent<Animator>().Play("cuberotationout");
            FindObjectOfType<AudioManager>().Play("menusortie");


    }

    public void dialogtask()
    {
        if(PlayerPrefs.GetInt("joker") > 0)
        {
            dialogbox.SetActive(true);
            dialogbox.transform.GetChild(1).transform.GetChild(0).GetComponent<Button>().onClick.AddListener(yestask);
            dialogbox.transform.GetChild(1).transform.GetChild(1).GetComponent<Button>().onClick.AddListener(referme);
        }
        else
        {
            jkr.transform.Find("pasjoker").GetComponent<Animator>().Play("pasokertxtanim");
            if(PlayerPrefs.GetString("music")=="oui")
            {
                FindObjectOfType<AudioManager>().Play("btnnegatif");
            }
        }
        
    }
    public void referme()
    {
        dialogbox.SetActive(false);
    }

    public void yestask()
    {
        Debug.Log("yess !!!");
        if (PlayerPrefs.GetInt("level") == SceneManager.GetActiveScene().buildIndex + 1 && PlayerPrefs.GetInt("joker")>0)
        {
            PlayerPrefs.SetInt("joker", PlayerPrefs.GetInt("joker") - 1);
        //toutes les animations du menu///////////
        Time.timeScale = 1f;
        pause = false;
        jkr.GetComponent<Animator>().Play("jokerintra");
        medaille.GetComponent<Animator>().Play("medailleintra");
        magasin.GetComponent<Animator>().Play("magasinintra");
        circle.GetComponent<Animator>().Play("circleout");
        cube.GetComponent<Animator>().Play("cuberotationout");
        /////////////////////////////////////////////////////

        dialogbox.SetActive(false);
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            StartCoroutine(LoadScene());
        }
        {
           //GetComponent<Animator>().Play("pasokertxtanim");
           if(GameObject.Find("pasjoker")!=null)
            {
                Debug.Log("j'ai trouvé !!!!");
            }
            //GameObject.Find("pasjoker").GetComponent<Animator>().Play("pasokertxtanim");
        }
        
    }

    IEnumerator LoadScene()
    {
        
        GameObject.Find("Main Camera").GetComponent<Animator>().Play("out");
        //transitionAnimator.GetComponent<Animator>().Play("out");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
