using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterController : MonoBehaviour
{
    public GameObject worker;
    public Transform targetBrick;
    public float speed = 2f;
    public GameObject Aharfi;
    [SerializeField] private Transform brickPosition;
    [SerializeField] private float stopDistance = 0.5f;
    public bool isTakeBrick = false;
    public GameObject build;
    public int j =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Aharfi.GetComponent<Transform>().GetChild(j).gameObject.activeSelf)
        {  
            Debug.Log("Aktif");
            j++;

        }



        if (!isTakeBrick)
        {
        Search();
        }
        else{
        Build();
        }
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
            //Debug.Log(distanceToBrick);
            Pick();
        }
    }

    void FindBrick()
    {
        
        if (targetBrick || Brick.Instance.brickPieces.Count <= 0) return;
        targetBrick = Brick.Instance.brickPieces[0];
        Brick.Instance.brickPieces.Remove(targetBrick);
        //targetBrick = FindGameObjectWithTag("brick").transform;
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
        targetBrick.parent = brickPosition;
        targetBrick.position = brickPosition.position;
        isTakeBrick=true;
    }

    void Build()
    {
        var distanceToBuild = Vector3.Distance(transform.position, build.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, build.transform.position, speed * Time.deltaTime);
        SmoothFollow(build.transform.position, 100f * speed);
        if (distanceToBuild < stopDistance)
        {
            Invoke("DropBrick", 1f);

        }
    }

    void DropBrick()
    {
            Destroy(this.GetComponent<Transform>().GetChild(2).GetChild(0).gameObject);
            isTakeBrick=false;
            Aharfi.GetComponent<Transform>().GetChild(j).gameObject.SetActive(true);
            //j++;
        
    }
}
