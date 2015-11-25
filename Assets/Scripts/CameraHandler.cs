using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour, ICameraHandler
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
	}

	public void Rotate(Vector3 eulerAngles)
	{
		transform.Rotate(eulerAngles);
	}

}
