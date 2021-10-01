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
        abilityNameText.text = ability.AbilityName;      // 폭탄 이름
        priceText.text = string.Format("{0} 골드", ability.price);   //값 업데이트
        levelText.text = string.Format("Lv.{0}", ability.Level);    //갯수 업데이트
        abilityImage.sprite = abilitySprite[ability.AbilityNumber];     //순번

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
        SoundManager.Instance.Ui1Sound();
        if (GameManager.Instance.CurrentUser.gold < ability.price)
        {
            return;     //골드 부족하면 리턴
        }
        GameManager.Instance.CurrentUser.gold -= ability.price; // 현재 유저 골드에서 가격 빼기
        ability.price = (long)(ability.price * 1.2f);   
        ability.Level++;      // 레벨 증가
        ability.damage = (long)(ability.damage * 1.2f);
        ability.Diamond = (long)(ability.Diamond * 2.2f);
        ChDia();
        ability.goldAbility = (long)(ability.goldAbility * 1.2f);
        ability.autogold = (long)(ability.autogold * 1.2f);
        Check();
        UpdateUI();
        GameManager.Instance.UI.UpdateGoldPanel();  //골드 값 업데이트

    }
}
