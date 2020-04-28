using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;// lista targets
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool gameActive;
    private int score;
    private float spawnRate=1; //esineiden luomis väli sekunneissa
    
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {// luodaan esineet pelikentälle
        while(gameActive)
        {
        yield return new WaitForSeconds(spawnRate);
        int index=Random.Range(0,targets.Count);
        Instantiate(targets[index]);
       
        }
        
    }
   public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text="Score: " +score;
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        gameActive=false;
    }
    public void RestartGame()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
    public void StartGame(int difficulty)
    {
        gameActive=true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /=difficulty;
        StartCoroutine(SpawnTargets());//kutsutaan luonti metodia
        score=0;
        UpdateScore(0);
        
    }
}
