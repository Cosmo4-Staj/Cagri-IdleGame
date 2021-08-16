using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransporterController : MonoBehaviour
{
    public static TransporterController instance;
    Animator TransporterAnimator;

    public GameObject BuildPrefab;
    public GameObject buildArea;
    public GameObject smoke;

    [SerializeField] private Transform brickPosition;
    public Transform targetBrick;

    public float speed = 2f;
    public float stopDistance = 0.5f;
    public bool isTakeBrick = false;
    public int child;
    public static int j=0;

    void Awake() 
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        TransporterAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        BuildPrefab=GameManager.instance.Object[GameManager.instance.ObjectCount];
        child=BuildPrefab.GetComponent<Transform>().GetChild(0).gameObject.transform.childCount;
        GameManager.instance.level(j/(float) child);
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
            TransporterAnimator.SetTrigger("Pick");
            //TakeBrick();
            Invoke("TakeBrick", 1.0f);
        }
    }

    public void TakeBrick()
    {
        //GameObject smokeInstance =Instantiate(smoke, brickPosition.transform.position, brickPosition.transform.rotation);
        //Destroy(smokeInstance.gameObject, 1f);
        targetBrick.parent = brickPosition;
        targetBrick.position = brickPosition.position;
        isTakeBrick=true;
        
    }

    public void Build()
    {
        TransporterAnimator.SetTrigger("Walk");
        var distanceToBuild = Vector3.Distance(transform.position, buildArea.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, buildArea.transform.position, speed * Time.deltaTime);
        SmoothFollow(buildArea.transform.position, 100f * speed);
        if (distanceToBuild < stopDistance)
        {
            //TransporterAnimator.SetTrigger("Pick");
            //Invoke("DropBrick", 1f);
            DropBrick();
            MoneyManager.instance.AddMoney(2);

        }
    }

    public void DropBrick()
    {
        GameObject smokeInstance =Instantiate(smoke, Prefab.instance.sortedBrickList[j].transform.position, Prefab.instance.sortedBrickList[j].transform.rotation);
        Destroy(smokeInstance.gameObject, 1f);
        Destroy(this.GetComponent<Transform>().GetChild(2).GetChild(0).gameObject);
        isTakeBrick=false;
        Prefab.instance.sortedBrickList[j].SetActive(true);
        j++;
        if(j>=child)
        {
            j=0;
            GameManager.instance.OnLevelCompleted();
        }
    }
    
}
