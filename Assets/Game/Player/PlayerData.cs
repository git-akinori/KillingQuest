using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerCharacter
{
    Knife, TwoHanded, Princess, NONE,
}

[System.Serializable]
public class PlayerData
{
    [SerializeField]
    protected GameObject obj;

    [SerializeField, Range(1, 1000)]
    protected float maxLIFE = 100;
    [SerializeField, Range(0, 1000)]
    protected float maxEXTRA = 100;

    [SerializeField, Range(0, 10)]
    protected float addExSpeed = 0;
    [SerializeField, Range(0, 2)]
    protected float delayOfSpecial = 0.1f;

    [SerializeField, Range(0, 10)]
    protected int attackPower = 1;
    [SerializeField, Range(0, 100)]
    protected int knockBackPower = 1;

    public GameObject Obj { get { return obj; } }
    public float MaxLife { get { return maxLIFE; } }
    public float MaxExtra { get { return maxEXTRA; } }
    public float AddExSpeed { get { return addExSpeed; } }
    public float DelayOfSpecial { get { return delayOfSpecial; } }
    public int AttackPower { get { return attackPower; } }
    public int KnockBackPower { get { return knockBackPower; } }
}
