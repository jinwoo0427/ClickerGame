using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpbar : MonoBehaviour
{
    private Enemy enemy = null;
    public Enemy currentenemy { get { return enemy; } }

    public Slider hpbar;
    [SerializeField]
    private Text enemyNameText;
    [SerializeField]
    private Text hpText;
    float hping;


    public void SetValue(Enemy enemy)
    {
        this.enemy = enemy;
        UpdateEnemy();
    }
    public void UpdateEnemy()
    {
        enemyNameText.text = enemy.enemyName;
        hpText.text = string.Format("{0}", enemy.currenthp);
    }



    void Start()
    {
        //hpbar.maxValue = enemy.maxhp;
        enemy.currenthp = enemy.maxhp;
        UpdateEnemy();
    }

    void Update()
    {
        hping = (float)currentenemy.currenthp / (float)currentenemy.maxhp;
        Hp();


    }
    public void CheckHp()
    {
            currentenemy.currenthp -= GameManager.Instance.CurrentUser.damage * GameManager.Instance.CurrentUser.boostD;
        
        if (currentenemy.currenthp <= 0)
        {
            ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //switch (currentenemy.num)
            //{
            //    case 0:
            //        ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //        break;
            //    case 1:
            //        ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //        break;
            //    case 2:
            //        ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //        break;
            //    case 3:
            //        ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //        break;
            //    case 4:
            //        ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //        break;
            //    case 5:
            //        ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //        break;
            //    case 6:
            //        ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //        break;
            //    case 7:
            //        ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //        break;
            //    case 8:
            //        ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            //        break;
            //}
            GameManager.Instance.CurrentUser.Diamond += enemy.diamond;
            GameManager.Instance.CurrentUser.gold += enemy.gold;
            
            GameManager.Instance.UI.UpdateDiaPanel();
            GameManager.Instance.UI.UpdateGoldPanel();
        }

    }
    //public void HpUp()
    //{
    //    //switch (GameManager.Instance.CurrentUser.damage)
    //    //{
    //    //    case 2:
    //    //        GameManager.Instance.currentenemy.maxhp 

    //    //}

    //    if(GameManager.Instance.CurrentUser.damage >= )
    //    {

    //    }

    //}
    public void Hp()
    {
        //hpbar.value = currentenemy.currenthp / currentenemy.maxhp;
        
        hpbar.value = Mathf.Lerp(hpbar.value, hping, Time.deltaTime * 10);
        UpdateEnemy();
    }

}
