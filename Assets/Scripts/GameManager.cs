using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Transporter;
    public GameObject Miner;
    public GameObject SuperWorker;
    public GameObject Parent;
    public GameObject finishScreen;
    public GameObject mainScreen;
    public GameObject startScreen;
    public float xPos;
    public float zPos;
    public Text LevelText;
    public int ObjectCount = 0;
    public List <GameObject> Object;

    void Awake() 
    {
        instance = this;
    }
    public static bool isGameStarted = false;
    public static bool isGameEnded= false;

    void Start()
    {
        ObjectCount = 0;
        PlayerPrefs.SetInt("LevelID", ObjectCount); 
        GetLevel();
        //LevelText.text = "Level " + (ObjectCount +1).ToString();

    }

    void Update()
    {
        
    }

    public void OnLevelStarted()
    {
        isGameStarted = true;
        mainScreen.SetActive(true);
        startScreen.SetActive(false);
    }

    public void OnLevelEnded() // Game Over?
    {
        
    }

    public void OnLevelCompleted() // Loads the next level
    {
        mainScreen.SetActive(false);
        finishScreen.SetActive(true);
        isGameEnded = true;
    }

    public void OnLevelFailed() // Loads the current scene back
    {
        
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

    public void SpawnSuperWorker()
    {
        xPos=  Random.Range(1.5f,5.5f);
        zPos=  Random.Range(0f,10f);
        Instantiate(SuperWorker,new Vector3(xPos,0f,zPos),Quaternion.identity);
    }

    public void NextLevel ()
    {
        ObjectCount++;
        PlayerPrefs.SetInt("LevelID", ObjectCount); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GetLevel()
    {
        ObjectCount = PlayerPrefs.GetInt("LevelID", 0); 
        if (ObjectCount> Object.Count -1 || ObjectCount <0) 
        {
            ObjectCount = 0;
            PlayerPrefs.SetInt("LevelID", ObjectCount);
        }
        Instantiate(Object[ObjectCount],new Vector3(-2f,0.5f,0f), Quaternion.Euler(0,90,0));
    }
    
    public void Activation() 
    {

        
    }
}
