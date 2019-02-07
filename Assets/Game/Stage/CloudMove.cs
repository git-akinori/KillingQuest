using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {

	[SerializeField]
	float roopDist = 50;
	[SerializeField]
	float movedDist = 0;
	[SerializeField]
	float speed = 0;

	[SerializeField]
	GameObject cloud1;
	[SerializeField]
	GameObject cloud2;

	Transform cloud_left, cloud_right;

	void Start()
	{
		roopDist = cloud2.transform.localPosition.x - cloud1.transform.localPosition.x;

		cloud_left = cloud1.transform;
		cloud_right = cloud2.transform;
	}

	void FixedUpdate()
	{
		movedDist += speed;

		cloud_left.localPosition -= new Vector3(speed, 0);
		cloud_right.localPosition -= new Vector3(speed, 0);

		if (movedDist >= roopDist)
		{
			cloud_left.localPosition += new Vector3(roopDist * 2, 0);

			var tmp = cloud_left;
			cloud_left = cloud_right;
			cloud_right = tmp;

			movedDist = 0;
		}
	}
}
/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {

	[SerializeField]
	float roopDist = 50;
	[SerializeField]
	float movedDist = 0;

	[SerializeField]
	GameObject cloud1;
	[SerializeField]
	GameObject cloud2;

	Transform cloud_left, cloud_right;

	void Start () {
		roopDist = cloud2.transform.localPosition.x - cloud1.transform.localPosition.x;

		cloud_left = cloud1.transform;
		cloud_right = cloud2.transform;
	}

	void Update()
	{
		movedDist += Time.deltaTime;

		cloud_left.localPosition -= new Vector3(Time.deltaTime, 0);
		cloud_right.localPosition -= new Vector3(Time.deltaTime, 0);

		if (movedDist >= roopDist)
		{

			cloud_left.localPosition += new Vector3(roopDist * 2, 0);

			movedDist = 0;
		}
	}
}

	 */
