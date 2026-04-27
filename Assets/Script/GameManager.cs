using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Stops game time, for pausing the game while in the title menu
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //for play again button
    public void Restart()
    {
        //load active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //for play button
    public void StartGame() 
    { 
        //deactives title screen
        titleScreen.SetActive(false);
        //unpauses game
        Time.timeScale = 1;
    }
}