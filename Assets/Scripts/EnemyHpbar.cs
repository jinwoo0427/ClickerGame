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
    [SerializeField]
    private DamageText damageTextTemplate = null;
    [SerializeField]
    private Transform pool = null;
    private Vector3 vec;
    
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
        float randomX = Random.Range(4f, -5f);
        float randomY = Random.Range(2f, 3f);
        vec = new Vector3(randomX, randomY, 10f);
        DamageText newText = null;
        if (pool.childCount > 0)
        {
            newText = pool.GetChild(0).GetComponent<DamageText>();
        }
        else
        {
            newText = Instantiate(damageTextTemplate, damageTextTemplate.transform.parent);
        }

        newText.Show(vec);

        if (currentenemy.currenthp <= 0)
        {
            ObjectPool.Instance.ReturnObject(PoolObjectType.slider, GameManager.Instance.UI.newSlider);
            
            GameManager.Instance.CurrentUser.Diamond += enemy.diamond;
            GameManager.Instance.CurrentUser.gold += enemy.gold;
            
            GameManager.Instance.UI.UpdateDiaPanel();
            GameManager.Instance.UI.UpdateGoldPanel();
        }

    }
    public void HpUp()
    {
        enemy.maxhp *= (long)1.25f;

    }
    public void Hp()
    {
        //hpbar.value = currentenemy.currenthp / currentenemy.maxhp;
        
        hpbar.value = Mathf.Lerp(hpbar.value, hping, Time.deltaTime * 10);
        UpdateEnemy();
    }

}
