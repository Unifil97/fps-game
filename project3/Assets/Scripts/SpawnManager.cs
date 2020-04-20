using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject estePrefab;
    private Vector3 tuloKohta = new Vector3(25,0,0);// määritellään mistä kohdasta este tulee
    private float alkuViive=2;
    private float uusintaVali=2;
    private PlayerController playerContsollerScript;
    // Start is called before the first frame update
    void Start()
    {
       playerContsollerScript=GameObject.Find("Player").GetComponent<PlayerController>();
      InvokeRepeating("SpawnObstacle",alkuViive, uusintaVali);  //uusi este pelikentälle
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if(playerContsollerScript.gameOver==false)
        {
            Instantiate(estePrefab, tuloKohta, estePrefab.transform.rotation );
        }
        
    }
}
