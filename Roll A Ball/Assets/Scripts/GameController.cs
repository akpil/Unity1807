using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int Score;
    private UIController uiControl;
    private GameObject[] pickups;

	// Use this for initialization
	void Start () {
        Score = 0;
        uiControl = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        pickups = GameObject.FindGameObjectsWithTag("PickUp");

    }

    public void AddScore(int value)
    {
        Score += value;
        uiControl.SetScoreText(Score);
        for (int i = 0; i < pickups.Length; i++)
        {
            if (pickups[i].activeInHierarchy)
            {
                Debug.Log("TTT");
                return;
            }
        }
        Debug.Log("game finish");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
