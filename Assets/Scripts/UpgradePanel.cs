using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoSingleton<UpgradePanel>
{
    [SerializeField]
    private Text bombNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text DiaText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Image bombImage = null;
    [SerializeField]
    private GameObject unlock = null;
    [SerializeField]
    private GameObject Diabutton = null;
    
    
    [SerializeField]
    private Sprite[] bombSprite;

    private Bomb bomb = null;

    public void SetValue(Bomb bomb)
    {
        this.bomb = bomb;
        UpdateUI();
        
    }
  
    public void UpdateUI()
    {
        UnLock();
        bombNameText.text = bomb.BombName;      // ÆøÅº ÀÌ¸§
        priceText.text = string.Format("{0} °ñµå", bomb.price);   //°ª ¾÷µ¥ÀÌÆ®
        amountText.text = string.Format("{0}", bomb.Level);    //°¹¼ö ¾÷µ¥ÀÌÆ®
        DiaText.text = string.Format("{0}", bomb.UnLockprice);    //´ÙÀÌ¾Æ°¹¼ö ¾÷µ¥ÀÌÆ®
        bombImage.sprite = bombSprite[bomb.BombNumber];     //¼ø¹ø
    }
    
    public void UnLock()
    {
        if(bomb.Level >= 1)
        {
            unlock.SetActive(false);
        }
        else
        {
            unlock.SetActive(true);
            UnLockDia();
            
        }   
    }
    private void Update()
    {
        UnLockDia();
    }
    public void UnLockDia()
    {
        if (bomb.BombNumber == GameManager.Instance.CurrentUser.UnlockNum)
        {
            Diabutton.SetActive(true);
        }
        else
        {
            Diabutton.SetActive(false);
        }
    }
    public void OnClickFirstPur()
    {
        if (GameManager.Instance.CurrentUser.Diamond < bomb.UnLockprice)
        {
            return;     //´ÙÀÌ¾Æ ºÎÁ·ÇÏ¸é ¸®ÅÏ
        }
        if(GameManager.Instance.CurrentUser.UnlockNum == bomb.BombNumber)
        {
            GameManager.Instance.CurrentUser.Diamond -= bomb.UnLockprice;
            bomb.Level++;
            UpdateUI();
            GameManager.Instance.UI.UpdateDiaPanel();
            unlock.SetActive(false);
            GameManager.Instance.CurrentUser.UnlockNum += 1;
            UnLockDia();
        }
    }
    public void OnClickPurchase()   //ÆøÅºÀ» »òÀ» °æ¿ì
    {
        if (GameManager.Instance.CurrentUser.gold < bomb.price)
        {
            return;     //°ñµå ºÎÁ·ÇÏ¸é ¸®ÅÏ
        }
        GameManager.Instance.CurrentUser.gold -= bomb.price; // ÇöÀç À¯Àú °ñµå¿¡¼­ ÆøÅº °¡°Ý »©±â
        bomb.price = (long)(bomb.price * 1.25f);    //ÆøÅº °¡°Ý 1.25¹è¾¿ Áõ°¡
        bomb.Level++;      //ÆøÅº ·¹º§ Áõ°¡
        GameManager.Instance.CurrentUser.damage += bomb.BombDamage;

        UpdateUI();         
        GameManager.Instance.UI.UpdateGoldPanel();  //°ñµå °ª ¾÷µ¥ÀÌÆ®

    }
    

}