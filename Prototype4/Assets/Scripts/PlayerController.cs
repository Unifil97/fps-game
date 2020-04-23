using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerIndicator;
    public float speed=5;
    public float powerupForce=15.0f;//törmäys voima
    
    public bool hasPowerup=false;

    // Start is called before the first frame update
    void Start()
    {
       playerRb=GetComponent<Rigidbody>(); 
       focalPoint=GameObject.Find("Focal Point");//etsitään Focal Point hierarkiasta
    }

    // Update is called once per frame
    void Update()
    {
        float inputForward=Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * inputForward * speed);
        powerIndicator.transform.position=transform.position+new Vector3(0,-0.5f,0);//laitetaan powerIndicator seuraamaan pelaajaa
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            powerIndicator.gameObject.SetActive(true);//aktivoidaan powerIndicator
            hasPowerup=true;//osutaan powerup:iin ja tuhotaan se
            Destroy(other.gameObject);
            StartCoroutine(PowerupTime());//Powerup alkaa
        }
    }
    IEnumerator PowerupTime()
    {
        yield return new WaitForSeconds(5);//Kauanko powerup kestää
        hasPowerup=false;
        powerIndicator.gameObject.SetActive(false);//poistetaan powerIndicator näkyvistä
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")&& hasPowerup)
        {
            Rigidbody enemyRigidbody=collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer=collision.gameObject.transform.position - transform.position;// Enemy poispäin pelaajasta

            enemyRigidbody.AddForce(awayFromPlayer*powerupForce,ForceMode.Impulse);//törmäys voima
            Debug.Log("Törmäsit " + collision.gameObject.name + " Powerup " + hasPowerup);
        }
    }
}
