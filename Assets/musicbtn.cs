using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicbtn : MonoBehaviour
{
    public GameObject explodesound;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(task);
        if(PlayerPrefs.HasKey("music"))
        {
            if(PlayerPrefs.GetString("music")=="oui")
            {
                explodesound.GetComponent<AudioSource>().volume = 1f;
            }
            else
            {
                explodesound.GetComponent<AudioSource>().volume = 0f;
            }

        }
    }

    // Update is called once per frame
    void task()
    {
        if(FindObjectOfType<AudioManager>().GetComponent<AudioSource>().volume >0)
        {
            PlayerPrefs.SetString("music", "non");
            explodesound.GetComponent<AudioSource>().volume = 0f;
            foreach (AudioSource s in FindObjectOfType<AudioManager>().GetComponents<AudioSource>())
            {
                s.volume = 0;
                transform.Find("croix").gameObject.GetComponent<Image>().color= new Color32(255, 255, 255, 255);

            }
            foreach (AudioSource s in GameObject.Find("theball").gameObject.GetComponents<AudioSource>())
            {
                s.volume = 0;
            }
            
        }
        else
        {
            explodesound.GetComponent<AudioSource>().volume = 1f;
            PlayerPrefs.SetString("music", "oui");
            foreach (AudioSource s in FindObjectOfType<AudioManager>().GetComponents<AudioSource>())
            {
                s.volume = 0.378f;
                transform.Find("croix").gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 0);

            }
            foreach (AudioSource s in GameObject.Find("theball").GetComponents<AudioSource>())
            {
                s.volume = 0.613f;
            }

        }
    }
}
