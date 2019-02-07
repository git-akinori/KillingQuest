using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumEnemy
{
    SKELETON,
    ORK,
    BOSS_SKELETON,
}

[System.Serializable]
public class EnemiesData
{
    [SerializeField]
    BaseEnemyData ork;
    [SerializeField]
    BaseEnemyData skeleton;
    [SerializeField]
    BaseEnemyData boss_skeleton;

    public BaseEnemyData Ork { get { return ork; } }
    public BaseEnemyData Skeleton { get { return skeleton; } }
    public BaseEnemyData Boss_Skeleton { get { return boss_skeleton; } }
}
