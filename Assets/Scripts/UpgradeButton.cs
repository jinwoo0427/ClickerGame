using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    
    [SerializeField]
    private GameObject BombScroll = null;
    private bool isbombUpgradebutton = true;
    [SerializeField]
    private GameObject AbilityScroll = null;
    private bool isabilityUpgradebutton = true;
    [SerializeField]
    private GameObject StoreScroll = null;
    private bool isstoreUpgradebutton = true;
    [SerializeField]
    private GameObject SettingPanel = null;
    private bool issettingbutton = true;


    public void OnClickSettingButtion()
    {
        if (issettingbutton == true)
        {
            SoundManager.Instance.UiSound();
            isbombUpgradebutton = false;
            isstoreUpgradebutton = false;
            isabilityUpgradebutton = false;
            OnClickAbilityUpgradeButton();
            OnClickBombUpgradeButton();
            OnClickStoreUpgradeButton();
            SettingPanel.SetActive(true);
            issettingbutton = false;
        }
        else
        {
            SoundManager.Instance.UiendSound();
            SettingPanel.SetActive(false);
            issettingbutton = true;
        }
    }
    public void OnClickAbilityUpgradeButton()
    {
        if (isabilityUpgradebutton == true)
        {
            SoundManager.Instance.UiSound();
            isbombUpgradebutton = false;
            isstoreUpgradebutton = false;
            issettingbutton = false;
            OnClickSettingButtion();
            OnClickBombUpgradeButton();
            OnClickStoreUpgradeButton();
            AbilityScroll.SetActive(true);
            isabilityUpgradebutton = false;
        }
        else
        {
            SoundManager.Instance.UiendSound();
            AbilityScroll.SetActive(false);
            isabilityUpgradebutton = true;
        }
    }
    public void OnClickStoreUpgradeButton()
    {
        if (isstoreUpgradebutton == true)
        {
            SoundManager.Instance.UiSound();
            isbombUpgradebutton = false;
            isabilityUpgradebutton = false;
            issettingbutton = false;
            OnClickSettingButtion();
            OnClickBombUpgradeButton();
            OnClickAbilityUpgradeButton();
            StoreScroll.SetActive(true);
            isstoreUpgradebutton = false;
        }
        else
        {
            SoundManager.Instance.UiendSound();
            StoreScroll.SetActive(false);
            isstoreUpgradebutton = true;
        }
    }
    public void OnClickBombUpgradeButton()
    {
        if (isbombUpgradebutton == true)
        {
            SoundManager.Instance.UiSound();
            isabilityUpgradebutton = false;
            isstoreUpgradebutton = false;
            issettingbutton = false;
            OnClickSettingButtion();
            OnClickAbilityUpgradeButton();
            OnClickStoreUpgradeButton();
            BombScroll.SetActive(true);
            isbombUpgradebutton = false;
        }
        else 
        {
            SoundManager.Instance.UiendSound();
            BombScroll.SetActive(false);
            isbombUpgradebutton = true;
        }
    }
    
}
