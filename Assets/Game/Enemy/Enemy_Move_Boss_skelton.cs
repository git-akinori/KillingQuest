using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move_Boss_skelton : EnemyMove
{
    private float _specialPeriod = 0;

    private void Update()
    {
        Debug.Log(_status);
        //Debug.Log(_attackPeriod);
        //Debug.Log(_specialPeriod);
    }

    private void back()
    {
        rb2d.velocity = new Vector2(10, 0);
    }

    private void stop()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    private void counter()
    {
        rb2d.velocity = new Vector2(-15, 0);
    }

    protected override void MoveStart()
    {
        rb2d.velocity = new Vector2(-enemyData.Speed, 0);
    }

    protected override void MoveUpdate()
    {
        if (rb2d.IsSleeping()) MoveStart();

        /* 通常移動の処理 */
        if (_knockCheck == true)
        {
            _knockbackTime += Time.deltaTime;
            if (_knockbackTime > 0.5f)
            {
                _knockCheck = false;
                MoveStart();
                _knockbackTime = 0;
            }
        }
    }

    protected override void AttackStart()
    {
        _animator.SetBool("special", false);
    }

    protected override void AttackUpdate()
    {
        /*攻撃開始時の処理*/
        _attackPeriod += Time.deltaTime;
        if (_attackPeriod > enemyData.Attackpeiod / 10f)
        {
            _animator.SetTrigger("attack");
            //HitPlayer();
            _attackPeriod = 0;
        }

        _specialPeriod += Time.deltaTime;
        /*攻撃開始時の処理*/
        if (_specialPeriod > 20f)
        {
            changeStatus(EnumStatus.SPECIAL);
            _animator.SetBool("special", true);
            
        }
    }

    protected override void SpecialUpdate()
    {
        _specialPeriod = 0;


    }
}
