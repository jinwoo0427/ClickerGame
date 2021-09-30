using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemymove : MonoBehaviour
{
    private Vector3 enemyPo = new Vector3(0f, -2f, 10f);   
    private EnemyHpbar enemyHpbar = null;
    private Animator animator = null;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyHpbar = FindObjectOfType<EnemyHpbar>();
        gameObject.transform.position = enemyPo;
        //transform.localScale = new Vector3(25f, 24f, 0f);
    }

   public void ReturnObj()
    {

        switch (GameManager.Instance.currentenemy.num)
        {
            case 0:
                ObjectPool.Instance.GetObject(PoolObjectType.cartooneffect);
                ObjectPool.Instance.ReturnObject(PoolObjectType.Slime, gameObject);
                break;
            case 1:
                ObjectPool.Instance.GetObject(PoolObjectType.cartooneffect);
                ObjectPool.Instance.ReturnObject(PoolObjectType.SlimeCow, gameObject);
                break;
            case 2:
                ObjectPool.Instance.GetObject(PoolObjectType.cartooneffect);
                ObjectPool.Instance.ReturnObject(PoolObjectType.SlimeKing, gameObject);
                break;
            case 3:
                ObjectPool.Instance.GetObject(PoolObjectType.cartooneffect);
                ObjectPool.Instance.ReturnObject(PoolObjectType.Babydragon, gameObject);
                break;
            case 4:
                ObjectPool.Instance.GetObject(PoolObjectType.cartooneffect);
                ObjectPool.Instance.ReturnObject(PoolObjectType.Rabbit, gameObject);
                break;
            case 5:
                ObjectPool.Instance.GetObject(PoolObjectType.cartooneffect);
                ObjectPool.Instance.ReturnObject(PoolObjectType.Bear, gameObject);
                break;
            case 6:
                ObjectPool.Instance.GetObject(PoolObjectType.cartooneffect);
                ObjectPool.Instance.ReturnObject(PoolObjectType.TreeMonster, gameObject);
                break;
            case 7:
                ObjectPool.Instance.GetObject(PoolObjectType.cartooneffect);
                ObjectPool.Instance.ReturnObject(PoolObjectType.RockMonster, gameObject);
                break;
            case 8:
                ObjectPool.Instance.GetObject(PoolObjectType.cartooneffect);
                ObjectPool.Instance.ReturnObject(PoolObjectType.Anubis, gameObject);
                break;

        }
    }
    public void Die()
    {
            if(enemyHpbar.currentenemy.currenthp <= 0)
            {
                
                ReturnObj();
                GameManager.Instance.CreateEnemy();
            }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bomb")
        {
            enemyHpbar.CheckHp();
            Die();
        }
    }

}
