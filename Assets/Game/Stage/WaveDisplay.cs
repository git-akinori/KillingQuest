using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject waveInfo = null;
    [SerializeField]
    GameObject[] number = new GameObject[3];

    [SerializeField]
    GameObject[] countNumber = new GameObject[3];

    [SerializeField]
    int waitSeconds = 3;

    void Start()
    {
        waveInfo.SetActive(false);
        number[0].SetActive(false);
        number[1].SetActive(false);
        number[2].SetActive(false);

        countNumber[0].SetActive(false);
        countNumber[1].SetActive(false);
        countNumber[2].SetActive(false);
    }

    public IEnumerator WaveDisplayCoroutine()
    {
        var count = waitSeconds;

        waveInfo.SetActive(true);
        number[GameManager.Member.EnemySpawner.CurrentWaveNum].SetActive(true);

        yield return new WaitForSeconds(2);

        number[GameManager.Member.EnemySpawner.CurrentWaveNum].SetActive(false);
        waveInfo.SetActive(false);

        while (count > 0)
        {
            // change num
            countNumber[--count].SetActive(true);
            yield return new WaitForSeconds(1);
            countNumber[count].SetActive(false);
        }

        yield return null;
    }
}