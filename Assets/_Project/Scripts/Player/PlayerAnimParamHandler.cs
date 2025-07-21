using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimParamHandler : MonoBehaviour
{
    [SerializeField] private string _paramNameV = "vertical";
    [SerializeField] private string _paramNameH = "horizontal";
    [SerializeField] private string _paramNameRun = "isRunning";

    private Animator _anim;
    private PlayerController _playerController;
    private float v;
    private float h;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    
    void Update()
    {
        if(_playerController.IsRunning && (_playerController.Vertical != 0 || _playerController.Horizontal != 0))
        {
            _anim.SetBool(_paramNameRun, true);
        }
        else
        {
            _anim.SetBool(_paramNameRun, false);
        }
        _anim.SetFloat(_paramNameV, _playerController.Vertical); 
        _anim.SetFloat(_paramNameH, _playerController.Horizontal);
        
    }
}
