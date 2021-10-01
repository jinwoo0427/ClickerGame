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
    private GameObject QuitPanel = null;
    private bool isQuitbutton = true;
    [SerializeField]
    private GameObject SettingPanel = null;
    private bool isSettingbutton = true;

    private bool isEffectbutton = false;
    
    private bool isBGMbutton = false;
    
    public void OnClickSoundButton()
    {
        SoundManager.Instance.Ui1Sound();
        if(isEffectbutton == true)
        {

            SoundManager.Instance.EffectMute(isEffectbutton);
            isEffectbutton = false;
        }
        else
        {
            SoundManager.Instance.EffectMute(isEffectbutton);
            isEffectbutton = true;
        }

    }

    public void OnClickBackSoundButton()
    {
        SoundManager.Instance.Ui1Sound();
        if (isBGMbutton == true)
        {

            BgmSound.Instance.BgmMute(isBGMbutton);
            isBGMbutton = false;
        }
        else
        {
            BgmSound.Instance.BgmMute(isBGMbutton);
            isBGMbutton = true;
        }

    }
    public void OnClickGameQuitNo()
    {
        SoundManager.Instance.Ui1Sound();
        isQuitbutton = false;
        OnClickQuitButtion();
    }
    public void OnClickGameQuitYes()
    {
        SoundManager.Instance.Ui1Sound();
        Application.Quit();
    }
    public void OnClickSettingButtion()
    {
        if (isSettingbutton == true)
        {
            SoundManager.Instance.Ui1Sound();
            isbombUpgradebutton = false;
            isstoreUpgradebutton = false;
            isabilityUpgradebutton = false;
            isQuitbutton = true;
            OnClickAbilityUpgradeButton();
            OnClickBombUpgradeButton();
            OnClickStoreUpgradeButton();
            SettingPanel.SetActive(true);
            isSettingbutton = false;
        }
        else
        {
            //SoundManager.Instance.Ui2Sound();
            SettingPanel.SetActive(false);
            isSettingbutton = true;
        }
    }
    public void OnClickQuitButtion()
    {
        if (isQuitbutton == true)
        {
            SoundManager.Instance.Ui1Sound();
            isSettingbutton = false;
            isbombUpgradebutton = false;
            isstoreUpgradebutton = false;
            isabilityUpgradebutton = false;
            OnClickSettingButtion();
            OnClickAbilityUpgradeButton();
            OnClickBombUpgradeButton();
            OnClickStoreUpgradeButton();
            QuitPanel.SetActive(true);
            isQuitbutton = false;
        }
        else
        {
            //SoundManager.Instance.Ui2Sound();
            QuitPanel.SetActive(false);
            isQuitbutton = true;
        }
    }
    public void OnClickAbilityUpgradeButton()
    {
            SoundManager.Instance.Ui1Sound();
        if (isabilityUpgradebutton == true)
        {
            isbombUpgradebutton = false;
            isstoreUpgradebutton = false;
            isQuitbutton = false;
            isSettingbutton = false;
            OnClickSettingButtion();
            OnClickQuitButtion();
            OnClickBombUpgradeButton();
            OnClickStoreUpgradeButton();
            AbilityScroll.SetActive(true);
            isabilityUpgradebutton = false;
        }
        else
        {
            //SoundManager.Instance.Ui2Sound();
            AbilityScroll.SetActive(false);
            isabilityUpgradebutton = true;
        }
    }
    public void OnClickStoreUpgradeButton()
    {
            SoundManager.Instance.Ui1Sound();
        if (isstoreUpgradebutton == true)
        {
            isbombUpgradebutton = false;
            isabilityUpgradebutton = false;
            isQuitbutton = false;
            isSettingbutton = false;
            OnClickSettingButtion();
            OnClickQuitButtion();
            OnClickBombUpgradeButton();
            OnClickAbilityUpgradeButton();
            StoreScroll.SetActive(true);
            isstoreUpgradebutton = false;
        }
        else
        {
            //SoundManager.Instance.Ui2Sound();
            StoreScroll.SetActive(false);
            isstoreUpgradebutton = true;
        }
    }
    public void OnClickBombUpgradeButton()
    {
            SoundManager.Instance.Ui1Sound();
        if (isbombUpgradebutton == true)
        {
            isabilityUpgradebutton = false;
            isstoreUpgradebutton = false;
            isQuitbutton = false;
            isSettingbutton = false;
            OnClickSettingButtion();
            OnClickQuitButtion();
            OnClickAbilityUpgradeButton();
            OnClickStoreUpgradeButton();
            BombScroll.SetActive(true);
            isbombUpgradebutton = false;
        }
        else 
        {
            BombScroll.SetActive(false);
            isbombUpgradebutton = true;
        }
    }

    
}
