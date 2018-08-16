using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackField : MonoBehaviour {

    [SerializeField]
    private PlayerController player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(string.Format("enemy name{0}", other.gameObject.name));
        }
    }
}
