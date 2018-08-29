using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour {

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

    public void UpgradeHP(int cost)
    {
        if (PlayerDataController.instance.UseMoney(cost))
        {
            //PlayerDataController.instance.UpgradeHP();
            LobbyUIController.instance.SetMoney(PlayerDataController.instance.GetMoney());
            //LobbyUIController.instance.SetHP(PlayerDataController.instance.GetHP());
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
