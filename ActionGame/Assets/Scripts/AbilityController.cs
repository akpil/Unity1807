using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eAbilityTypes
{
    HP, AP
}

public class AbilityController : MonoBehaviour {
    public static AbilityController instance;

    private AbilityData[] abilityDataList;

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

        // AbilityData 초기화
        abilityDataList = new AbilityData[2];
        abilityDataList[0] = new AbilityData();
        abilityDataList[0].title = "체력강화";
        abilityDataList[0].contents = "체력 레벨을 {0} 에서 {1} 로 올립니다.";
        abilityDataList[0].level = 0;
        abilityDataList[0].baseCost = 10;
        abilityDataList[0].costWeight = 1.1f;
        abilityDataList[0].inconIndex = 0;
        abilityDataList[0].baseAbilityEffect = 11;
        abilityDataList[0].currentAbilityEffect = 0;
        abilityDataList[0].effectWeight = 2;

        abilityDataList[1] = new AbilityData();
        abilityDataList[1].title = "공격력강화";
        abilityDataList[1].contents = "공경력 레벨을 {0} 에서 {1} 로 올립니다.";
        abilityDataList[1].level = 0;
        abilityDataList[1].baseCost = 15;
        abilityDataList[1].costWeight = 1.05f;
        abilityDataList[1].inconIndex = 1;
        abilityDataList[1].baseAbilityEffect = 1;
        abilityDataList[1].currentAbilityEffect = 0;
        abilityDataList[1].effectWeight = 1;
    }

    // Use this for initialization
    void Start () {
		
	}

    public int GetAbilityLength()
    {
        return abilityDataList.Length;
    }

    public AbilityData GetData(int index)
    {
        return abilityDataList[index];
    }

    public int GetCurrentAbilityData(int index)
    {
        return abilityDataList[index].currentAbilityEffect;
    }

    public int GetCurrentAbilityCost(int index)
    {
        return abilityDataList[index].currentCost;
    }

    public void RenewAbilityData(int index, int level)
    {
        abilityDataList[index].level += level;
        abilityDataList[index].currentCost = (int)(abilityDataList[index].baseCost *
                                                   Mathf.Pow(abilityDataList[index].costWeight,
                                                             abilityDataList[index].level));
        abilityDataList[index].currentAbilityEffect = abilityDataList[index].baseAbilityEffect +
                                                        abilityDataList[index].effectWeight *
                                                        abilityDataList[index].level;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
