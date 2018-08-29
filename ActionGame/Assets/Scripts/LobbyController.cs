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
        }
        LobbyUIController.instance.SetHP(
            AbilityController.instance.GetCurrentAbilityData((int)eAbilityTypes.HP));
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

    public void UpgradeAbility(int index)
    {
        if (PlayerDataController.instance.UseMoney(
                                AbilityController.instance.GetCurrentAbilityCost(index)))
        {
            AbilityController.instance.RenewAbilityData(index, 1);
            AbilityData data = AbilityController.instance.GetData(index);
            LobbyUIController.instance.RenewAbilityData(index, ref data);
        }
        else
        {

        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
