using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonpush : MonoBehaviour
{

    public Button btn;
    public GameObject img;
    private Vector3 initscale;
    private Vector3 targetscale;
    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        targetscale = new Vector3(img.transform.localScale.x - img.transform.localScale.x / 10, img.transform.localScale.y - img.transform.localScale.y / 10, img.transform.localScale.z - img.transform.localScale.z / 10);
        initscale = img.transform.localScale;
        btn.onClick.AddListener(task);
    }

    
    // Update is called once per frame
    void Update()
    {
        if(done==false)
        {
            Vector3.Lerp(img.transform.localScale, targetscale, Time.deltaTime*100);
        }
        if(img.transform.localScale==targetscale)
        {
            done = true;
            Vector3.Lerp(img.transform.localScale, initscale, Time.deltaTime*100);
        }
    }

    public void task()
    {
        Debug.Log("ya un truc");
        done = false;
    }
}
