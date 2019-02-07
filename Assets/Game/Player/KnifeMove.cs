using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMove : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    [SerializeField]
    AudioClip SE_throw;
    [SerializeField]
    AudioClip SE_hit;

    void Start()
    {
        transform.parent.GetComponent<AudioSource>().PlayOneShot(SE_throw);
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.GetComponent<AudioSource>().PlayOneShot(SE_hit);
        collision.transform.GetComponent<EnemyMove>().EnemyDamaged(GameManager.Member.PlayerBehaviour.AttackPower);
        Destroy(gameObject);
    }
}
