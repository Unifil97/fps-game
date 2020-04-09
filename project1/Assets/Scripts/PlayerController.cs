using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private float speed= 10f;
   private float turnSpeed=30f;
   private float horizontalInput;
   public float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput= Input.GetAxis("Horizontal");
        forwardInput=Input.GetAxis("Vertical");
       // liikutetaan autoa eteenpäin
       transform.Translate(Vector3.forward*Time.deltaTime*speed * forwardInput);
       transform.Rotate(Vector3.up,  Time.deltaTime * turnSpeed * horizontalInput);  
    }
}
