using UnityEngine;
using System.Collections;

public class BulletHandler : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		StartCoroutine(Life());
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y < 0)
		{
			Destroy(gameObject);
		}
	}

	IEnumerator Life()
	{
		yield return new WaitForSeconds(3.0f);
		Destroy(gameObject);
	}
}
