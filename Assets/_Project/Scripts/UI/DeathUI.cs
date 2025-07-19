using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PauseMenu;

public class DeathUI : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    private void OnTriggerEnter(Collider other)
    { 
        canvas.SetActive(true);
        Time.timeScale = 0;   
    }
}
