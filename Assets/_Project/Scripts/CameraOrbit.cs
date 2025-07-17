using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform _target;         // Il player
    [SerializeField] private float _distance = 10f;       // Distanza orbitale
    [SerializeField] private float _xSpeed = 180f;       // Sensibilità orizzontale
    [SerializeField] private float _ySpeed = 120f;       // Sensibilità verticale
    [SerializeField] private float _yMin = -20f;         // Clamp verticale
    [SerializeField] private float _yMax = 80f;

    private float _yaw; // mouse X
    private float _pitch; // mouse Y 

    void Start()
    {
        if (_target == null) return;
        //Vector3 angles = transform.eulerAngles;
        //_yaw = angles.y;
        //_pitch = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (_target == null) return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _yaw += mouseX * _xSpeed * Time.deltaTime;
        _pitch -= mouseY * _ySpeed * Time.deltaTime;
        _pitch = Mathf.Clamp(_pitch, _yMin, _yMax);

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -_distance);

        transform.position = _target.position + offset;
        transform.LookAt(_target.position);
    }
}
