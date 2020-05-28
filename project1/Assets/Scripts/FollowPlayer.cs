using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
   [SerializeField] private Vector3 offset=new Vector3(02,7,-9);
    // Start is called before the first frame update
   

    // Update is called once per frame
    void LateUpdate()
    {
        // kamera pelaajan taakse lisäämällä pelaajan sijainti
        transform.position = player.transform.position + offset;
        
    }
}
