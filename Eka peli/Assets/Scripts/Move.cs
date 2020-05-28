using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    public Rigidbody rbEnemy;
    public SpawnManager spawnManager;
    public float speed=20;
  
     
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy=GetComponent<Rigidbody>();
        spawnManager=GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(0,1,0);
        transform.Translate(Vector3.up*Time.deltaTime*speed);
        
    }
   public void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
        spawnManager.UpdateScore(-15);
        spawnManager.GameOver(); 
        
    }

}
