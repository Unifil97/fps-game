using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public SpawnManager spawnManager;
   
    public AudioSource shotAudio;
    public AudioClip shotSound;
    public GameObject hitExplosion;
    public GameObject missExplosion;
   
    
    
  
    // Start is called before the first frame update
    void Start()
    {
        shotAudio.GetComponent<AudioSource>();
        spawnManager=GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        Cursor.visible=false;
        
    }

    // Update is called once per frame
    void Update()
    {
         
        this.transform.position=Input.mousePosition;
         if(Input.GetMouseButtonDown(0) )
         {
             
            shotAudio.PlayOneShot(shotSound,1);
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           
            if(Physics.Raycast(ray,out hit))
            {
                                                                    
                
                
                if(hit.transform.gameObject.tag=="Enemy")
                {
                   
                    Destroy(hit.transform.gameObject); 
                     Instantiate(hitExplosion,hit.point,Quaternion.LookRotation(hit.normal)) ;
                     spawnManager.UpdateScore(5);                 
                                 
                }
                  Instantiate(missExplosion,hit.point,Quaternion.LookRotation(hit.normal));
                if(spawnManager.gameActive==false){
                    Cursor.visible=true;
                    spawnManager.Restart();

                }
            }
             
         } 
         
    }
    
}
