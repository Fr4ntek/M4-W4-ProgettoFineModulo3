using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private int _jumpForce = 5;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Transform _cameraTransform;

    private Rigidbody _rb;
    private float h;
    private float v;
    private Vector3 _camForward;
    private Vector3 _camRight;
    private bool _canMove = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_groundChecker == null) _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && CanJump())
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if(_cameraTransform == null) return;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        _camForward = _cameraTransform.forward.normalized;
        _camRight = _cameraTransform.right.normalized;
        _camForward.y = 0f;
        _camRight.y = 0f;

        Vector3 direction = (v * _camForward + h * _camRight).normalized * _speed;

        if (direction.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed * Time.fixedDeltaTime);
        }
        if (_canMove)
        {
            _rb.velocity = direction * _speed + new Vector3(0f, _rb.velocity.y, 0f);
        }
        
    }

    private bool CanJump()
    {
        if (_groundChecker.IsGrounded) return true;
        return false;
    }

    public IEnumerator TemporarilyDisableMovement()
    {
        _canMove = false;
        yield return new WaitForSeconds(0.5f); 
        _canMove = true;
    }
}
