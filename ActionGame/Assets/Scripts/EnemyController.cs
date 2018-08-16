using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEnemyState {
    SeekPlayer, FindPlayer, AttackPlayer
};

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float Speed;

    private eEnemyState state;

    private Animator anim;
    private Rigidbody2D rb;
    private PlayerController player;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}

    private void OnEnable()
    {
        player = null;
        state = eEnemyState.SeekPlayer;
        StartCoroutine(EnemyStateM());
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
            }
            yield return pointFive;
        }
    }

    public void Attack()
    {
        Debug.Log("zAttack!!!");
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
