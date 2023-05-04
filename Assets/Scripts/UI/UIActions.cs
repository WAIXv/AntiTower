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
            var levelName = "Level01" + nextLevelIndex;
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
            Time.timeScale = 0;
            var go = Instantiate(_winCanvasPrefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(GameObject.Find("Canvas").transform);
            go.GetComponent<RectTransform>().position = Vector3.zero;
        }
    }
}