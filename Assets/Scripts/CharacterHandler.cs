using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour, ICharacterHandler
{
    public float speed = 5.0f;

    private CharacterController _characterContorller;
    protected CharacterController characterContorller { get { return _characterContorller ?? (_characterContorller = GetComponent<CharacterController>()); } }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move(Physics.gravity * Time.deltaTime);
	}

    public void Move(Vector3 motion)
    {
        characterContorller.Move(motion);
    }

    public void Forward(Vector3 motion)
    {
        if (motion.magnitude == 0) return;

        characterContorller.Move(Quaternion.LookRotation(motion) * transform.forward * (speed * motion.magnitude));
    }

    public void Rotate(Vector3 eulerAngles)
    {
        transform.Rotate(eulerAngles);
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

}
