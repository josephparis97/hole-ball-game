using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class storeloader : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(task);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void task()
    {
        PlayerPrefs.SetInt("tmplevel", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("store");
    }
}
