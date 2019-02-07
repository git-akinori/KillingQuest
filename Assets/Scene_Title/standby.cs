using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class standby : MonoBehaviour {

    private GameObject startmotion;
    private float step = 0.02f;

	// Use this for initialization
	void Start () {
        this.startmotion = GameObject.Find("Text");
	}

	// Update is called once per frame
	void Update () {
        float SBColor = this.startmotion.GetComponent<Image>().color.a;
        if (SBColor < 0 || SBColor > 1) {
            step = step * -1;
        }
        this.startmotion.GetComponent<Image>().color = new Color(255, 255, 255, SBColor + step);
	}
}
