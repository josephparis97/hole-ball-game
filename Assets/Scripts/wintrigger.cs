using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class wintrigger : MonoBehaviour
{
    public GameObject transitionAnimator;
    public ParticleSystem win;
    public int numero;
    private Player player=new Player();
    public UnityEvent winning = new UnityEvent();

    
    void Awake()
    {
        if (PlayerPrefs.HasKey("level") == false)
        {
            PlayerPrefs.SetInt("level", 1);
            //SceneManager.LoadScene(0);
        }

        if(PlayerPrefs.HasKey("didacticiel")==false)
        {
            SceneManager.LoadScene("didacticiel");
        }

        if(SceneManager.GetActiveScene().buildIndex==0)
        {
            if (PlayerPrefs.GetInt("level") > 1)
            {
                if (PlayerPrefs.HasKey("jeviensdesrewards"))
                {
                    if(PlayerPrefs.GetString("jeviensdesrewards")=="oui")
                    {
                        PlayerPrefs.SetString("jeviensdesrewards", "non");
                    }
                    else
                    {
                        SceneManager.LoadScene(PlayerPrefs.GetInt("level") - 1);
                    }
                }
                else
                {
                    SceneManager.LoadScene(PlayerPrefs.GetInt("level")-1);
                }
            }
        }
        
    }
    


    // Start is called before the first frame update
    void Start()
    {
        AnalyticsEvent.LevelStart(PlayerPrefs.GetInt("level"));
        //PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter(Collider other)//Lorsque la sphere est traversé
    {
       
        if(other.tag=="Player")//si l'onjet qui la traverse est la boule
        {
            other.gameObject.SetActive(false);//rendre inactif la boule
            
        }
        winning.Invoke();//invoque l'évennement "le joueur vient de gagner le niveau"

       
        if(PlayerPrefs.GetInt("level")==SceneManager.GetActiveScene().buildIndex+1)//si le niveau sur lequel est situé le joueur est un niveau qu'il n'a jamais réussi
        {
            AnalyticsEvent.LevelComplete(PlayerPrefs.GetInt("level"));//Analytics sert pour envoyer des informations au créateur du jeu
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);//on ajoute un niveau au nombre de niveau réussi par le joueur
        }
        StartCoroutine(LoadScene()); // appelle la coroutine LoadScene    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator LoadScene()
    {
        win.Play();//permet d'activer l'animation des particules lorsque le joueur gagne
        FindObjectOfType<AudioManager>().Play("victoire1");//permet de joueur le son de la victoire
            
        yield return new WaitForSeconds(2f);//attendre 2secondes

        transitionAnimator.GetComponent<Animator>().Play("out");//lancer l'animation de camera pour la transition entre les niveaux
        yield return new WaitForSeconds(1f);//attendre 1 seconde

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//démarrer le niveau suivant
        
    }
    
}


