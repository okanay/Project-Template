using UnityEngine;

public class PlayerData
{ 
    public static int PlayerMoney => PlayerPrefs.GetInt("playerMoney");
    public static int PlayerLevel => PlayerPrefs.GetInt("playerLevel");
}

