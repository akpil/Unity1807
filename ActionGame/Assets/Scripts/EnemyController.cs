using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float Speed;

    private Animator anim;
    private Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;
        anim.SetBool(AnimationHashList.AnimHashWalk, true);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool(AnimationHashList.AnimHashAttack, true);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
