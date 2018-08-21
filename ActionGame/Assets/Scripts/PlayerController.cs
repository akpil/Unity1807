using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    const int MaxHPSlot = 11;
    private Animator anim;
    [SerializeField]
    private IngameUIController ui;
    [SerializeField]
    private int AP;
    private int MaxHP;
    private int currentHP;
    private int HPLooseGap;
    private int currentHPLossGap;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
    }

    public void SetData(int _MaxHP, int _AP)
    {
        MaxHP = _MaxHP;
        currentHP = MaxHP;
        HPLooseGap = MaxHP / MaxHPSlot;
        currentHPLossGap = HPLooseGap;
        AP = _AP;
    }

    public void Hit(int damage)
    {
        currentHP -= damage;
        currentHPLossGap -= damage;
        if (currentHPLossGap <= 0)
        {
            ui.LooseHP();
            currentHPLossGap += HPLooseGap;
        }

        if (currentHP <= 0)
        {
            anim.SetBool(AnimationHashList.AnimHashDead, true);
        }
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
