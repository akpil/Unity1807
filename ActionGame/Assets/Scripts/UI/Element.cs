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

	// Use this for initialization
	void Start () {
        PurchaseButton.onClick.AddListener(TextFunction);

    }

    public void TextFunction()
    {
        Debug.Log("Button Click Test");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
