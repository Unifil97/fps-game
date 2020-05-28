using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
     public GameObject[] animalPrefabs;
     public TextMeshProUGUI scoreText;
     public TextMeshProUGUI gameOverText;
     public Button restartButton;
     public bool gameActive;
    private int score;
    private float tuloAlueX=345;
    private float tuloKohtaZ=450;
    private float aloitusAika=2;
    private float tuloVali=1.5f;
   
    
   // public int animalIndex;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LuoElukka",aloitusAika,tuloVali);
        score=0;
        UpdateScore(0);
        gameActive=true;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void LuoElukka()
    {
       if(gameActive){
        int animalIndex = Random.Range(0,animalPrefabs.Length);
           Vector3 spanPos=new Vector3(Random.Range(150,tuloAlueX),0,tuloKohtaZ);
            Instantiate(animalPrefabs[animalIndex],spanPos,animalPrefabs[animalIndex].transform.rotation);
       }
    }
     public void UpdateScore(int Addscore)
    {
        score+=Addscore;
        scoreText.text="Score: "+score;
    }
   public void GameOver()
    {
        if(score<=0){
            gameOverText.gameObject.SetActive(true);
            gameActive=false;
            restartButton.gameObject.SetActive(true);
        }
    }
    public void Restart()
    {   
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
