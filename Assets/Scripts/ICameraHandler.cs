using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface ICameraHandler : IEventSystemHandler
{
	void Rotate(Vector3 eulerAngles);
}
