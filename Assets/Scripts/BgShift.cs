using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgShift : MonoBehaviour
{


    public GameObject[] obstacles;
    // Start is called before the first frame update
    private GameObject[] loadedObstacle = new GameObject[2];
    private int aux = 0;

    private int lastRandomGenerated = -1;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Background")
        {
                    
            //Coloca a posição do background que passou para depois do que esta passando    
            float widht = ((BoxCollider2D)col).size.x;
            Vector3 colPos = col.transform.position;  
          
            col.transform.position = new Vector3(colPos.x + 2*widht, colPos.y, colPos.z);

            //faz com que o proximo obstaculo seja diferente do ultimo
            int randomGenerated = Random.Range(0,obstacles.Length);
            while(randomGenerated == lastRandomGenerated)
            {
                randomGenerated = Random.Range(0,obstacles.Length);
            }   
            lastRandomGenerated = randomGenerated;


            //Destroi o obstaculo carregado anteriormente
            if(loadedObstacle[aux%2] != null)
                Destroy(loadedObstacle[aux%2]);
            //Instancia um novo obstaculo para o proximo cenârio aleatóriamente
            loadedObstacle[aux%2] = (GameObject)Instantiate(obstacles[randomGenerated], col.transform);
    
            aux += 1;        
        }
    }
}
