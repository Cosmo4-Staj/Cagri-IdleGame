using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterController : MonoBehaviour
{
    MoneyManager moneyManager;
    Animator TransporterAnimator;
    public GameObject worker;
    public Transform targetBrick;
    public float speed = 2f;
    public GameObject BuildObject;
    [SerializeField] private Transform brickPosition;
    public float stopDistance = 0.5f;
    public bool isTakeBrick = false;
    public GameObject build;
    public int child;
    public static int j=0;
    // Start is called before the first frame update
    void Start()
    {
        BuildObject=GameManager.instance.Object[GameManager.instance.ObjectCount];
        TransporterAnimator = GetComponent<Animator>();
        moneyManager = FindObjectOfType<MoneyManager>();
    }
    // Update is called once per frame
    void Update()
    {

        child=BuildObject.GetComponent<Transform>().gameObject.transform.childCount;
        //Debug.Log("child sayısı:"+child);
        if (!GameManager.isGameStarted || GameManager.isGameEnded) // Oyun baslamadiysa veya bittiyse
        {
            return;
        }
        if (!isTakeBrick)
        {
        Search();
        }
        else{
        Build();
        }
    }

    public void Search()
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

    public void FindBrick()
    {
        if (targetBrick || Brick.instance.brickPieces.Count <= 0) return;
        targetBrick = Brick.instance.brickPieces[0];
        Brick.instance.brickPieces.Remove(targetBrick);
        TransporterAnimator.SetTrigger("Walk");
        
    }

    private void SmoothFollow(Vector3 target, float smoothSpeed)
    {
        Vector3 direction = target - transform.position;
        if (direction != Vector3.zero)
        {
           transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), smoothSpeed * Time.deltaTime); 
        }
            
    }

    public void Pick()
    {
        if (targetBrick)
        {
            //StartCoroutine(TakeBrick());  
            TransporterAnimator.SetTrigger("Pick");
            Invoke("TakeBrick", 1f);
        }
    }

    public void TakeBrick()
    {
        //TransporterAnimator.SetTrigger("Pick");
        //yield return new WaitForSeconds(1f);
        targetBrick.parent = brickPosition;
        targetBrick.position = brickPosition.position;
        isTakeBrick=true;
    }

    public void Build()
    {
        TransporterAnimator.SetTrigger("Walk");
        var distanceToBuild = Vector3.Distance(transform.position, build.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, build.transform.position, speed * Time.deltaTime);
        SmoothFollow(build.transform.position, 100f * speed);
        if (distanceToBuild < stopDistance)
        {
            //TransporterAnimator.SetTrigger("Pick");
            //Invoke("DropBrick", 1f);
            DropBrick();
            moneyManager.AddMoney(2);

        }
    }

    public void DropBrick()
    {
        
        Destroy(this.GetComponent<Transform>().GetChild(2).GetChild(0).gameObject);
        isTakeBrick=false;
        Debug.Log("J değerimiz"+j);
        BuildObject.GetComponent<Transform>().GetChild(j).gameObject.SetActive(true);
        j++;
        if(j>=child)
        {
            GameManager.instance.OnLevelCompleted();
        }
    }
    
}
