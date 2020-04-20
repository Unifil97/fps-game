using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    

    public float hyppyVoima;
    public float vetoVoima;
    public bool onMaassa=true;
    public bool gameOver=false;
    // Start is called before the first frame update
    void Start()
    {
        playerRB=GetComponent<Rigidbody>();
        playerAnim=GetComponent<Animator>();
        playerAudio=GetComponent<AudioSource>();
        Physics.gravity *= vetoVoima;
        dirtParticle.Stop();
                
    }

    // Update is called once per frame
    void Update()
    {   //painetaan välilyöntiä ukko hyppää
        if(Input.GetKeyDown(KeyCode.Space)&& onMaassa && !gameOver)
        {
            playerRB.AddForce(Vector3.up*hyppyVoima,ForceMode.Impulse);
            onMaassa=false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound,1.0f);//hyppy ääni
        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            onMaassa=true;
            dirtParticle.Play();//juostessa mura lentää
        }
        //kun törmätään esteeseen peli loppuu
        else if(collision.gameObject.CompareTag("Este"))
        {
            Debug.Log("Game over");
            gameOver=true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();//näytetään tehosteet
            dirtParticle.Stop();//muran lennätys lopetetaan
            playerAudio.PlayOneShot(crashSound,1.0f);//törmäys ääni
            
        }
    }
}
