using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmanager : MonoBehaviour
{
    private void Awake()
    {
        /*
        if (PlayerPrefs.HasKey("jeviensdesrewards"))
        {


            if (PlayerPrefs.GetString("jeviensdesrewards") == "oui")
            {
                Debug.Log("viens des rewards");
                PlayerPrefs.SetString("jeviensdesrewards", "non");
            }
            else if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("level") - 1);
            }
        }
        */
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("tmp level :" + PlayerPrefs.HasKey("tmplevel"));
        //Debug.Log("tmp level :" + PlayerPrefs.GetInt("tmplevel"));
        //Debug.Log("tmp level :" + PlayerPrefs.HasKey("tmplevel"));
        /*
       
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
