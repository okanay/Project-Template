using UnityEngine;

public class PlayerManager : CostumBehaviour
{
    private readonly PlayerData m_PlayerData = new PlayerData();
    
    public int GetPlayerCurrency => PlayerData.PlayerMoney;
    public int GetPlayerLevel => PlayerData.PlayerLevel;
    
    public void ChangePlayerCurrency(int value)
    {
        PlayerPrefs.SetInt("playerMoney", PlayerData.PlayerMoney + value);
        PlayerPrefs.Save();
    }
    public void ChangePlayerLevel(int value)
    {
        PlayerPrefs.SetInt("playerLevel", PlayerData.PlayerLevel + value);
        PlayerPrefs.Save();
    }
}
