using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
            PlayerDataController.instance.UpgradeHP();
            LobbyUIController.instance.SetMoney(PlayerDataController.instance.GetMoney());
            LobbyUIController.instance.SetHP(PlayerDataController.instance.GetHP());
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
