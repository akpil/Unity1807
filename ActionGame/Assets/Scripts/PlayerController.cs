using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;
    private int animHashAttack;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        animHashAttack = Animator.StringToHash("IsAttack");

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool(AnimationHashList.AnimHashAttack, true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool(AnimationHashList.AnimHashAttack, false);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool(AnimationHashList.AnimHashDead, true);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool(AnimationHashList.AnimHashDead, false);
        }
	}
}
