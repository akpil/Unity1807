using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour {

    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text TitleText,
                 CostText,
                 Contents;
    [SerializeField]
    private Button PurchaseButton;

    [SerializeField]
    int index;
    [SerializeField]
    bool isAbility;

	// Use this for initialization
	void Start () {
        PurchaseButton.onClick.AddListener(Upgrade);
    }

    public void SetUP(ref AbilityData data)
    {
        TitleText.text = data.title;
        CostText.text = data.currentCost.ToString();
        Contents.text = string.Format(data.contents, data.level, data.level + 1);
        icon.sprite = LobbyUIController.instance.GetIconSprite(data.inconIndex);
    }

    public void Renew(ref AbilityData data)
    {
        CostText.text = data.currentCost.ToString();
        Contents.text = string.Format(data.contents, data.level, data.level + 1);
    }

    public void Upgrade()
    {
        LobbyUIController.instance.UpgradeMenu(index, isAbility);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
