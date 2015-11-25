using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WeaponController : MonoBehaviour
{
	public GameObject character;

	public GameObject camera;

	// Use this for initialization
	void Start()
	{
		if (character == null)
		{
			character = GameObject.FindWithTag("Player");
		}

		if (camera == null)
		{
			camera = GameObject.FindWithTag("MainCamera");
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			FireWeapon(character, camera.transform.rotation);
		}
	}

	void FireWeapon(GameObject gameObject, Quaternion direction)
	{
		if (!gameObject) return;

		ExecuteEvents.Execute<IWeaponHandler>(
			gameObject,
			null,
			(handler, data) => handler.Fire(direction)
		);
	}
}
