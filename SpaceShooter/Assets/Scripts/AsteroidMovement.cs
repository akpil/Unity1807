using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField]
    private float angularSpeed, 
                        Speed;
    [SerializeField]
    private int ScoreValue;

    private GameController control;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.angularVelocity = Random.onUnitSphere * angularSpeed;
        rb.velocity = Vector3.back * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("PlayerBolt"))
        {
            other.gameObject.SetActive(false);

            if (control == null)
            {
                control = GameObject.FindGameObjectWithTag("GameController").
                                                            GetComponent<GameController>();
            }
            control.AddScore(ScoreValue);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
