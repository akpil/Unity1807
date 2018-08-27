using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataController : MonoBehaviour {

    public static PlayerDataController instance;

    [SerializeField]
    private int maximumKillCount,
        HP,
        AP,
        currentMoney;
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
    }


    public void UpgradeHP()
    {
        HP++;
    }

    public void UpgradeAP()
    {
        AP++;
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
    public int GetHP()
    {
        return HP;
    }
    public int GetAP()
    {
        return AP;
    }

}
