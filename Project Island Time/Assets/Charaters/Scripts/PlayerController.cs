using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;

    private CharacterController _characterController;

    public float Speed = 5.0f;
    public float RotationSpeed = 300.0f;
    public float Gravity = 9.8f;

    private Vector3 _moveDir = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //if (vertical < 0) vertical = 0;
        //Debug.Log("????");

        bool move = (vertical != 0);
            _animator.SetBool("Running", move);
        

        transform.Rotate(0, horizontal * RotationSpeed * Time.deltaTime, 0);

        // _moveDir = Vector3.forward * vertical;
        // _moveDir = transform.TransformDirection(_moveDir);
        // _moveDir *= Speed;
        _moveDir = new Vector3(0, 0, vertical);
        _moveDir = transform.TransformDirection(_moveDir);
        _moveDir.y = -Gravity;

        _characterController.Move(_moveDir * Speed * Time.deltaTime);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.LogWarning(other);
    //}
}
