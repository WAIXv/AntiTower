using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Pannels
{
    public class BattleCanvas : MonoBehaviour
    {
        [SerializeField] private IntEventChannelSO CoinChangedEvent;

        private Text _currentCoin;

        private void Awake()
        {
            _currentCoin = transform.GetComponentInChildren<Text>();
        }

        private void OnEnable()
        {
            CoinChangedEvent.OnEventRaised += OnCoinChanged;
        }

        private void OnDisable()
        {
            CoinChangedEvent.OnEventRaised -= OnCoinChanged;
        }

        private void OnCoinChanged(int newValue)
        {
            _currentCoin.text = newValue.ToString();
        }
    }
}