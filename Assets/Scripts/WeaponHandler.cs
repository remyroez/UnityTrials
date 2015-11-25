using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour, IWeaponHandler
{
	public GameObject world;

	public GameObject prefab;

	// Use this for initialization
	void Start ()
	{
		if (world == null)
		{
			world = GameObject.FindWithTag("Game/World");
		}

		if (prefab == null)
		{
			prefab = Resources.Load("Prefabs/Bullet") as GameObject;
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Fire(Quaternion direction)
	{
		GameObject bullet = Instantiate(prefab, transform.position + direction * Vector3.forward * 1, Quaternion.identity) as GameObject;
		bullet.transform.parent = world.transform;
		bullet.GetComponent<Rigidbody>().AddForce(direction * Vector3.forward * 1000);
    }
}
