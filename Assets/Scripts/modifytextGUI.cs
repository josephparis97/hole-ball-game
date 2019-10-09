using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class modifytextGUI : MonoBehaviour
{
    public Text txt;
    
    // Start is called before the first frame update
    void Start()
    {
        int nombre = SceneManager.GetActiveScene().buildIndex + 1;
        txt.text = "" + nombre;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
