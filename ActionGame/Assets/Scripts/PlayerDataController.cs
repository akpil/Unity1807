using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataController : MonoBehaviour {

    public static PlayerDataController instance;

    [SerializeField]
    private int maximumKillCount,
        currentMoney;
    [SerializeField]
    int[] abilityLevels;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        SetNewData();
    }

    void SetNewData()
    {
        maximumKillCount = 0;
        currentMoney = 0;
        abilityLevels = new int[2];
        for (int i = 0; i < abilityLevels.Length; i++)
        {
            abilityLevels[i] = 0;
        }
    }


    public void UpgradeAbility(int index)
    {
        abilityLevels[index]++;
    }


    public void AddMoney(int value)
    {
        if (value >= 0)
        {
            currentMoney += value;
        }
        else
        {
            Debug.Log(string.Format("add money fail money value is {0}", value));
        }
    }

    public bool UseMoney(int value)
    {
        if (value >= 0)
        {
            if (currentMoney >= value)
            {
                currentMoney -= value;
                return true;
            }
            else
            {
                Debug.Log(string.Format("use money fail value is way to much"));
            }
        }
        else
        {
            Debug.Log(string.Format("use money fail money value is {0}", value));
        }
        return false;
    }

    public int GetMoney()
    {
        return currentMoney;
    }
    public int GetAbilityLevel(int index)
    {
        return abilityLevels[index];
    }
}
