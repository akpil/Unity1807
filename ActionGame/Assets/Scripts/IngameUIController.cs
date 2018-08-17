using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIController : MonoBehaviour {
    [SerializeField]
    private Text moneyText;
	// Use this for initialization
	void Start () {
		
	}

    public void SetMoneyText(int value)
    {
        moneyText.text = value.ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
