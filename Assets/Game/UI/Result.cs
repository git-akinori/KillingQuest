using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Result : MonoBehaviour
{

	[SerializeField]
	GameObject ResultUI;
    [SerializeField]
    GameObject ResultImage;

    [SerializeField]
    private Sprite[] _resultImage;

	// 起動時オフ
	void Start()
	{
		ResultUI.SetActive(false);
	}

	// リザルト画面に入る処理
	public void EnterResult(bool win)
	{
		if (win)
        {
            StartCoroutine(WinCoroutine());
        }
		else
        {
            StartCoroutine(LoseCoroutine());
        }
    }

    IEnumerator WinCoroutine()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            ResultUI.SetActive(true);
        }

        ResultImage.GetComponent<Image>().sprite = _resultImage[0];
        Debug.Log("WIN!");

        yield return null;
    }

    IEnumerator LoseCoroutine()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            ResultUI.SetActive(true);
        }

        ResultImage.GetComponent<Image>().sprite = _resultImage[1];
        Debug.Log("LOSE!");

        yield return null;
    }
}
