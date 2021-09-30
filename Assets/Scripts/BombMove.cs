using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMove : MonoBehaviour
{
    [SerializeField]
    private Animator bombanimator = null;

    private Rigidbody2D rb;
    private float timer = 0;
    private float waitingTime;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bombanimator = GetComponent<Animator>();
    }
    void Start()
    {
        timer = 0;
        waitingTime = 2;
        BombTrans();
        rb.simulated = true;
    }
    private void OnEnable()
    {
        CheckAnime();
        rb.simulated = true;
    }
    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(Vector3.forward * 1);
        if (timer > waitingTime)
        {
            CheckBomb();
            BombTrans();
            timer = 0;
        }
        //transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    public void BombTrans()
    {
        //bombanimator.Play("New State");
        float randomX = Random.Range(2f, -2f);
        gameObject.transform.position = new Vector3(randomX, 6f, 10f);

    }
    private void CheckAnime()
    {
        switch (GameManager.Instance.CurrentUser.UnlockNum)
        {
            case 1:
                bombanimator.Play("reset0");
                break;
            case 2:
                bombanimator.Play("reset1");
                break;
            case 3:
                bombanimator.Play("reset2");
                break;
            case 4:
                bombanimator.Play("reset3");
                break;
            case 5:
                bombanimator.Play("reset4");
                break;
            case 6:
                bombanimator.Play("reset5");
                break;
            case 7:
                bombanimator.Play("reset6");
                break;
            case 8:
                bombanimator.Play("reset7");
                break;
            case 9:
                bombanimator.Play("reset8");
                break;
            case 10:
                bombanimator.Play("reset9");
                break;

        }
    }
    private void CheckBomb()
    {

        switch (GameManager.Instance.CurrentUser.UnlockNum)
        {

            case 1:
                ObjectPool.Instance.ReturnObject(PoolObjectType.Kongaltan, gameObject);
                break;
            case 2:
                ObjectPool.Instance.ReturnObject(PoolObjectType.Sylyutan, gameObject);
                break;
            case 3:
                ObjectPool.Instance.ReturnObject(PoolObjectType.Dynamite, gameObject);
                break;
            case 4:
                ObjectPool.Instance.ReturnObject(PoolObjectType.Stickybomb, gameObject);
                break;
            case 5:
                ObjectPool.Instance.ReturnObject(PoolObjectType.Bomb, gameObject);
                break;
            case 6:
                ObjectPool.Instance.ReturnObject(PoolObjectType.Cartoonbomb1, gameObject);
                break;
            case 7:
                ObjectPool.Instance.ReturnObject(PoolObjectType.Chemicalbomb, gameObject);
                break;
            case 8:
                ObjectPool.Instance.ReturnObject(PoolObjectType.Cartoonbomb2, gameObject);
                break;
            case 9:
                ObjectPool.Instance.ReturnObject(PoolObjectType.Skullbomb, gameObject);
                break;
            case 10:
                ObjectPool.Instance.ReturnObject(PoolObjectType.HeckBomb, gameObject);
                break;

        }

    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if(collision.tag == "enemy" || collision.tag == "floor")
        {
            rb.simulated = false;
            bombanimator.Play("Explosion");

            //if (collision.tag == "enemy" || collision.tag == "floor")
        }
        //rb.simulated = true;
        //CheckBomb();
        //BombTrans();
        

    }
   
}
