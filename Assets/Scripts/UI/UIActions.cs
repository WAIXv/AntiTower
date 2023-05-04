using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    [CreateAssetMenu(fileName = "UIActions", menuName = "Game/UIActions")]
    public class UIActions : ScriptableObject
    {
        [SerializeField] private GameManager _gameManager;
        
        [Header("UI CanvasPrefab")]
        [SerializeField] private GameObject _winCanvasPrefab;
        [SerializeField] private GameObject _loseCanvasPrefab;
        [SerializeField] private GameObject _pauseCanvasPrefab;
        [SerializeField] private GameObject _restartLevelCanvasPrefab;
        
        private GameObject _pauseCanvasBuffer;
        private GameObject _restartLevelCanvasBuffer;

        private GameObject CreateUICanvas(GameObject prefab)
        {
            Time.timeScale = 0;
            var canvas = GameObject.Find("Canvas").transform;
            return Instantiate(prefab,canvas);
        }
        
        public void OnCharactorButtonPressed(int id)
        {
            _gameManager.SpawnCharactor(id);
        }

        public void OnGameStart()
        {
            SceneManager.LoadScene("Level01");
        }

        public void OnGameExit()
        {
            Application.Quit();
        }

        public void OnNextLevel()
        {
            var nextLevelIndex = _gameManager.CurrentLevelIndex + 1;
            var levelName = "Level0" + (nextLevelIndex + 1);
            SceneManager.LoadScene(levelName);
            _gameManager.OnNewLevelLoad(nextLevelIndex);
        }

        public void OnBackToMain()
        {
            SceneManager.LoadScene("StartScene");
        }

        public void OnGameWin()
        {
            Debug.LogError("Game Win");
            CreateUICanvas(_winCanvasPrefab);
        }
        
        public void OnGameLose()
        {
            Debug.LogError("Game Lose");
            CreateUICanvas(_loseCanvasPrefab);
        }

        public void OnPause()
        {
            _pauseCanvasBuffer = CreateUICanvas(_pauseCanvasPrefab);
        }

        public void OnRestartLevel()
        {
            _restartLevelCanvasBuffer = CreateUICanvas(_restartLevelCanvasPrefab);
        }

        public void OnRestartLevelCancled()
        {
            Time.timeScale = 1f;
            Destroy(_restartLevelCanvasBuffer);
        }
        
        public void OnResume()
        {
            Time.timeScale = 1f;
            Destroy(_pauseCanvasBuffer);
        }

        public void RestartLevel()
        {
            Debug.LogError("Restart");
            var levelName = "Level0" + (_gameManager.CurrentLevelIndex + 1);
            _gameManager.OnNewLevelLoad(_gameManager.CurrentLevelIndex);
            SceneManager.LoadScene(levelName);
        }
    }
}