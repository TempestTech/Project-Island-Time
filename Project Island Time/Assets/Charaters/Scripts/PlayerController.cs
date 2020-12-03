using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _characterController;
    private bool canJump, isInAir;
    private float baseJump;

    public float Speed = 4.0f;
    public float RotationSpeed = 300.0f;
    public float Gravity = 9.8f;
    public float JumpSpeed = 5.0f;

    private Vector3 _moveDir = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        canJump = true;
        isInAir = false;
        baseJump = -100;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool move = (vertical != 0);
        if (_animator.GetBool("PushingS") == false)
            _animator.SetBool("Running", move);

        if (_animator.GetBool("PushingS") == true)
            Speed = 0.5f;
        else
            Speed = 4.0f;


        transform.Rotate(0, horizontal * RotationSpeed * Time.deltaTime, 0);

        // _moveDir = Vector3.forward * vertical;
        // _moveDir = transform.TransformDirection(_moveDir);
        //_moveDir *= Speed;
        _moveDir = new Vector3(0, 0, vertical);
        _moveDir = transform.TransformDirection(_moveDir);
        if (canJump)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))
            {
                isInAir = true;
                if (baseJump == -100)
                    baseJump = transform.position.y;
                if (_animator.GetBool("Running") == true)
                {
                    _animator.SetBool("JumpingR", true);
                }
                else if (_animator.GetBool("Running") == false)
                {
                    _animator.SetBool("Jumping", true);
                }
                //if (Input.GetKey(KeyCode.Space))
                //    _moveDir.y = JumpSpeed / Speed;
                //else if (Input.GetKeyDown(KeyCode.Space))
                //    _moveDir.y += JumpSpeed / Speed;
            }
            if (baseJump != -100 && transform.position.y - baseJump > 1.3)
            {
                canJump = false;
                isInAir = false;
                _animator.SetBool("Jumping", false);
                _animator.SetBool("Landing", true);
            }
            if (isInAir)
                _moveDir.y = JumpSpeed / Speed;
        }
        else
        {
        }
        if (_characterController.isGrounded && !canJump)
        {
            baseJump = -100;
            canJump = true;
            _animator.SetBool("Jumping", false);
            _animator.SetBool("JumpingR", false);
            _animator.SetBool("Landing", false);
        }
        _moveDir.y -= Gravity * Speed * 0.5f * Time.deltaTime;
        _characterController.Move(_moveDir * Speed * Time.deltaTime);

    }
}
