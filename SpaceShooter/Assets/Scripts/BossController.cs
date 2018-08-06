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
    [SerializeField]
    private int ScoreValue;

    private bool AttackStart;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        soundControl = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void SetBoltPool(BoltPool boltP)
    {
        BoltP = boltP;
    }

    private void OnEnable()
    {
        AttackStart = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt"))
        {
            other.gameObject.SetActive(false);
            if (AttackStart)
            {
                control.AddScore(ScoreValue);
                gameObject.SetActive(false);

                soundControl.PlayEffectSound(eSoundEffectClip.expEnemy);
                GameObject effect = control.GetEffect(eEffecType.expEnemy);
                effect.transform.position = transform.position;
                effect.SetActive(true);
            }
        }
    }
}
