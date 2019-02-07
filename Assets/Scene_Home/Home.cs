using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Home : MonoBehaviour
{
    [SerializeField]
    private int maxCharactorNum;
    [SerializeField]
    private int maxStageNum;
    [SerializeField]
    private float time_Change;


    [SerializeField]
    private int nowSelectCharactor;
    private int nextSelectCharactor;
    [SerializeField]
    private int nowSelectStage;
    private int nextSelectStage;
    private float frame;

    [SerializeField]
    private Image _StageImage;
    [SerializeField]
    private Sprite[] _changeSprite;

    [SerializeField]
    private GameObject _sellectStage;
    [SerializeField]
    private GameObject _sellectChara;

    //キャラチェンジのためのカウント
    private int count = 0;

    //ステージチェンジのためのカウント
    public int StageNumbers = 0;

    //シェーダーてきななにか
    private float blackalpha;
    [SerializeField]
    private Image _blackImage;
    [SerializeField]
    private GameObject _blackObj;

    private void Start()
    {
        _sellectChara.SetActive(false);
        _sellectStage.SetActive(true);

        blackalpha = 1;
        StartCoroutine(FirstCoroutine());
        PlayerPrefs.SetInt("StageNumbers", 1);
        PlayerPrefs.SetInt("SelectedCharacter", (int)PlayerCharacter.Knife);
        PlayerPrefs.SetInt("CharacterDecision", 0); // 0 = false, 1 = true
    }

    IEnumerator FirstCoroutine()
    {
        while (true)
        {
            _blackImage.GetComponent<Image>().color = new Color(0, 0, 0, blackalpha);

            blackalpha -= 0.005f;

            if (blackalpha <= 0f)
            {
                break;
            }

            yield return null;
        }

        _blackObj.SetActive(false);

        yield return null;
    }

    //SellectStage
    public void PushStage1()
    {
        _StageImage.sprite = _changeSprite[0];
        PlayerPrefs.SetInt("StageNumbers", 1);
    }

    public void PushStage2()
    {
        _StageImage.sprite = _changeSprite[1];
        PlayerPrefs.SetInt("StageNumbers", 2);

    }

    public void PushStage3()
    {
        _StageImage.sprite = _changeSprite[2];
        PlayerPrefs.SetInt("StageNumbers", 3);
    }

    public void StageDecide()
    {
        StartCoroutine(NextSellect());
    }

    private IEnumerator NextSellect()
    {
        _sellectStage.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        _sellectChara.SetActive(true);
        yield return null;
    }

    //SellectChara
    public void Right()
    {
        count++;

        ChangeCharacter();
    }

    public void Left()
    {
        count--;

        ChangeCharacter();
    }

    void ChangeCharacter()
    {
        switch (count % 3)
        {
            case 0:
                PlayerPrefs.SetInt("SelectedCharacter", (int)PlayerCharacter.Knife);
                break;

            case 1:
                PlayerPrefs.SetInt("SelectedCharacter", (int)PlayerCharacter.Princess);
                break;

            case 2:
                PlayerPrefs.SetInt("SelectedCharacter", (int)PlayerCharacter.TwoHanded);
                break;
        }
    }

    public void CharaDecide()
    {
        _sellectChara.SetActive(false);
        PlayerPrefs.SetInt("CharacterDecision", 1); // 0 = false, 1 = true
    }

    public void BackSellectStage()
    {
        StartCoroutine(BackSellect());
    }

    private IEnumerator BackSellect()
    {
        _sellectChara.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _sellectStage.SetActive(true);
        yield return null;
    }


}
