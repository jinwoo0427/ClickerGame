using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text goldText = null;
    [SerializeField]
    private Text DiamondText = null;
    //[SerializeField]
    //private Animator beakerAnimator = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;
    private List<UpgradePanel> upgradePanels = new List<UpgradePanel>();
    
    [SerializeField]
    private GameObject abilityPanelTemplate = null;
    private List<AbilityPanel> abilityPanels = new List<AbilityPanel>();
    [SerializeField]
    private GameObject storePanelTemplate = null;
    private List<StorePanel> storePanels = new List<StorePanel>();
    [SerializeField]
    private GameObject hpbar = null;
    private List<EnemyHpbar> hpslider = new List<EnemyHpbar>();

    //[SerializeField]
    // private EnergyText energyTextTemplate = null;
    //[SerializeField]
    //private Transform pool = null;



    void Start()
    {
        UpdateDiaPanel();
        UpdateGoldPanel();
        CreateBombPanels();
        CreateAbilityPanels();
        CreateStorePanels();

    }
       public GameObject newSlider = null;
       public EnemyHpbar newSliderComponent = null;
    public void CreateHp(int i)
    {
       
        switch (i)
        {
            case 0:
                newSlider = Instantiate(hpbar, hpbar.transform.parent);
                newSliderComponent = newSlider.GetComponent<EnemyHpbar>();
                newSliderComponent.SetValue(GameManager.Instance.CurrentUser.enemyList[i]);
                newSlider.SetActive(true);
                hpslider.Add(newSliderComponent);
                break;
            case 1:
                newSlider = Instantiate(hpbar, hpbar.transform.parent);
                newSliderComponent = newSlider.GetComponent<EnemyHpbar>();
                newSliderComponent.SetValue(GameManager.Instance.CurrentUser.enemyList[i]);
                newSlider.SetActive(true);
                hpslider.Add(newSliderComponent);
                break;
            case 2:
                newSlider = Instantiate(hpbar, hpbar.transform.parent);
                newSliderComponent = newSlider.GetComponent<EnemyHpbar>();
                newSliderComponent.SetValue(GameManager.Instance.CurrentUser.enemyList[i]);
                newSlider.SetActive(true);
                hpslider.Add(newSliderComponent);
                break;
            case 3:
                newSlider = Instantiate(hpbar, hpbar.transform.parent);
                newSliderComponent = newSlider.GetComponent<EnemyHpbar>();
                newSliderComponent.SetValue(GameManager.Instance.CurrentUser.enemyList[i]);
                newSlider.SetActive(true);
                hpslider.Add(newSliderComponent);
                break;
            case 4:
                newSlider = Instantiate(hpbar, hpbar.transform.parent);
                newSliderComponent = newSlider.GetComponent<EnemyHpbar>();
                newSliderComponent.SetValue(GameManager.Instance.CurrentUser.enemyList[i]);
                newSlider.SetActive(true);
                hpslider.Add(newSliderComponent);
                break;
            case 5:
                newSlider = Instantiate(hpbar, hpbar.transform.parent);
                newSliderComponent = newSlider.GetComponent<EnemyHpbar>();
                newSliderComponent.SetValue(GameManager.Instance.CurrentUser.enemyList[i]);
                newSlider.SetActive(true);
                hpslider.Add(newSliderComponent);
                break;
            case 6:
                newSlider = Instantiate(hpbar, hpbar.transform.parent);
                newSliderComponent = newSlider.GetComponent<EnemyHpbar>();
                newSliderComponent.SetValue(GameManager.Instance.CurrentUser.enemyList[i]);
                newSlider.SetActive(true);
                hpslider.Add(newSliderComponent);
                break;
            case 7:
                newSlider = Instantiate(hpbar, hpbar.transform.parent);
                newSliderComponent = newSlider.GetComponent<EnemyHpbar>();
                newSliderComponent.SetValue(GameManager.Instance.CurrentUser.enemyList[i]);
                newSlider.SetActive(true);
                hpslider.Add(newSliderComponent);
                break;
            case 8:
                newSlider = Instantiate(hpbar, hpbar.transform.parent);
                newSliderComponent = newSlider.GetComponent<EnemyHpbar>();
                newSliderComponent.SetValue(GameManager.Instance.CurrentUser.enemyList[i]);
                newSlider.SetActive(true);
                hpslider.Add(newSliderComponent);
                break;

        }

    }
    
    private void CreateBombPanels() // ��� ���� �Լ�
    {
        GameObject newPanel = null;     //�г� ����
        UpgradePanel newPanelComponent = null;   //�гο� ���� ������Ʈ ����
        foreach (Bomb bomb in GameManager.Instance.CurrentUser.bombList)    //��� ��ź�� �� �������� �Ѵ�
        {
            newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);    //���׷��̵� �г��� �����Ѵ�.
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();      //�г�������Ʈ�� ���׷��̵� �г� �ȿ� �ִ� ���׷��̵� �г� ������Ʈ�� ���δ�.
            newPanelComponent.SetValue(bomb);   //bomb���� ���� �����Ѵ�.
            newPanel.SetActive(true);   
            upgradePanels.Add(newPanelComponent);   //���׷��̵� �г� ����Ʈ�� ������Ʈ�� �߰�
            if(bomb.Level >= 1)
            {
                GameManager.Instance.CurrentUser.UnlockNum += 1;
            }

        }
        
    }
    private void CreateAbilityPanels() // ��� ���� �Լ�
    {
        GameObject newPanel = null;     //�г� ����
        AbilityPanel newPanelComponent = null;   //�гο� ���� ������Ʈ ����
        foreach (Ability ability in GameManager.Instance.CurrentUser.abilityList)    //��� ����� �� �������� �Ѵ�
        {
            newPanel = Instantiate(abilityPanelTemplate, abilityPanelTemplate.transform.parent);    //���׷��̵� �г��� �����Ѵ�.
            newPanelComponent = newPanel.GetComponent<AbilityPanel>();      //�г�������Ʈ�� ���׷��̵� �г� �ȿ� �ִ� ���׷��̵� �г� ������Ʈ�� ���δ�.
            newPanelComponent.SetValue(ability);
            newPanel.SetActive(true);
            abilityPanels.Add(newPanelComponent);   //���׷��̵� �г� ����Ʈ�� ������Ʈ�� �߰�    

        }

    }
    private void CreateStorePanels()
    {
        GameObject newPanel = null;     //�г� ����
        StorePanel newPanelComponent = null;   //�гο� ���� ������Ʈ ����
        foreach (Store store in GameManager.Instance.CurrentUser.storeList)    //��� ����� �� �������� �Ѵ�
        {
            
            newPanel = Instantiate(storePanelTemplate, storePanelTemplate.transform.parent);    //���׷��̵� �г��� �����Ѵ�.
            newPanelComponent = newPanel.GetComponent<StorePanel>();      //�г�������Ʈ�� ���׷��̵� �г� �ȿ� �ִ� ���׷��̵� �г� ������Ʈ�� ���δ�.
            newPanelComponent.SetValue(store);   //bomb���� ���� �����Ѵ�.
            newPanel.SetActive(true);
            storePanels.Add(newPanelComponent);   //���׷��̵� �г� ����Ʈ�� ������Ʈ�� �߰�
            store.on = false;
        }
    }
    public void CreateBomb()
    {


        switch (GameManager.Instance.CurrentUser.UnlockNum)
        {
            case 1:
                ObjectPool.Instance.GetObject(PoolObjectType.Kongaltan);

                break;
            case 2:
                ObjectPool.Instance.GetObject(PoolObjectType.Sylyutan);
                break;
            case 3:
                ObjectPool.Instance.GetObject(PoolObjectType.Dynamite);
                break;
            case 4:
                ObjectPool.Instance.GetObject(PoolObjectType.Stickybomb);
                break;
            case 5:
                ObjectPool.Instance.GetObject(PoolObjectType.Bomb);
                break;
            case 6:
                ObjectPool.Instance.GetObject(PoolObjectType.Cartoonbomb1);
                break;
            case 7:
                ObjectPool.Instance.GetObject(PoolObjectType.Chemicalbomb);
                break;
            case 8:
                ObjectPool.Instance.GetObject(PoolObjectType.Cartoonbomb2);
                break;
            case 9:
                ObjectPool.Instance.GetObject(PoolObjectType.Skullbomb);
                break;
            case 10:
                ObjectPool.Instance.GetObject(PoolObjectType.HeckBomb);
                break;
        }
    }
    public void OnClickbomb()
    {
       
        GameManager.Instance.CurrentUser.gold += GameManager.Instance.CurrentUser.gPc * GameManager.Instance.CurrentUser.boostE;


        UpdateGoldPanel();
        CreateBomb();

        
        //beakerAnimator.Play("Click");

        //energytext newtext = null;

        //if (pool.childcount > 0)
        //{
        //    newtext = pool.getchild(0).getcomponent<energytext>();
        //}
        //else
        //{
        //    newtext = instantiate(energytexttemplate, energytexttemplate.transform.parent);
        //}

        //newtext.show(input.mouseposition);



    }

    public void UpdateGoldPanel()
    {
        goldText.text = string.Format("{0}", GameManager.Instance.CurrentUser.gold);  //��� �� ������Ʈ
    }
    public void UpdateDiaPanel()
    {
        DiamondText.text = string.Format("{0}", GameManager.Instance.CurrentUser.Diamond);  //���̾Ƹ�� �� ������Ʈ
    }

}
