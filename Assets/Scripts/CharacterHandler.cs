using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour, ICharacterHandler
{
	public float speed = 5.0f;

	public float jumpPower = 5.0f;

	private Vector3 thrust = Vector3.zero;

	private Vector3 velocity = Vector3.zero;

	private Vector3 force = Vector3.zero;

	private CharacterController _characterContorller;
	protected CharacterController characterContorller { get { return _characterContorller ?? (_characterContorller = GetComponent<CharacterController>()); } }

	protected bool isGrounded { get { return characterContorller ? characterContorller.isGrounded : false; } }

	private bool isJumped = false;
	
	// Use this for initialization
	void Start()
	{

	}

	void Reset()
	{
		Cleanup();
		velocity = Vector3.zero;

		SetPosition(new Vector3(0, 10, 0));
		SetRotation(Quaternion.identity);
	}

	// Update is called once per frame
	void Update()
	{
		velocity += force + (Physics.gravity * Time.deltaTime);

		Move((thrust + velocity) * Time.deltaTime);

		if (isGrounded)
			velocity = Vector3.zero;

		if (transform.position.y < 0)
		{
			Reset();
        }

		Cleanup();
    }

	void Cleanup()
	{
		thrust = Vector3.zero;
		force = Vector3.zero;
		isJumped = false;
	}

	public void SimpleMove(Vector3 speed)
	{
		characterContorller.SimpleMove(speed);
	}

	public void Move(Vector3 motion)
	{
		characterContorller.Move(motion);
	}

	public void Forward(Vector3 motion)
	{
		if (motion.magnitude == 0) return;

		thrust = (Quaternion.LookRotation(motion) * transform.forward * (speed * motion.magnitude));
	}

	public void SetPosition(Vector3 position)
	{
		transform.position = position;
	}

	public void Rotate(Vector3 eulerAngles)
	{
		transform.Rotate(eulerAngles);
	}

	public void SetRotation(Quaternion rotation)
	{
		transform.rotation = rotation;
	}

	public void Jump(Vector3 motion)
	{
		if (isJumped) return;
		if (!isGrounded) return;

		AddForce(motion* jumpPower);

		isJumped = true;
    }

	public void AddForce(Vector3 force)
	{
		this.force += force;
    }
}
