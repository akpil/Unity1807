using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEnemyState {
    SeekPlayer, FindPlayer, AttackPlayer, Dead
};

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float Speed;

    private eEnemyState state;

    private Animator anim;
    private Rigidbody2D rb;
    private PlayerController player;

    private int MaxHP;
    private int currentHP;
    private int AP;
    private int income;

    private GameController control;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void SetData(int hp, int money)
    {
        MaxHP = hp;
        currentHP = MaxHP;
        AP = 1;
        income = money;
        StartCoroutine(EnemyStateM());
    }

    private void OnEnable()
    {
        anim.SetBool(AnimationHashList.AnimHashDead, false);
        player = null;
        state = eEnemyState.SeekPlayer;
    }

    public void Hit(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            state = eEnemyState.Dead;
        }
    }

    private IEnumerator EnemyStateM()
    {
        WaitForSeconds pointFive = new WaitForSeconds(.5f);
        WaitForSeconds one = new WaitForSeconds(1);
        while (true)
        {
            switch (state)
            {
                case eEnemyState.SeekPlayer:
                    rb.velocity = transform.right * Speed;
                    anim.SetBool(AnimationHashList.AnimHashWalk, true);
                    break;
                case eEnemyState.FindPlayer:
                    anim.SetBool(AnimationHashList.AnimHashWalk, false);
                    state = eEnemyState.AttackPlayer;
                    break;
                case eEnemyState.AttackPlayer:
                    anim.SetBool(AnimationHashList.AnimHashAttack, true);
                    yield return one;
                    break;
                case eEnemyState.Dead:
                    anim.SetBool(AnimationHashList.AnimHashDead, true);
                    control.AddMoney(income);
                    //TODO 스코어 업데이트 등등
                    break;
                default:
                    Debug.Log("구현되지 않은 스테이트입니다.");
                    break;
            }
            yield return pointFive;
            if (anim.GetBool(AnimationHashList.AnimHashDead))
            {
                yield return one;
                gameObject.SetActive(false);
                break;
            }
        }
    }

    public void Attack()
    {
        anim.SetBool(AnimationHashList.AnimHashAttack, false);
        player.Hit(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            state = eEnemyState.FindPlayer;
            player = collision.gameObject.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
