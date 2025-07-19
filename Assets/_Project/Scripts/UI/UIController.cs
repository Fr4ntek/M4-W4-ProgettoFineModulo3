using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private TextMeshProUGUI _coinCounterText;
    [SerializeField] private GameObject _coinWarningMessage;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _countdownTime = 60f;
    [SerializeField] private GameManager _gameManager;

    public int _coinCount = 0;
    private float _timeLeft;
    private bool _isRunning = false;
    private LifeController _lifeController;



    void Start()
    {
        _lifeController = GetComponent<LifeController>();
        UpdateCoinUI();
        SetTimerUI();
    }

    private void SetTimerUI()
    {
        _timeLeft = _countdownTime;
        _isRunning = true;
    }

    void Update()
    {
        UpdateTimerUI();   
    }

    private void UpdateTimerUI()
    {
        if (!_isRunning) return;
        _timeLeft -= Time.deltaTime;
        _timeLeft = Mathf.Max(0f, _timeLeft);

        int minutes = Mathf.FloorToInt(_timeLeft / 60f);
        int seconds = Mathf.FloorToInt(_timeLeft % 60f);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (_timeLeft <= 0f)
        {
            _isRunning = false;
            _lifeController.Die();
        }
    }

    public void AddCoin(int amount)
    {
        _coinCount += amount;
        UpdateCoinUI();
    }

    public void CheckCoins()
    {
        if (_coinCount >= 15)
        {
            _gameManager.ChangeScene("Level2");
        }
        else
        {
            StartCoroutine(ShowWarningMessage());
        }
    }

    private IEnumerator ShowWarningMessage()
    {
        _coinWarningMessage.SetActive(true);
        yield return new WaitForSeconds(2f);
        _coinWarningMessage.SetActive(false);
    }

    private void UpdateCoinUI()
    {
        _coinCounterText.text = "x " + _coinCount.ToString();
    }

    public void UpdateHealthBar(int hp, int maxHp)
    {
        _healthBarSprite.fillAmount = (float)hp / maxHp;
        _healthBarSprite.color = _gradient.Evaluate(_healthBarSprite.fillAmount);
    }

}
