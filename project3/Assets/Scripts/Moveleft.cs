using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController playerContsollerScript;
    private float leftBound = -15f;//määritellään missä kohtaa este tuhotaan
    // Start is called before the first frame update
    void Start()
    {
       playerContsollerScript=GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      if(playerContsollerScript.gameOver==false)
      {
        transform.Translate(Vector3.left*Time.deltaTime*speed);
      }
      if(transform.position.x < leftBound && gameObject.CompareTag("Este"))
      {
        Destroy(gameObject);//este tuhotaan
      }
        
    }
}
