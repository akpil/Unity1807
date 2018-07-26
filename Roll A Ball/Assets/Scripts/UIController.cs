using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text ScoreText;

	// Use this for initialization
	void Start () {
        ScoreText.text = "Score : 0";
    }

    public void SetScoreText(int value)
    {
        ScoreText.text = string.Format("Score : {0}", value.ToString());
    }

	// Update is called once per frame
	void Update () {
		
	}
}
