using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    [SerializeField]
    private GameObject gameover;

    [SerializeField]
    private int counterdied = 1;

    [SerializeField]
    private Text txtscore;

    //[SerializeField]
    //private Text finalscore;

    [SerializeField]
    private GameObject optionscreen;

    void Start()
    {
      counterdied = counterdied;
     instance = this;
     txtscore.text = "Mortes: " + counterdied.ToString();
    }

     void Update()
    {
         txtscore.text = "Mortes: " + counterdied.ToString();  
    }

    public void Gameoverr()
    {
        gameover.SetActive(true);
        counterdied++;
    }

    public void Restartgame(string lvlname)
    {
        counterdied = counterdied;
        SceneManager.LoadScene(lvlname);
        
    }

    public void Wingame(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
        counterdied = 0;
    }

    public void Quitgame ()
    { 
        Application.Quit();
    }

    public void OpenOptionsgame ()
    {
        optionscreen.SetActive(true);
    
    }

    public void CloseOptionsgame ()
    {
        optionscreen.SetActive(false);
    }
}
