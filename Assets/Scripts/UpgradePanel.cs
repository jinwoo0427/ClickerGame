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
        bombNameText.text = bomb.BombName;      // ��ź �̸�
        priceText.text = string.Format("{0} ���", bomb.price);   //�� ������Ʈ
        amountText.text = string.Format("{0}", bomb.Level);    //���� ������Ʈ
        DiaText.text = string.Format("{0}", bomb.UnLockprice);    //���̾ư��� ������Ʈ
        bombImage.sprite = bombSprite[bomb.BombNumber];     //����
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
            return;     //���̾� �����ϸ� ����
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
    public void OnClickPurchase()   //��ź�� ���� ���
    {
        if (GameManager.Instance.CurrentUser.gold < bomb.price)
        {
            return;     //��� �����ϸ� ����
        }
        GameManager.Instance.CurrentUser.gold -= bomb.price; // ���� ���� ��忡�� ��ź ���� ����
        bomb.price = (long)(bomb.price * 1.25f);    //��ź ���� 1.25�辿 ����
        bomb.Level++;      //��ź ���� ����
        GameManager.Instance.CurrentUser.damage += bomb.BombDamage;

        UpdateUI();         
        GameManager.Instance.UI.UpdateGoldPanel();  //��� �� ������Ʈ

    }
    

}