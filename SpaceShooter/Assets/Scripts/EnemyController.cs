﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField]
    private Transform BoltPos;

    private BoltPool BoltP;
    [SerializeField]
    private float Speed;
	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
    }

    public void SetBoltPool(BoltPool boltP)
    {
        BoltP = boltP;
    }

    private void OnEnable()
    {
        StartCoroutine(AutoShoot());
        rb.velocity = Vector3.back * Speed;
        StartCoroutine(AutoMovement());
    }

    private IEnumerator AutoMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f,2f));
            float moveForce = Random.Range(2f, 3f);
            if (rb.position.x >= 0)
            {
                rb.velocity += Vector3.left * moveForce;
            }
            else
            {
                rb.velocity += Vector3.right * moveForce;
            }
            float moveTime = Random.Range(1f, 2f);
            yield return new WaitForSeconds(moveTime);
            if (rb.position.x >= 0)
            {
                rb.velocity += Vector3.left * moveForce;
            }
            else
            {
                rb.velocity += Vector3.right * moveForce;
            }
            yield return new WaitForSeconds(Random.Range(0f,1f));
            if (rb.position.x >= 0)
            {
                rb.velocity += Vector3.left * moveForce;
            }
            else
            {
                rb.velocity += Vector3.right * moveForce;
            }
            yield return new WaitForSeconds(moveTime);
            if (rb.position.x >= 0)
            {
                rb.velocity += Vector3.left * moveForce;
            }
            else
            {
                rb.velocity += Vector3.right * moveForce;
            }
        }
    }

    private IEnumerator AutoShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Bolt bullet = BoltP.GetFromPool();
            bullet.transform.position = BoltPos.position;
            bullet.transform.rotation = BoltPos.rotation;
            bullet.gameObject.SetActive(true);
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
