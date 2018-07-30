using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {
    private Rigidbody rb;
    public float Speed;
    private Vector3 rollbackAmount;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -Speed);
        rollbackAmount = new Vector3(0, 0, 40.96f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BGBumper"))
        {
            rb.position += rollbackAmount;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
