using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _radius = 0.1f;
    [SerializeField] private LayerMask _whatIsGround;

    public bool IsGrounded { get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, _radius);
    }

    void Update()
    {
        IsGrounded = Physics.CheckSphere(transform.position, _radius, _whatIsGround);
    }
}
