using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    private Rigidbody rb;

    [SerializeField]
    private Transform BoltPos;
    [SerializeField]
    private BoltPool BoltP;
    [SerializeField]
    private float Speed;

    private GameController control;
    private SoundController soundControl;
    private MainUIController UIcontrol;
    [SerializeField]
    private int ScoreValue;

    private bool AttackStart;

    [SerializeField]
    private int MaxHp;
    private int currentHP;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        soundControl = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        UIcontrol = GameObject.FindGameObjectWithTag("UI").GetComponent<MainUIController>();
    }

    public void SetBoltPool(BoltPool boltP)
    {
        BoltP = boltP;
    }

    private void OnEnable()
    {
        AttackStart = false;
        currentHP = MaxHp;
        UIcontrol.SetHP((float)currentHP / MaxHp);
        StartCoroutine(BossPhase());
    }

    private IEnumerator BossPhase()
    {
        rb.velocity = Vector3.back * Speed;

        WaitForSeconds pointOne = new WaitForSeconds(.1f);
        WaitForSeconds pointFive = new WaitForSeconds(.5f);
        WaitForSeconds one = new WaitForSeconds(1);
        WaitForSeconds twoPointFive = new WaitForSeconds(2.5f);
        WaitForSeconds five = new WaitForSeconds(5);
        Coroutine AutoShot;

        while (rb.position.z > 12.2f)
        {
            yield return pointOne;
        }
        rb.velocity = Vector3.zero;
        yield return one;
        AttackStart = true;

        while (true)
        {
            rb.velocity = Vector3.left * Speed;
            AutoShot = StartCoroutine(AutoShoot());
            yield return twoPointFive;
            StopCoroutine(AutoShot);
            rb.velocity = Vector3.zero;
            yield return pointFive;

            rb.velocity = Vector3.right * Speed;
            AutoShot = StartCoroutine(AutoShoot());
            yield return five;
            StopCoroutine(AutoShot);
            rb.velocity = Vector3.zero;
            yield return pointFive;

            rb.velocity = Vector3.left * Speed;
            AutoShot = StartCoroutine(AutoShoot());
            yield return twoPointFive;
            StopCoroutine(AutoShot);
            rb.velocity = Vector3.zero;
            yield return one;

        }
    }

    private IEnumerator AutoShoot()
    {
        WaitForSeconds pointFive = new WaitForSeconds(.5f);
        while (true)
        {
            yield return pointFive;
            Bolt bullet = BoltP.GetFromPool();
            bullet.transform.position = BoltPos.position;
            bullet.transform.rotation = BoltPos.rotation;
            bullet.gameObject.SetActive(true);
            soundControl.PlayEffectSound(eSoundEffectClip.shotEnemy);
        }
    }

    public void Bomb()
    {
        currentHP /= 2;
        UIcontrol.SetHP((float)currentHP / MaxHp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt"))
        {
            other.gameObject.SetActive(false);
            if (AttackStart)
            {
                if (currentHP > 0)
                {
                    currentHP--;
                }
                else
                {
                    control.AddScore(ScoreValue);
                    control.BossDead();
                    gameObject.SetActive(false);

                    soundControl.PlayEffectSound(eSoundEffectClip.expEnemy);
                    GameObject effect = control.GetEffect(eEffecType.expEnemy);
                    effect.transform.position = transform.position;
                    effect.SetActive(true);
                }
                UIcontrol.SetHP((float)currentHP / MaxHp);
            }
        }
    }
}
