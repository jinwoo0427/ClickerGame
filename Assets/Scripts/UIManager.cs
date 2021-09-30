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
    
    private void CreateBombPanels() // 페널 생성 함수
    {
        GameObject newPanel = null;     //패널 생성
        UpgradePanel newPanelComponent = null;   //패널에 붙을 컴포넌트 생성
        foreach (Bomb bomb in GameManager.Instance.CurrentUser.bombList)    //모든 폭탄을 다 돌때까지 한다
        {
            newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);    //업그레이드 패널을 생성한다.
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();      //패널컴포넌트에 업그레이드 패널 안에 있는 업그레이드 패널 컴포넌트를 붙인다.
            newPanelComponent.SetValue(bomb);   //bomb으로 값을 설정한다.
            newPanel.SetActive(true);   
            upgradePanels.Add(newPanelComponent);   //업그레이드 패널 리스트에 컴포넌트를 추가
            if(bomb.Level >= 1)
            {
                GameManager.Instance.CurrentUser.UnlockNum += 1;
            }

        }
        
    }
    private void CreateAbilityPanels() // 페널 생성 함수
    {
        GameObject newPanel = null;     //패널 생성
        AbilityPanel newPanelComponent = null;   //패널에 붙을 컴포넌트 생성
        foreach (Ability ability in GameManager.Instance.CurrentUser.abilityList)    //모든 기능을 다 돌때까지 한다
        {
            newPanel = Instantiate(abilityPanelTemplate, abilityPanelTemplate.transform.parent);    //업그레이드 패널을 생성한다.
            newPanelComponent = newPanel.GetComponent<AbilityPanel>();      //패널컴포넌트에 업그레이드 패널 안에 있는 업그레이드 패널 컴포넌트를 붙인다.
            newPanelComponent.SetValue(ability);
            newPanel.SetActive(true);
            abilityPanels.Add(newPanelComponent);   //업그레이드 패널 리스트에 컴포넌트를 추가    

        }

    }
    private void CreateStorePanels()
    {
        GameObject newPanel = null;     //패널 생성
        StorePanel newPanelComponent = null;   //패널에 붙을 컴포넌트 생성
        foreach (Store store in GameManager.Instance.CurrentUser.storeList)    //모든 기능을 다 돌때까지 한다
        {
            
            newPanel = Instantiate(storePanelTemplate, storePanelTemplate.transform.parent);    //업그레이드 패널을 생성한다.
            newPanelComponent = newPanel.GetComponent<StorePanel>();      //패널컴포넌트에 업그레이드 패널 안에 있는 업그레이드 패널 컴포넌트를 붙인다.
            newPanelComponent.SetValue(store);   //bomb으로 값을 설정한다.
            newPanel.SetActive(true);
            storePanels.Add(newPanelComponent);   //업그레이드 패널 리스트에 컴포넌트를 추가
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
        goldText.text = string.Format("{0}", GameManager.Instance.CurrentUser.gold);  //골드 값 업데이트
    }
    public void UpdateDiaPanel()
    {
        DiamondText.text = string.Format("{0}", GameManager.Instance.CurrentUser.Diamond);  //다이아몬드 값 업데이트
    }

}
