using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StorePanel : MonoBehaviour
{
    [SerializeField]
    private Text storeNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text timeText = null;
    [SerializeField]
    private Image storeImage = null;
    [SerializeField]
    private Image boost1 = null;
    [SerializeField]
    private Image boost2 = null;
    [SerializeField]
    private Image boost3 = null;


    [SerializeField]
    private Sprite[] storeSprite;

    private Store store = null;

    public void BoostEnabled()
    {
        boost1.enabled = false;
        boost2.enabled = false;
        boost3.enabled = false;
    }
    public void OnDisable()
    {
        if(store.on == true)
        {
            Invoke("Timer", store.time);
        }
    }
    public void Timer()
    {
        if (store.on == true)
        {
            if (store.StoreNumber == 0)
            {
                boost1.enabled = false;
                GameManager.Instance.CurrentUser.boostgPc = 1;
            }
            if (store.StoreNumber == 1)
            {
                boost2.enabled = false;
                GameManager.Instance.CurrentUser.boostgPs = 1;
            }
            if (store.StoreNumber == 2)
            {
                boost3.enabled = false;
                GameManager.Instance.CurrentUser.boostdamage = 1;
            }
            Debug.Log(store.time);

            store.on = false;

        }
    }
    public void SetValue(Store store)
    {
        this.store = store;
        UpdateUI();
    }
    public void UpdateUI()
    {
        storeNameText.text = store.StoreName;
        priceText.text = string.Format("{0}다이아", store.price);
        timeText.text = string.Format("({0}초)", store.time);
        storeImage.sprite = storeSprite[store.StoreNumber];
    }
    private IEnumerator Check1()
    {
        if(store.on == true)
        {
            if (store.StoreNumber == 0)
            {
                boost1.enabled = true;
                GameManager.Instance.CurrentUser.boostgPc = 10;
                yield return new WaitForSeconds(store.time);
                //Timer();
            }
            if (store.StoreNumber == 1)
            {
                boost2.enabled = true;
                GameManager.Instance.CurrentUser.boostgPs = 10;
                yield return new WaitForSeconds(store.time);
                //Timer();
            }
            if (store.StoreNumber == 2)
            {
                boost3.enabled = true;
                GameManager.Instance.CurrentUser.boostdamage = 10;
                yield return new WaitForSeconds(store.time);

                //Timer();
            }
            Timer();
        }
       
    }
    
    public void OnClickPurchase()
    {
        SoundManager.Instance.Ui1Sound();
        if (GameManager.Instance.CurrentUser.gold < store.price || store.on == true)
        {
            return;     //골드 부족하면 리턴
        }
        GameManager.Instance.CurrentUser.Diamond -= store.price;
        store.on = true;
        //Check();
        StartCoroutine(Check1());
        UpdateUI();
        
        GameManager.Instance.UI.UpdateDiaPanel();  //골드 값 업데이트

    }
}
