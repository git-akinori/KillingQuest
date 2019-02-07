using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
	[SerializeField]
	Image lifeGauge;
	[SerializeField]
	Image extraGauge;

    PlayerBehaviour playerBehaviour;

    void Start()
    {
        playerBehaviour = GameManager.Member.PlayerBehaviour.GetComponent<PlayerBehaviour>();
		lifeGauge.fillAmount = playerBehaviour.LifeRatio;
		extraGauge.fillAmount = playerBehaviour.ExtraRatio;
    }
	
    void FixedUpdate()
    {
		lifeGauge.fillAmount = playerBehaviour.LifeRatio;
		extraGauge.fillAmount = playerBehaviour.ExtraRatio;
	}
}
