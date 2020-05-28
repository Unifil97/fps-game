using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
   [SerializeField] float speed;
   [SerializeField] float rpm;
   [SerializeField] private float horsePower=0;
   private float turnSpeed=30f;
   private float horizontalInput;
   public float verticalInput;
   private Rigidbody playerRb;
   [SerializeField] GameObject centerOfMass;
   [SerializeField] TextMeshProUGUI speedText;
   [SerializeField] TextMeshProUGUI rpmText;
   [SerializeField] List<WheelCollider> wheels;
   [SerializeField] int wheelsOnGround;
    // Start is called before the first frame update
    void Start()
    {
       playerRb=GetComponent<Rigidbody>(); 
       playerRb.centerOfMass=centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput= Input.GetAxis("Horizontal");
        verticalInput=Input.GetAxis("Vertical");
       // liikutetaan autoa eteenpäin
      // transform.Translate(Vector3.forward*Time.deltaTime*speed * forwardInput);
      if(IsOnGround())
      {
       playerRb.AddRelativeForce(Vector3.forward*horsePower*verticalInput);
       transform.Rotate(Vector3.up,  Time.deltaTime * turnSpeed * horizontalInput); 
       speed=Mathf.RoundToInt(playerRb.velocity.magnitude*3.6f); //km/h mailia vaihda 2.237
       speedText.SetText("Speed: "+speed+" km/h");
       rpm=(speed % 30)*50;
       rpmText.SetText("Rpm: "+ rpm);
      }
     
    }
    bool IsOnGround()
    {
      wheelsOnGround=0;
      foreach(WheelCollider wheel in wheels)
      {
        if(wheel.isGrounded)
        {
          wheelsOnGround++;
        }
      }
      if(wheelsOnGround==4)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
}
