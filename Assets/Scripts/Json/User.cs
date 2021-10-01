using System.Collections.Generic;

[System.Serializable]
public class User
{
    public string userName;

    public int UnlockNum;
    public long gold;
    public long Diamond;
    public long boostgPc;
    public long boostgPs;
    public long boostdamage;
    public long gPc;    //gold per click
    public long gPs;    //gold per click
    public long damage;    //gold per click
    public List<Bomb> bombList = new List<Bomb>(); //��ź��
    public List<Ability> abilityList = new List<Ability>(); //��ų
    public List<Enemy> enemyList = new List<Enemy>(); //��
    public List<Store> storeList = new List<Store>(); //��

}
