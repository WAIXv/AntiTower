using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Pannels
{
    public class CoinToWinCanvas : MonoBehaviour
    {
        [SerializeField] private IntEventChannelSO CoinToWinChangedEvent;
        
        private Text _currentCoinToWin;

        private void Awake()
        {
            _currentCoinToWin = transform.GetComponentInChildren<Text>();
        }
        
        private void OnEnable()
        {
            CoinToWinChangedEvent.OnEventRaised += OnCoinToWinChanged;
        }
        
        private void OnCoinToWinChanged(int newValue)
        {
            Debug.Log($"CoinToWinCanvas Update: {newValue}");
            _currentCoinToWin.text = newValue.ToString();
        }
    }
}