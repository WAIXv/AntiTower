using System;
using UnityEngine;

namespace Manager
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private int _currentLevelIndex;
        private void OnEnable()
        {
            _gameManager.OnNewLevelLoad(_currentLevelIndex);
        }
    }
}