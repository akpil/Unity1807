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

    [SerializeField]
    private Element[] AbilityListArr;

    [SerializeField]
    private Sprite[] abilitySpriteList;

    private void Awake()
    {
        // sprite list load
        abilitySpriteList = Resources.LoadAll<Sprite>("UI/AbilityIcons");

        instance = this;
    }

    public Sprite GetIconSprite(int index)
    {
        return abilitySpriteList[index];
    }

    void Start()
    {
    }

    public void SetupAbilityData(int index, ref AbilityData data)
    {
        AbilityListArr[index].SetUP(ref data);
    }

    public void RenewAbilityData(int index, ref AbilityData data)
    {
        AbilityListArr[index].Renew(ref data);
    }

    public void SetMoney(int value)
    {
        moneyText.text = value.ToString();
    }

    public void SetHP(int value)
    {
        HPText.text = value.ToString();
    }

    public void UpgradeMenu(int index, bool isAbility)
    {
        if (isAbility)
        {
            LobbyController.instance.UpgradeAbility(index);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
