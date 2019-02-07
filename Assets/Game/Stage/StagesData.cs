using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseSpawnData
{
    string name;
    [SerializeField, Range(0, 5)]
    float spawnStartTime = 0;
    [SerializeField, Range(0.1f, 5)]
    float spawnInterval = 1;
    [SerializeField, Range(0, 20)]
    int spawnLimitNum = 0;

    public BaseSpawnData(string name) { this.name = name; }

    public string Name { get { return name; } }
    public float SpawnStartTime { get { return spawnStartTime; } }
    public float SpawnInterval { get { return spawnInterval; } }
    public int SpawnLimitNum { get { return spawnLimitNum; } }
}

[System.Serializable]
public class BaseWaveData
{
    [SerializeField]
    BaseSpawnData ork = new BaseSpawnData("Ork");
    [SerializeField]
    BaseSpawnData skeleton = new BaseSpawnData("Skeleton");
    [SerializeField]
    BaseSpawnData boss_skeleton = new BaseSpawnData("Boss Skeleton");

    public BaseSpawnData Ork { get { return ork; } }
    public BaseSpawnData Skeleton { get { return skeleton; } }
    public BaseSpawnData Boss_Skeleton { get { return boss_skeleton; } }
    public BaseSpawnData[] SpawnData
    {
        get
        {
            BaseSpawnData[] bsd = new BaseSpawnData[3];
            bsd[0] = ork;
            bsd[1] = skeleton;
            bsd[2] = boss_skeleton;
            return bsd;
        }
    }
}

[System.Serializable]
public class BaseStageData
{
    [SerializeField]
    BaseWaveData wave1;
    [SerializeField]
    BaseWaveData wave2;
    [SerializeField]
    BaseWaveData wave3;

    public BaseWaveData Wave1 { get { return wave1; } }
    public BaseWaveData Wave2 { get { return wave2; } }
    public BaseWaveData Wave3 { get { return wave3; } }

    public BaseWaveData[] WaveData
    {
        get
        {
            BaseWaveData[] waves = new BaseWaveData[3];
            waves[0] = wave1;
            waves[1] = wave2;
            waves[2] = wave3;
            return waves;
        }
    }
}


public class StagesData : MonoBehaviour
{
    [SerializeField]
    BaseStageData stage1;
    [SerializeField]
    BaseStageData stage2;
    [SerializeField]
    BaseStageData stage3;

    public BaseStageData Stage1 { get { return stage1; } }
    public BaseStageData Stage2 { get { return stage2; } }
    public BaseStageData Stage3 { get { return stage3; } }
    
    public BaseStageData[] StageData
    {
        get
        {
            BaseStageData[] stages = new BaseStageData[3];
            stages[0] = stage1;
            stages[1] = stage2;
            stages[2] = stage3;
            return stages;
        }
    }
}
