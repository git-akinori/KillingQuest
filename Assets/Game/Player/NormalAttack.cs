using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MonoBehaviour {

    [SerializeField]
    AudioClip SE_damage;

    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().PlayOneShot(SE_damage);
        collision.transform.GetComponent<EnemyMove>().EnemyDamaged(GameManager.Member.PlayerBehaviour.AttackPower);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
