using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "UIActions", menuName = "Game/UIActions")]
    public class UIActions : ScriptableObject
    {
        [SerializeField] private GameManager _gameManager;
        
        public void OnCharactorButtonPressed(int id)
        {
            _gameManager.SpawnCharactor(id);
        }
    }
}