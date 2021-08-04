using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterController : MonoBehaviour
{
    public Transform targetBrick;
    public float speed = 2f;
    [SerializeField] private Transform brickCarryPosition;
    [SerializeField] private float stopDistance = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Search();
    }

    void Search()
    {
        FindBrick();
        if (!targetBrick) return;
        var targetPos = targetBrick.position; 
        targetPos.y = 0f;
        var distanceToBrick = Vector3.Distance(transform.position, targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        SmoothFollow(targetPos, 100f * speed);
        
        if (distanceToBrick < stopDistance)
        {
            Pick();
        }
    }

    void FindBrick()
    {
        
        if (targetBrick || Brick.Instance.brickPieces.Count <= 0) return;
        targetBrick = Brick.Instance.brickPieces[0];
        Brick.Instance.brickPieces.Remove(targetBrick);
    }

    private void SmoothFollow(Vector3 target, float smoothSpeed)
    {
        Vector3 direction = target - transform.position;
        if (direction != Vector3.zero)
        {
           transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), smoothSpeed * Time.deltaTime); 
        }
            
    }

    void Pick()
    {
        if (targetBrick)
        {
            Invoke("TakeBrick", 1f);
        }
    }

    void TakeBrick()
    {
        targetBrick.parent = brickCarryPosition;
        targetBrick.position = brickCarryPosition.position;
    }
}
