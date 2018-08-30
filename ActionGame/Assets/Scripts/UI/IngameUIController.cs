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

    [SerializeField]
    private GameObject StageResultWindow, NewMaxScoreImage;
    [SerializeField]
    private Text StageMoneyText, StageKillCountText, MaxKillCount;

	// Use this for initialization
	void Start () {
        HPSlotIndex = HPSlots.Length - 1;
        NewMaxScoreImage.SetActive(false);
    }

    public void LooseHP()
    {
        if (HPSlotIndex < 0)
        {
            return;
        }
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

    public void ShowNewRecord()
    {
        NewMaxScoreImage.SetActive(true);
    }

    public void ShowResultWindow(int money, int killCount, int maxKillCount)
    {
        StageMoneyText.text = money.ToString();
        StageKillCountText.text = killCount.ToString();
        MaxKillCount.text = maxKillCount.ToString();
        StageResultWindow.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
