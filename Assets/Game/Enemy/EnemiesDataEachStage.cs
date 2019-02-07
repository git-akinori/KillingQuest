using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDataEachStage : MonoBehaviour
{
    [SerializeField] 
    EnemiesData stage1;
    [SerializeField]
    EnemiesData stage2;
    [SerializeField]
    EnemiesData stage3;

    public EnemiesData Stage1 { get { return stage1; } }
    public EnemiesData Stage2 { get { return stage2; } }
    public EnemiesData Stage3 { get { return stage3; } }

    public EnemiesData[] Stages
    {
        get
        {
            EnemiesData[] stages = new EnemiesData[3];
            stages[0] = stage1;
            stages[1] = stage2;
            stages[2] = stage3;
            return stages;
        }
    }
}
