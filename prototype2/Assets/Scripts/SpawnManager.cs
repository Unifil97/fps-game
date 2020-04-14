using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float tuloAlueX=20;
    private float tuloKohtaZ=20;
    private float aloitusAika=2;
    private float tuloVali=1.5f;
    
   // public int animalIndex;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LuoRandomiElukka",aloitusAika,tuloVali);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void LuoRandomiElukka()
    {
        int animalIndex = Random.Range(0,animalPrefabs.Length);
           Vector3 spanPos=new Vector3(Random.Range(-tuloAlueX,tuloAlueX),0,tuloKohtaZ);
            Instantiate(animalPrefabs[animalIndex],spanPos,animalPrefabs[animalIndex].transform.rotation);
    }
}
