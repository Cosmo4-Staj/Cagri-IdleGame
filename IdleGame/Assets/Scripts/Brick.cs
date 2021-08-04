using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    TransporterController playerManager;
    public static Brick Instance;
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
}
