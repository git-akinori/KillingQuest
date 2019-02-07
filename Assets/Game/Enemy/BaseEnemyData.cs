using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEnemyData
{
    [SerializeField, Range(1, 100)]
    int hp;
    [SerializeField, Range(1, 100)]
    int speed;
    [SerializeField, Range(0, 100)]
    int power;
    [SerializeField, Range(1, 100)]
    int weight;
    [SerializeField, Range(0, 100)]
    int exPoint;
    [SerializeField, Range(0, 200)]
    int attackperiod;
 
    public BaseEnemyData(BaseEnemyData status)
    {
        hp = status.HP;
        speed = status.Speed;
        power = status.Power;
        weight = status.Weight;
        exPoint = status.ExPoint;
        attackperiod = status.Attackpeiod;
    }

    public int HP { get { return hp; } set { hp = value; } }
    public int Speed { get { return speed; } }
    public int Power { get { return power; } }
    public int Weight { get { return weight; } }
    public int ExPoint { get { return exPoint; } }
    public int Attackpeiod { get { return attackperiod; } }
}

