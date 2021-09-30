using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityPanel : MonoBehaviour
{
    [SerializeField]
    private Text abilityNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text levelText = null;
    [SerializeField]
    private Image abilityImage = null;
    
    [SerializeField]
    private Sprite[] abilitySprite;

    [SerializeField]
    private Ability ability = null;
    public Ability Currentability { get { return ability; } }
    public void SetValue(Ability ability)
    {
        this.ability= ability;
        UpdateUI();

    }

    public void UpdateUI()
    {
        abilityNameText.text = ability.AbilityName;      // ��ź �̸�
        priceText.text = string.Format("{0} ���", ability.price);   //�� ������Ʈ
        levelText.text = string.Format("Lv.{0}", ability.Level);    //���� ������Ʈ
        abilityImage.sprite = abilitySprite[ability.AbilityNumber];     //����

    }

    public void Check()
    {
        GameManager.Instance.CurrentUser.gPc += ability.goldAbility;
        GameManager.Instance.CurrentUser.gPs += ability.autogold;
        GameManager.Instance.CurrentUser.damage += ability.damage;
    }
    public void ChDia()
    {
        foreach(Enemy enemy in GameManager.Instance.CurrentUser.enemyList)
        {
            enemy.diamond += ability.Diamond;
        }    

    }
    public void OnClickPurchase()   
    {
        if (GameManager.Instance.CurrentUser.gold < ability.price)
        {
            return;     //��� �����ϸ� ����
        }
        GameManager.Instance.CurrentUser.gold -= ability.price; // ���� ���� ��忡�� ���� ����
        ability.price = (long)(ability.price * 1.25f);    //���� 1.25�辿 ����
        ability.Level++;      // ���� ����
        ability.damage = (long)(ability.damage * 1.25f);
        ability.Diamond = (long)(ability.Diamond * 1.1f);
        ChDia();
        ability.goldAbility = (long)(ability.goldAbility * 1.25f);
        ability.autogold = (long)(ability.autogold * 1.25f);
        Check();
        UpdateUI();
        GameManager.Instance.UI.UpdateGoldPanel();  //��� �� ������Ʈ

    }
}