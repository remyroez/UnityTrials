using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface ITransformHandler : IEventSystemHandler
{
    void Rotate(Vector3 motion);
    void SetRotation(Quaternion rotation);
}
