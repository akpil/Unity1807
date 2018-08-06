using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour {

    [SerializeField]
    private Text ScoreText,
                 GameOverText,
                 RestartText,
                 HPText,
                 LifeText;

    public void SetScore(int value)
    {
        ScoreText.text = string.Format("Score : {0}",value.ToString());
    }

    public void SetGameOver()
    {
        GameOverText.text = "Game Over";
        RestartText.gameObject.SetActive(true);
    }

    public void HideGameOver()
    {
        GameOverText.text = "";
        RestartText.gameObject.SetActive(false);
    }

    public void SetPlayerHP(int value)
    {
        HPText.text = string.Format("HP: {0}", value.ToString());
    }

    public void SetPlayerLife(int value)
    {
        LifeText.text = string.Format("X {0}", value.ToString());
    }

	// Update is called once per frame
	void Update () {
		
	}
}
