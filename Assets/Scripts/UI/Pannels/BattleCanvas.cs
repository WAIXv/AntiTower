using System;
using Charactor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Pannels
{
    public class BattleCanvas : MonoBehaviour
    {
        [SerializeField] private IntEventChannelSO CoinChangedEvent;

        [SerializeField] private CharactorDataSO _charactor_0_data;
        [SerializeField] private CharactorDataSO _charactor_1_data;
        [SerializeField] private CharactorDataSO _charactor_2_data;

        [SerializeField] private Text _charactor_0_cost;
        [SerializeField] private Text _charactor_1_cost;
        [SerializeField] private Text _charactor_2_cost;

        private Text _currentCoin;

        private void Awake()
        {
            _currentCoin = transform.GetComponentInChildren<Text>();
            _charactor_0_cost.text = _charactor_0_data.costValue.ToString();
            _charactor_1_cost.text = _charactor_1_data.costValue.ToString();
            _charactor_2_cost.text = _charactor_2_data.costValue.ToString();
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