using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected BaseEnemyData enemyData;

    [SerializeField]
    float deathTime = 0;

    protected float _knockbackTime = 0;
    protected bool _knockCheck = false;

    protected Animator _animator;

    static protected PlayerBehaviour PB_player;
    protected Rigidbody2D rb2d;

    [SerializeField]
    private GameObject _eff;
   

    private void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("StageNumbers"));
    }

    protected enum EnumStatus
    {
        MOVE,
        ATTACK,
        SPECIAL,
        DEATH
    };

    protected EnumStatus _status;

    protected float _attackPeriod = 0;

    

    protected void CreateStart()
    {
        /* 作成後一回だけ呼ばれる */
        _animator = GetComponent<Animator>();

        if (!PB_player) PB_player = GameManager.Member.PlayerBehaviour;
        rb2d = GetComponent<Rigidbody2D>();

        var enemiesDataEachWave = GameManager.Member.EnemiesDataEachStage;

        switch (transform.name)
        {
            case "Skeleton":        enemyData = new BaseEnemyData(enemiesDataEachWave.Stages[PlayerPrefs.GetInt("StageNumbers")-1].Skeleton); break;
            case "Ork":             enemyData = new BaseEnemyData(enemiesDataEachWave.Stages[PlayerPrefs.GetInt("StageNumbers")-1].Ork); break;
            case "Boss Skeleton":   enemyData = new BaseEnemyData(enemiesDataEachWave.Stages[PlayerPrefs.GetInt("StageNumbers")-1].Boss_Skeleton); break;
            default: Debug.LogError("not enemyName!" + transform.name); break;
        }
    }

    protected virtual void MoveStart()
    {
        /* 通常移動開始時、最初に1回呼ばれる */

        rb2d.velocity = new Vector2(-enemyData.Speed, 0);
    }

    protected virtual void MoveUpdate()
    {
        /* 通常移動の処理 */

        if (rb2d.IsSleeping()) MoveStart();
    }

    protected virtual void AttackStart()
    {
        /*攻撃開始時に、一回呼ばれる*/

    }

    protected virtual void AttackUpdate()
    {
        /*攻撃開始時の処理*/
        _attackPeriod += Time.deltaTime;
        if (_attackPeriod > enemyData.Attackpeiod / 10f)
        {
            _animator.SetTrigger("attack");
            //HitPlayer();
            _attackPeriod = 0;
        }
    }

    protected virtual void SpecialStart()
    {
    }

    protected virtual void SpecialUpdate()
    {
    }

    protected virtual void DeathStart()
    {
        /* HPが0になった時最初に1回だけ呼ばれる */
        if (PB_player)
        {
            PB_player.AddExtraPoint(enemyData.ExPoint);
        }
        GetComponent<BoxCollider2D>().enabled = false;

        rb2d.velocity = new Vector2(0, 0);
        _animator.SetTrigger("yarareta");

        Destroy(gameObject, deathTime);
    }

    protected virtual void DeathUpdate()
    {
        /* HPが0になった後の処理 */
    }

    protected virtual void HitPlayer()
    {
        //敵がプレイヤーにダメージを与える

        if (PB_player)
        {
            /* プレイヤーに当たった時の処理*/
            PB_player.Damaged(enemyData.Power);
        }
    }

    public virtual void EnemyDamaged(int power)
    {
        /* 武器に当たった時の処理 */
        enemyData.HP -= power;
        _animator.SetTrigger("damaged");
        _status = EnumStatus.MOVE;

        _knockCheck = true;
        Knockback();
    }

    protected virtual void Knockback()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * (PB_player.KnockBackPower / (float)enemyData.Weight) * 0.5f, ForceMode2D.Impulse);
    }

    void Start()
    {
        CreateStart();
        changeStatus(EnumStatus.MOVE);
    }

    protected virtual void FixedUpdate()
    {
        switch (_status)
        {
            case EnumStatus.MOVE:
                MoveUpdate();
                break;

            case EnumStatus.ATTACK:
                AttackUpdate();
                break;

            case EnumStatus.SPECIAL:
                SpecialUpdate();
                break;

            case EnumStatus.DEATH:
                DeathUpdate();
                break;

            default:
                Debug.Log("NoStatus");
                break;
        }

        if (enemyData.HP <= 0)
        {
            changeStatus(EnumStatus.DEATH);
        }

        if (_knockCheck == true)
        {
            _knockbackTime += Time.deltaTime;
            if (_knockbackTime > 1)
            {
                _knockCheck = false;
                MoveStart();
                _knockbackTime = 0;
            }
        }
    }

    protected virtual void changeStatus(EnumStatus _status)
    {
        switch (_status)
        {
            case EnumStatus.MOVE:
                MoveStart();
                break;

            case EnumStatus.ATTACK:
                AttackStart();
                break;

            case EnumStatus.SPECIAL:
                SpecialStart();
                break;

            case EnumStatus.DEATH:
                DeathStart();
                break;

            default:
                break;
        }

        this._status = _status;

    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            changeStatus(EnumStatus.ATTACK);
        }
    }

    protected virtual void effect()
    {
        Instantiate(_eff, transform);
    }

   

    public void destroy()
    {
        Destroy(gameObject);
    }


}
