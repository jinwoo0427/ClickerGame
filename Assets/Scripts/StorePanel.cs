using System.Collections;
using System.Collections.Generic;
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
    private Sprite[] storeSprite;

    private Store store = null;
    

    
    public void Timer()
    {
        if (store.on == true)
        {
            foreach(Ability ability in GameManager.Instance.CurrentUser.abilityList)
            {

            if (ability.AbilityNumber == 0)
            {
                GameManager.Instance.CurrentUser.boostD = 1;
            }
            if (ability.AbilityNumber == 2)
            {
                    GameManager.Instance.CurrentUser.boostE = 1;
            }
            if (ability.AbilityNumber == 1)
            {
                    GameManager.Instance.CurrentUser.boostA = 1;
            }
            Debug.Log(store.time);
            }
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
    private void Check()
    {
        if (store.StoreNumber == 0)
            GameManager.Instance.CurrentUser.boostE = 10;
        if (store.StoreNumber == 1)
            GameManager.Instance.CurrentUser.boostA = 10;
        if (store.StoreNumber == 2)
            GameManager.Instance.CurrentUser.boostD = 10;
    }
    private void TimeCh()
    {

        Invoke("Timer", store.time);

    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.gold < store.price || store.on == true)
        {
            return;     //골드 부족하면 리턴
        }
        GameManager.Instance.CurrentUser.Diamond -= store.price;
        //store.price = (long)(store.price * 1.25f);    //가격 1.25배씩 증가
        store.on = true;
        Check();
        Invoke("Timer", store.time);
        UpdateUI();
        GameManager.Instance.UI.UpdateDiaPanel();  //골드 값 업데이트

    }
}
