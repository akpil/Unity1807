using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour {

    public Vector3 rotateAngle;
    private GameController control;

	// Use this for initialization
	void Start () {
        GameObject controllerObj = GameObject.FindGameObjectWithTag("GameController");
        control = controllerObj.GetComponent<GameController>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            control.AddScore(1);
        }

    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(rotateAngle * Time.deltaTime);
	}
}
