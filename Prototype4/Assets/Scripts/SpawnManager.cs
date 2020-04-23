using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange=9.0f;
    public int enemyCount;
    public int numEnemy=1;
    // Start is called before the first frame update
    void Start()
    {
       SpawnEnemyWave(numEnemy);//3= montako vihulaista halutaan
       Powerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount=FindObjectsOfType<Enemy>().Length;//seurataan montako vihulaista on
        if(enemyCount==0)
        {
            numEnemy++; //kasvatetaan vihulaisten määrää aina yhdellä
            SpawnEnemyWave(numEnemy);
            Powerup();
            
        }
    }
    void Powerup()
    {
        Instantiate(powerupPrefab,GenerateSpawnPosition(),powerupPrefab.transform.rotation);
    }
    void SpawnEnemyWave(int enemies)
    {
         for(int i=0; i<enemies; i++)
       { // laitetaan vihulainen ilmestymään pelikentälle satunnaisiin kohtiin
        
       Instantiate(enemyPrefab, GenerateSpawnPosition(),enemyPrefab.transform.rotation); 
       }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ =Random.Range(-spawnRange,spawnRange);
        Vector3 randomPos=new Vector3(spawPosX,0,spawnPosZ);
        return randomPos;
    }
}
