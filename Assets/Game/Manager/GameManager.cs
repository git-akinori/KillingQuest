using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum EStage
{
	DEBUG_MODE = 0,
	STAGE_1 = 1,
	STAGE_2 = 2,
	STAGE_3 = 3,
}

public class GameManager : MonoBehaviour
{
	static GameManager gameManager = null;

	[SerializeField]
	GameObject canvas_UI;
	[SerializeField]
	GameObject playerObj;
    [SerializeField]
    GameObject attackColliderObj;
	[SerializeField]
	GameObject enemySpawnerObj;
	[SerializeField]
	GameObject UI_WaveObj;

    //stage差し替え用
    [SerializeField]
    Sprite[] Stageground;
    [SerializeField]
    Sprite[] StageSky;
    [SerializeField]
    Sprite[] StageCloud;

    [SerializeField]
    Image[] stages;
    

    //EStage selectedStage = EStage.STAGE_1;

	//CsvReader csvReader = new CsvReader();

	//string[] filePaths = new string[] {
	//	"WaveData_Stage1",
	//	"WaveData_Stage2",
	//	"WaveData_Stage3",};

	//static List<string[]> waveDataList = new List<string[]>();

	void Awake()
	{
		if (gameManager == null) gameManager = this;
		else if (gameManager != this) Destroy(gameObject);

		//DontDestroyOnLoad(gameObject);

		Application.targetFrameRate = 60;
	}

	void Start()
	{
		Time.timeScale = 1.0f;
		//LoadWaveData();

        switch (PlayerPrefs.GetInt("StageNumbers"))
        {
            case 1:
                stages[0].sprite = StageSky[0];
                stages[1].sprite = Stageground[0];
                break;

            case 2:
                stages[0].sprite = StageSky[1];
                stages[1].sprite = Stageground[1];
                break;

            case 3:
                stages[0].sprite = StageSky[2];
                stages[1].sprite = Stageground[2];
                break;
        }

	}

	// property --------------------------------------------------------------
	public static GameManager Member { get { return gameManager; } }

	// field
	//public List<string[]> WaveDataList { get { return waveDataList; } }
	//public EStage SelectedStage { get { return selectedStage; } set { selectedStage = value; LoadWaveData();  } }

    // component
    public BoxCollider2D AttackCollider { get { return attackColliderObj.GetComponentInChildren<BoxCollider2D>(); } }

	// script
	public PlayerBehaviour PlayerBehaviour { get { return playerObj.GetComponent<PlayerBehaviour>(); } }
    public PlayerAttack PlayerAttack { get { return attackColliderObj.GetComponent<PlayerAttack>(); } }
	public EnemySpawner EnemySpawner { get { return enemySpawnerObj.GetComponent<EnemySpawner>(); } }
    public BaseWaveData[] WavesData { get { return enemySpawnerObj.GetComponent<StagesData>().StageData[PlayerPrefs.GetInt("StageNumbers")-1].WaveData; } }
	public EnemiesDataEachStage EnemiesDataEachStage { get { return enemySpawnerObj.GetComponent<EnemiesDataEachStage>(); } }
	public WaveDisplay WaveDisplay { get { return UI_WaveObj.GetComponent<WaveDisplay>(); } }

	// functions -------------------------------------------------------------
	//private void LoadWaveData()
	//{
	//	if (selectedStage != EStage.DEBUG_MODE)
	//	{
	//		string filePath = "CSV/";

	//		// ウェーブデータを選択
	//		filePath += filePaths[(int)selectedStage - 1];

	//		//Debug.Log(filePath);
	//		// ウェーブデータをロードしてリスト化
	//		waveDataList = csvReader.ReadCSV(filePath);
	//	}
	//}

	public void EnterResult(bool win)
	{
		canvas_UI.GetComponent<Result>().EnterResult(win);
	}
}
