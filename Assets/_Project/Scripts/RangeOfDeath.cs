using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeOfDeath : MonoBehaviour
{
    [SerializeField] private float _timeLimit = 10f;
    
    private bool _timerActive = false;
    private bool _isCrouchedInTime = false;
    private Coroutine _timerCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (!_timerActive && other.CompareTag("Player"))
        {
            _timerActive = true;
            _isCrouchedInTime = false;
            _timerCoroutine = StartCoroutine(CountdownToDeath());
        }
    }

    private IEnumerator CountdownToDeath()
    {
        Debug.Log("Timer partito: hai " + _timeLimit + " secondi per premere Crouch!");
        yield return new WaitForSeconds(_timeLimit);

        if (!_isCrouchedInTime)
        {
            Debug.Log("Tempo scaduto. Muori!");
            //KillPlayer(); // o esegui un’animazione, carica una scena, ecc.
        }
        _timerActive = false;
    }
}

