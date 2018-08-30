using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour {
    public static LobbyController instance;

    private void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start () {
        StartCoroutine(Init());
	}

    private IEnumerator Init()
    {
        WaitForSeconds point2 = new WaitForSeconds(.2f);
        while (!PlayerDataController.instance.IsLoadFinish())
        {
            yield return point2;
        }
        for (int i = 0; i < AbilityController.instance.GetAbilityLength() ; i++)
        {
            AbilityData data = AbilityController.instance.GetData(i);
            LobbyUIController.instance.SetupAbilityData(i, ref data);
            switch (data.type)
            {
                case eAbilityTypes.HP:
                    LobbyUIController.instance.SetHP(data.currentAbilityEffect);
                    break;
                default:
                    Debug.Log(string.Format("unimplemented ability type : {0} ", data.type));
                    break;
            }
        }
        LobbyUIController.instance.SetMoney(PlayerDataController.instance.GetMoney());
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void AddMoney(int value)
    {
        PlayerDataController.instance.AddMoney(value);
        LobbyUIController.instance.SetMoney(PlayerDataController.instance.GetMoney());
    }

    public bool UseMoney(int cost)
    {
        bool result;
        result = PlayerDataController.instance.UseMoney(cost);
        LobbyUIController.instance.SetMoney(PlayerDataController.instance.GetMoney());
        return result;
    }

    public void UpgradeAbility(int index)
    {
        if (UseMoney(AbilityController.instance.GetCurrentAbilityCost(index)))
        {
            AbilityController.instance.RenewAbilityData(index, 1);
            AbilityData RenewedAbility = AbilityController.instance.GetData(index);
            LobbyUIController.instance.RenewAbilityData(index, ref RenewedAbility);
            switch (RenewedAbility.type)
            {
                case eAbilityTypes.HP:
                    LobbyUIController.instance.SetHP(RenewedAbility.currentAbilityEffect);
                    break;
                case eAbilityTypes.AP:
                    break;
                default:
                    break;
            }
        }
        else
        {

        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
