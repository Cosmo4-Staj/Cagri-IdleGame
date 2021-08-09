using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Brick;
    public GameObject Transporter;
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
        Instantiate(Brick,new Vector3(xPos,0.2f,zPos),Quaternion.identity);
    }

    public void SpawnTransporter()
    {
        Instantiate(Transporter,new Vector3(-10f,0.05268812f,-5f),Quaternion.identity);
    }
}
