using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    //Animator animator;
    Transform t_parent;
    
    BoxCollider2D attackCollider;
    [SerializeField]
    AudioClip SE_attack;

    [SerializeField]
    private GameObject _eff;
    [SerializeField]
    private GameObject arthur_knife;

    void Start()
    {
        t_parent = transform.parent;
        if (!transform.parent) Destroy(gameObject);
        //animator = GetComponent<Animator>();
        attackCollider = GameManager.Member.AttackCollider;
    }

    // アニメーションのパラメータ変更用
    //public void Change(bool active) { animator.SetBool(name, active); }

    // ダメージを与えるアニメーションの始めのフレームのキーイベントに追加する
    public void TurnOnCollision() { attackCollider.enabled = true; GetComponent<AudioSource>().PlayOneShot(SE_attack); }
    // ダメージを与えるアニメーションの終わりのフレームのキーイベントに追加する
    public void TurnOffCollision() { attackCollider.enabled = false; }

    public void EnterResult_clear() { GameManager.Member.EnterResult(true); }
    public void EnterResult_gameover() { GameManager.Member.EnterResult(false); }

    protected virtual void effect()
    {
        Instantiate(_eff, transform);
    }

    public void GenerateKnife()
    {
        Instantiate(arthur_knife, transform);
    }
}
