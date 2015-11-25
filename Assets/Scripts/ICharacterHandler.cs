using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface ICharacterHandler : IEventSystemHandler
{
    void Move(Vector3 motion);
    void Forward(Vector3 motion);
    void Rotate(Vector3 eulerAngles);
    void SetRotation(Quaternion rotation);

	void Jump(Vector3 motion);
}
