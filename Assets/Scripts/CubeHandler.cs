using UnityEngine;
using System.Collections;

public class CubeHandler : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y < 0)
		{
			Reset();
		}
	}

	void Reset()
	{
		transform.position = new Vector3(0, 5, 0);
		transform.rotation = Quaternion.identity;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}
