using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIController : MonoBehaviour {
    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private GameObject[] HPSlots;
    private int HPSlotIndex;

	// Use this for initialization
	void Start () {
        HPSlotIndex = HPSlots.Length - 1;
    }

    public void LooseHP()
    {
        HPSlots[HPSlotIndex].SetActive(false);
        HPSlotIndex--;
    }

    public void GainHP()
    {
        HPSlotIndex++;
        if (HPSlotIndex < HPSlots.Length)
        {
            HPSlots[HPSlotIndex].SetActive(true);
        }
        else
        {
            HPSlotIndex--;
        }
    }

    public void SetMoneyText(int value)
    {
        moneyText.text = value.ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
