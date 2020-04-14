using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float ylaRaja = 30;
    private float alaRaja= -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > ylaRaja) 
        {
            Destroy(gameObject);
        }
        else if(transform.position.z<alaRaja)
        {
            Destroy(gameObject);
        }
                
         
        
    }
}
