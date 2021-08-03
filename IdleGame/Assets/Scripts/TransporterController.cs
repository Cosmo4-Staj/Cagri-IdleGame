using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterController : MonoBehaviour
{
    
    Transform  Piece;
    // Start is called before the first frame update
    void Start()
    {
        Piece=GameObject.Find("Piece").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,Piece.transform.position,Time.deltaTime);
    }
}
