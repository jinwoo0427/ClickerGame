using System.Collections;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    public Vector3 enemyPo = new Vector3(0f, -1f, 10f);   
    private EnemyHpbar enemyHpbar = null;
    

    void Start()
    {

        enemyHpbar = FindObjectOfType<EnemyHpbar>();
        gameObject.transform.position = enemyPo;
        //transform.localScale = new Vector3(25f, 24f, 0f);
    }

   public void ReturnObj()
    {
        ObjectPool.Instance.ReturnObject(PoolObjectType.Slime, gameObject);
        ObjectPool.Instance.ReturnObject(PoolObjectType.SlimeCow, gameObject);
        ObjectPool.Instance.ReturnObject(PoolObjectType.SlimeKing, gameObject);
        ObjectPool.Instance.ReturnObject(PoolObjectType.Babydragon, gameObject);
        ObjectPool.Instance.ReturnObject(PoolObjectType.Rabbit, gameObject);
        ObjectPool.Instance.ReturnObject(PoolObjectType.Bear, gameObject);
        ObjectPool.Instance.ReturnObject(PoolObjectType.TreeMonster, gameObject);
        ObjectPool.Instance.ReturnObject(PoolObjectType.RockMonster, gameObject);
        ObjectPool.Instance.ReturnObject(PoolObjectType.Anubis, gameObject);

    }
    public void Die()
    {
            if(enemyHpbar.currentenemy.currenthp <= 0)
            {
                enemyHpbar.HpUp();
                StartCoroutine(HpCool());
                GameManager.Instance.isEnemy = false;
                GameManager.Instance.Spawn();
            }
    }
    private IEnumerator HpCool()
    {
        yield return new WaitForSeconds(0.1f);
        ReturnObj();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bomb")
        {
            SoundManager.Instance.BombEffect();
            enemyHpbar.CheckHp();
            Die();
        }
    }

}
