using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;

    public float Speed;
    public float rot;

    public Transform BoltPos;
    public Bolt PlayerBolt;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;

        rb.velocity = new Vector3(horizontal, 0, vertical);

        rb.rotation = Quaternion.Euler(0, 0, horizontal * -rot);

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -5, 5),
                                  0,
                                  Mathf.Clamp(rb.position.z, -4, 10));

        if (Input.GetKey(KeyCode.Space))
        {
            Bolt temp = Instantiate(PlayerBolt);
            temp.transform.position = BoltPos.position;
        }
	}
}
