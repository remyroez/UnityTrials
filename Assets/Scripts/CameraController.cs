using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    // Use this for initialization
    void Start ()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("MainCamera");
        }
    }
	
    // Update is called once per frame
    void Update ()
    {
        Vector3 mouseMotion = new Vector3(Input.GetAxis("Mouse Y") * -100, 0, 0);
        if (mouseMotion.magnitude > 0)
        {
            RotateCamera(target, mouseMotion * Time.deltaTime);
        }
    }
    
    void RotateCamera(GameObject gameObject, Vector3 eulerAngles)
    {
        if (!gameObject) return;

        ExecuteEvents.Execute<ICameraHandler>(
            gameObject,
            null,
            (handler, data) => handler.Rotate(eulerAngles)
        );
    }
}
