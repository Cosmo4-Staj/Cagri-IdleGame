using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Brick;

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
        Instantiate(Brick,transform.position,Quaternion.identity);
    }
}
