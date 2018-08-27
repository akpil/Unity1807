using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIController : MonoBehaviour {
    public static LobbyUIController instance;

    [SerializeField]
    private Button GameStartButton;
    [SerializeField]
    private Text moneyText,
                 HPText,
                 APText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
    }

    public void SetMoney(int value)
    {
        moneyText.text = value.ToString();
    }

    public void SetHP(int value)
    {
        HPText.text = value.ToString();
    }

    public void UpgradeManue(int index)
    {
        //TODO HP AP Upgrade function
        //reflect UI view
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
