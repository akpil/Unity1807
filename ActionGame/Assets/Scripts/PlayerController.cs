using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;
    [SerializeField]
    private int AP;
    private int MaxHP;
    private int currentHP;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
    }

    public void Hit(int damage)
    {
        currentHP -= damage;
    }

    public void AttackTarget(GameObject target)
    {
        target.SendMessage("Hit", AP);
    }

    public void AttackFinish()
    {
        anim.SetBool(AnimationHashList.AnimHashAttack, false);
    }

    public void LookRight()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void LookLeft()
    {
        transform.rotation = Quaternion.Euler(Vector3.up * 180);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool(AnimationHashList.AnimHashAttack, true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LookLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LookRight();
        }
    }
}
