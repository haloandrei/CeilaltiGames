using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public Vector2 boundariesX;
	public float ratio;

	void Update()
	{
		if (target == null)
		{
			return;
		}

		Vector3 destination = new Vector3(target.position.x, transform.position.y, transform.position.z);
		if (destination.x < boundariesX.x)
			destination.x = boundariesX.x;
		else if (destination.x > boundariesX.y)
			destination.x = boundariesX.y;

		transform.position = Vector3.Lerp(transform.position, destination, ratio);
	}
}
