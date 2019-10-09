using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneloaderonclick : MonoBehaviour
{
    public Button btn;

    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("level") == false)
        {
            PlayerPrefs.SetInt("level", 1);
        }
        btn.onClick.AddListener(task);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void task()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("tmplevel"));
       

    }
}
