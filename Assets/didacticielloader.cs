using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class didacticielloader : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("didacticiel")==false)
        {
            SceneManager.LoadScene("didacticiel");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
