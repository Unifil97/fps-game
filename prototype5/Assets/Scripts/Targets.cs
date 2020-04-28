using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed=12;
    private float maxSpeed=16;
    private float torque=5;
    private float xRange=4;
    private float ySpawnPos=-2;
    public int pointValue;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        targetRb=GetComponent<Rigidbody>();
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(Vector3.up*Random.Range(minSpeed,maxSpeed),ForceMode.Impulse);
       
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);

        transform.position=RandomPos();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if(gameManager.gameActive)
        {
            Destroy(gameObject );
            Instantiate(explosion,transform.position,explosion.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        
    }
    Vector3 RandomForce()
    {
        //kuinka nopeasti tavarat lentää
       return Vector3.up*Random.Range(minSpeed,maxSpeed);
    }
    float RandomTorque()
    {
         //Määrätään kuinka tavarat pyörii akselinsa ympäri
       return Random.Range(-torque,torque); 
    }
    Vector3 RandomPos()
    {
        //Mistä kohdasta tavarat ilmestyy (vasen,oikea),korkeus
        return new Vector3(Random.Range(-xRange,xRange),ySpawnPos);
    }
}
