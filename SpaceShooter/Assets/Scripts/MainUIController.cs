using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour {

    [SerializeField]
    private Text ScoreText,
                 GameOverText,
                 RestartText;

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

	// Update is called once per frame
	void Update () {
		
	}
}
