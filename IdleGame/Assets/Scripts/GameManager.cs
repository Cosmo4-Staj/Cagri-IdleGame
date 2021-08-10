using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Brick;
    public GameObject Transporter;
    public GameObject Miner;
    public GameObject Parent;
    public float xPos;
    public float zPos;

    void Awake() 
    {
        instance = this;
    }
    public static bool isGameStarted = false;
    public static bool isGameEnded= false;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void OnLevelStarted()
    {
        
    }

    public void OnLevelEnded() // Game Over?
    {
        
    }

    public void OnLevelCompleted() // Loads the next level
    {
        
    }

    public void OnLevelFailed() // Loads the current scene back
    {
        
    }
    public void SpawnBrick()
    {
        xPos=  Random.Range(-8f,-1f);
        zPos=  Random.Range(-12f,-9f);
        Instantiate(Brick,new Vector3(xPos,0.2f,zPos),Quaternion.identity,Parent.transform);
        
    }

    public void SpawnTransporter()
    {
        xPos=  Random.Range(1.5f,5.5f);
        zPos=  Random.Range(0f,10f);
        Instantiate(Transporter,new Vector3(xPos,0.05268812f,zPos),Quaternion.identity);
    }
    public void SpawnMiner()
    {
        xPos=  Random.Range(-13f,-10f);
        zPos=  Random.Range(-6f,0f);
        Instantiate(Miner,new Vector3(xPos,0f,zPos),Quaternion.identity);
    }
    
}
