using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Space]
    [SerializeField]
    PlayerCharacter playerCharacter = PlayerCharacter.Knife;

    [SerializeField]
    PlayerData arthur = null, twohanded = null, princess = null;
    PlayerData playerData = null;

    Gauge life;
    Gauge extra;

    Animator animator;

    [SerializeField]
    AudioClip SE_damaged = null;

    void Start()
    {
        if (PlayerPrefs.GetInt("CharacterDecision") == 1) // 0 = false, 1 = true
        {
            playerCharacter = (PlayerCharacter)PlayerPrefs.GetInt("SelectedCharacter");
        }

        switch (playerCharacter)
        {
            case PlayerCharacter.Knife: playerData = arthur; break;
            case PlayerCharacter.TwoHanded: playerData = twohanded; break;
            case PlayerCharacter.Princess: playerData = princess; break;
        }

        PlayerPrefs.SetInt("CharacterDecision", 0); // 0 = false, 1 = true

        GameManager.Member.PlayerAttack.RequireTouchTime = playerData.DelayOfSpecial;
        Instantiate(playerData.Obj, transform);

        life = new Gauge(playerData.MaxLife, 1);
        extra = new Gauge(playerData.MaxExtra, 0);

        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        if (!animator) { animator = GetComponentInChildren<Animator>(); }

        //life.Add(-0.1f);
        AddExtraPoint(playerData.AddExSpeed);
    }

    class Gauge
    {
        float max;
        float cur;

        public Gauge(float max, float initRatio)
        {
            this.max = max;
            cur = max * initRatio;
            cur = (cur < 0) ? 0
                : (cur > max) ? max
                : cur;
        }

        public void Add(float value)
        {
            cur += value;
            cur = (cur < 0) ? 0
                : (cur > max) ? max
                : cur;
        }

        public float Ratio { get { return cur / max; } }
        public float CurValue { get { return cur; } }
    }

    bool lose = false;

    // ダメージをくらう処理で呼び出す
    public void Damaged(float value) {
        life.Add(-value); animator.SetTrigger("damaged");
        GetComponentInChildren<AudioSource>().PlayOneShot(SE_damaged);

        if (life.CurValue <= 0 && !lose)
        {
            lose = true;
            GameManager.Member.PlayerBehaviour.Animator.SetTrigger("lose");
        }
    }

    // 敵を倒したときの処理で呼び出す
    public void AddExtraPoint(float value) { extra.Add(value); }

    // property----------------------------------------
    public int AttackPower { get { return playerData.AttackPower; } }
    public int KnockBackPower { get { return playerData.KnockBackPower; } }
    // LIFEの割合
    public float LifeRatio { get { return life.Ratio; } }
    // EXTRAの割合
    public float ExtraRatio { get { return extra.Ratio; } }
    // Animator
    public Animator Animator { get { return animator; } }
}
