using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IWeaponHandler : IEventSystemHandler
{
	void Fire(Quaternion direction);
}
