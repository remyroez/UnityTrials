using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject target;

    private Vector3 inputMotion = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
	    if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        inputMotion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (inputMotion.magnitude > 0)
        {
            MoveTarget(target, inputMotion);
        }

        Vector3 mouseMotion = new Vector3(0, Input.GetAxis("Mouse X") * 100, 0);
        if (mouseMotion.magnitude > 0)
        {
            RotateTarget(target, mouseMotion * Time.deltaTime);
        }

		if (Input.GetButtonDown("Jump"))
		{
			JumpCharacter(target, Vector3.up);
        }
    }

    void MoveTarget(GameObject gameObject, Vector3 motion)
    {
        if (!gameObject) return;

        ExecuteEvents.Execute<ICharacterHandler>(
            gameObject,
            null,
            (handler, data) => handler.Forward(motion)
        );
    }

    void RotateTarget(GameObject gameObject, Vector3 eulerAngles)
    {
        if (!gameObject) return;

        ExecuteEvents.Execute<ICharacterHandler>(
            gameObject,
            null,
            (handler, data) => handler.Rotate(eulerAngles)
        );
    }

	void JumpCharacter(GameObject gameObject, Vector3 motion)
	{
		if (!gameObject) return;

		ExecuteEvents.Execute<ICharacterHandler>(
			gameObject,
			null,
			(handler, data) => handler.Jump(motion)
		);
	}
}
