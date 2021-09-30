using UnityEngine;
using UnityEngine.UI;
using System.IO;



public class GameManager : MonoSingleton<GameManager>
{
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    [SerializeField]
    private User user = null;
    public User CurrentUser { get { return user; } }
    
    [SerializeField]
    private Ability ability = null;
    public Ability Currentability { get { return ability; } }
    [SerializeField]
    private Store store = null;
    public Store Currentstore{ get { return store; } }


    [SerializeField]
    private Enemy enemy = null;
    public Enemy currentenemy { get { return enemy; } }

    private Bomb bomb = null;
    public Bomb Currentbomb { get { return bomb; } }

    private UIManager uiManager = null;
    public UIManager UI
    {
        get
        {
            return uiManager;
        }
    }


    private void Awake()
    {

        //안드로이드 빌드시 Application.persistentDataPath
        
        SAVE_PATH = Application.dataPath + "/Save";
        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        InvokeRepeating("SaveToJson", 1f, 10f);
        InvokeRepeating("EarnGoldPerSecond", 0f, 1f); //invokerepeating 지정한 숫자까지 반복
        LoadFromJson();
        uiManager = GetComponent<UIManager>();
        CurrentUser.UnlockNum = 0;
        CreateEnemy();
    }
    
    
    public void CreateEnemy()
    {
        int randomspawn = UnityEngine.Random.Range(0, 9);
        //Debug.Log(randomspawn);
        enemy.num = randomspawn;
        
        switch (randomspawn)
        {
            case 0:
                ObjectPool.Instance.GetObject(PoolObjectType.Slime);
                UI.CreateHp(enemy.num);
                break;
            case 1:
                ObjectPool.Instance.GetObject(PoolObjectType.SlimeCow);
                UI.CreateHp(enemy.num);
                break;
            case 2:
                ObjectPool.Instance.GetObject(PoolObjectType.SlimeKing);
                UI.CreateHp(enemy.num);
                break;
            case 3:
                ObjectPool.Instance.GetObject(PoolObjectType.Babydragon);
                UI.CreateHp(enemy.num);
                break;
            case 4:
                ObjectPool.Instance.GetObject(PoolObjectType.Rabbit);
                UI.CreateHp(enemy.num);
                break;
            case 5:
                ObjectPool.Instance.GetObject(PoolObjectType.Bear);
                UI.CreateHp(enemy.num);
                break;
            case 6:
                ObjectPool.Instance.GetObject(PoolObjectType.TreeMonster);
                UI.CreateHp(enemy.num);
                break;
            case 7:
                ObjectPool.Instance.GetObject(PoolObjectType.RockMonster);
                UI.CreateHp(enemy.num);
                break;
            case 8:
                ObjectPool.Instance.GetObject(PoolObjectType.Anubis);
                UI.CreateHp(enemy.num);
                break;
            
        }
    }

    private void EarnGoldPerSecond()
    {
        user.gold += user.gPs;    //유저 골드에 폭탄 골드를 레벨만큼 곱해서 더함  
        UI.UpdateGoldPanel();

    }
    private void LoadFromJson()
    {
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true)
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }
    private void SaveToJson()
    {

        SAVE_PATH = Application.dataPath + "/Save";
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }
    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}
