using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sphere : MonoBehaviour
{
    private Vector3 origin;
    public Rigidbody rb;
    public GameObject pref;
    public int hauteur = 20;
    public GameObject develop; //questionnaire

    public UnityEvent restartevent=new UnityEvent();
    private GameObject[] argents;

    // Start is called before the first frame update
    void Start()
    {

        origin = this.transform.position;
        //pour la musique
        if (PlayerPrefs.HasKey("music"))
        {
            if(PlayerPrefs.GetString("music")=="oui")
            {
                foreach (AudioSource s in FindObjectOfType<AudioManager>().GetComponents<AudioSource>())
                {
                    s.volume = 0.378f;
                    //GameObject.Find("croix").gameObject.SetActive(false);
                    GameObject.Find("croix").gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 0);


                }
            }
            else
            {
                foreach (AudioSource s in FindObjectOfType<AudioManager>().GetComponents<AudioSource>())
                {
                    s.volume = 0;
                    //GameObject.Find("croix").gameObject.SetActive(true);
                    GameObject.Find("croix").gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

                }
            }
        }
        else
        {
            PlayerPrefs.SetString("music", "oui");
        }

        
        develop = GameObject.Find("Gui").transform.GetChild(13).gameObject;

        //restartevent = new UnityEvent();


        //PlayerPrefs.DeleteKey("level02");
        //PlayerPrefs.DeleteKey("level03");
        //PlayerPrefs.DeleteKey("level04");
        //PlayerPrefs.DeleteAll();
        argents = GameObject.FindGameObjectsWithTag("pierre");

        //Debug.Log("Le numero du build index de la scène est :" + SceneManager.GetActiveScene().buildIndex + 1);
        foreach (GameObject argent in argents)
        {
            //PlayerPrefs.DeleteKey(argent.name + SceneManager.GetActiveScene().buildIndex);
            if (PlayerPrefs.HasKey(argent.name + SceneManager.GetActiveScene().buildIndex))
                Destroy(argent);
        }

        if(PlayerPrefs.HasKey("questionnaire")==false&&PlayerPrefs.GetInt("level")>=19)
        {
            PlayerPrefs.SetString("questionnaire", "done");
            develop.gameObject.SetActive(true);
        }
       


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < origin.y - hauteur)
        {
            this.transform.position = origin;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            restartevent.Invoke();

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
       

        
        if (other.tag == "pierre")
        {
            //le son

          
            
            PlayerPrefs.SetInt(other.name + SceneManager.GetActiveScene().buildIndex, 1);
            Debug.Log("voici le nom du cristal touché" + other.name + SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") + 1);
            
            Debug.Log(other.name);
            Instantiate(pref, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("son rebond");
        //FindObjectOfType<AudioManager>().Play("rebond");
        if(PlayerPrefs.GetString("music")=="oui")
        {
            GetComponent<AudioSource>().pitch = 1 + Random.Range(-0.1f, 0.1f);
            GetComponent<AudioSource>().volume = GetComponent<Rigidbody>().velocity.magnitude;
            GetComponent<AudioSource>().Play();
        }
        
    }

}
