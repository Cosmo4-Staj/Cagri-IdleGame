using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerController : MonoBehaviour
{
    Animator MinerAnimator;
    public static MinerController instance;
    TransporterController playerManager;
    public float speed =2f;
    public GameObject prefab;
    public Transform Ore;
    public float stop = 2f;
        
    // Start is called before the first frame update
    void Start()
    {
        MinerAnimator = GetComponent<Animator>();
        instance=this;
        StartCoroutine(Spawn());  
    }

    // Update is called once per frame
    void Update()
    {
        
        float distanceToOre = Vector3.Distance(transform.position, Ore.position);
        transform.position = Vector3.MoveTowards(transform.position, Ore.position, speed * Time.deltaTime);
        SmoothFollow(Ore.position, 100f * 2f);
        if (distanceToOre < stop)
        {
            speed=0;
            MinerAnimator.SetTrigger("Mining");
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(GameManager.instance.waitfor);
        Brick.instance.SpawnBrick();
        StartCoroutine(Spawn());
    }

    private void SmoothFollow(Vector3 target, float smoothSpeed)
    {
        Vector3 direction = target - transform.position;
        if (direction != Vector3.zero)
        {
           transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), smoothSpeed * Time.deltaTime); 
        }
            
    }
}
