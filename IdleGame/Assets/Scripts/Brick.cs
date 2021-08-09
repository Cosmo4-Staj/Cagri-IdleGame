using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    TransporterController playerManager;
    public static Brick Instance;
    public GameObject prefab;
    public float xPos;
    public float zPos;
    //public GameObject Bricks;
    public List<Transform> brickPieces = new List<Transform>();

    void Awake()
    {
        playerManager = FindObjectOfType<TransporterController>();

        Instance = this;
        
        for (int i = 0; i < transform.childCount; i++)
        {

            brickPieces.Add(transform.GetChild(i).transform);
        }
    }

    void Update() 
    {
        

    }
    public void SpawnBrick()
    {
        xPos=  Random.Range(-8f,-1f);
        zPos=  Random.Range(-12f,-9f);
        Instantiate(prefab,new Vector3(xPos,0.2f,zPos),Quaternion.identity);
        //brickPieces.Add(transform)
    }
}
