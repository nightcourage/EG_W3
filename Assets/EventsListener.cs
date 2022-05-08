using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventsListener : MonoBehaviour
{
    [SerializeField] private GameObject _winPannel;
    [SerializeField] private ObjectSpawner _objectSpawner;

    private int _totalCoins;
    private int _leftCoins;
    [SerializeField]private TextMeshProUGUI _winText;
    
    private void Start()
    {
        _totalCoins = _objectSpawner.GetObjectsAmount();
        _winPannel.SetActive(false);
    }
    
    private void Update()
    {
        _leftCoins = _objectSpawner.GetObjectsAmount();
        ShowWin(CheckGameEnd());
    }

    private bool CheckGameEnd()
    {
        return _leftCoins == 0;
    }
    
    private void ShowWin(bool isFinished)
    {
        if (isFinished)
        {
            _winPannel.SetActive(true);
            _winText.text = $"You won and collected: {_totalCoins}";
        }
    }
}
