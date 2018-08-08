using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;

    public float Speed;
    public float rot;

    public Transform BoltPos;
    [SerializeField]
    private BoltPool BoltP;
    public float FireRate;
    private float currentFrieRate;
    [SerializeField]
    private int MaxHP;
    private int currentHP;
    private SoundController soundControl;
    private GameController control;
    private MainUIController uiControl;

    private int boltSize;
    private float powerUpTimer;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        currentFrieRate = 0;
        boltSize = 1;
        soundControl = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        uiControl = GameObject.FindGameObjectWithTag("UI").GetComponent<MainUIController>();
    }

    private void OnEnable()
    {
        currentHP = MaxHP;
        uiControl.SetPlayerHP(currentHP);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            currentHP--;
            uiControl.SetPlayerHP(currentHP);
            if (currentHP <= 0)
            {
                gameObject.SetActive(false);
                soundControl.PlayEffectSound(eSoundEffectClip.expPlayer);
                GameObject effect = control.GetEffect(eEffecType.expPlayer);
                effect.transform.position = transform.position;
                effect.SetActive(true);
                control.GameOver();
            }
        }
    }

    public void PowerUP()
    {
        boltSize = 3;
        powerUpTimer += 3;
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

        currentFrieRate -= Time.deltaTime;
        
        if (Input.GetButton("Shoot") && currentFrieRate <=0)
        {
            Bolt temp = BoltP.GetFromPool();
            temp.transform.position = BoltPos.position;
            temp.transform.localScale = Vector3.one * boltSize;
            temp.gameObject.SetActive(true);
            currentFrieRate = FireRate;
            soundControl.PlayEffectSound(eSoundEffectClip.shotPlayer);
        }
        if (powerUpTimer <= 0)
        {
            boltSize = 1;
            powerUpTimer = 0;
        }
        else
        {
            powerUpTimer -= Time.deltaTime;
        }
	}
}
