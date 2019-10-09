using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cristalerpcontrol : MonoBehaviour
{
    private Vector2 origin;
    private Vector2 destination;
    // Start is called before the first frame update
    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("imgcristalstatic").transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.Lerp(transform.position, destination,Time.deltaTime*5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yes111");
        Destroy(this.gameObject);
    }
}
