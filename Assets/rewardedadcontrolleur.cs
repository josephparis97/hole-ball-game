using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class rewardedadcontrolleur : MonoBehaviour
{
    //---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//
#if UNITY_IOS
    private string gameId = "1486551";
#elif UNITY_ANDROID
    private string gameId = "3235396";
#endif
    //-------------------------------------------------------------------//

    Button m_Button;
    public GameObject cristalobj;
    public string placementId = "rewardedVideo";

    void Start()
    {
        m_Button = GetComponent<Button>();
        if (m_Button) m_Button.onClick.AddListener(ShowAd);

        //---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, false);
        }
        //-------------------------------------------------------------------//
    }

    void Update()
    {
        if (m_Button) m_Button.interactable = Advertisement.IsReady(placementId);
    }

    void ShowAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show(placementId, options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video completed - Offer a reward to the player");
            //PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") + 5);
            StartCoroutine(cristalmove());

        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }

    IEnumerator cristalmove()
    {

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(cristalobj, GameObject.Find("pointB").transform);
            //Debug.Log("cristal pose");
        }
    }
}
