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
    public List<Bomb> bombList = new List<Bomb>(); //ÆøÅºµé
    public List<Ability> abilityList = new List<Ability>(); //½ºÅ³
    public List<Enemy> enemyList = new List<Enemy>(); //Àû
    public List<Store> storeList = new List<Store>(); //Àû

}
