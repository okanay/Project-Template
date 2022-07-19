using System;
using UnityEngine;

public class PlayerManager : CostumBehaviour
{
    public Player player;
    public PlayerData PlayerData = new PlayerData();
    
    public AnimationState AnimationChange;
    
    public MovementState MovementActivate;
    public MovementState MovementDeActivate;
    
    public int GetPlayerCurrency => PlayerData.PlayerMoney;
    public int GetPlayerLevel => PlayerData.PlayerLevel;
    
    // -------------------------------------------------------------Setter.
    
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
