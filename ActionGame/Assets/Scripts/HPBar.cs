using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    [SerializeField]
    private GameObject HPBarBorder;
    [SerializeField]
    private Image Bar;
    [SerializeField]
    private Text IncomeText;

    public void ShowHP(float hp)
    {
        IncomeText.gameObject.SetActive(false);
        HPBarBorder.SetActive(true);
        Bar.fillAmount = hp;
    }


    public void ShowIncome(int income)
    {
        IncomeText.text = income.ToString();
        IncomeText.gameObject.SetActive(true);
        HPBarBorder.SetActive(false);
        StartCoroutine(Sleep());
    }

    private IEnumerator Sleep()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
