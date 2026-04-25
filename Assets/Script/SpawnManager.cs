using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //for constantly calling SpawnObstacle
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    void SpawnObstacle ()
    {
        if(playerControllerScript.gameOver == false)
        {
            //for making clones of the obstacle
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
            UpdateScore(1);
          
        }
    
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
