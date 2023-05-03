using UnityEngine;

namespace Charactor
{
    [CreateAssetMenu(fileName = "NewCharactorData", menuName = "Charactor/Config/Charactor Data", order = 0)]
    public class CharactorDataSO : ScriptableObject
    {
        [Header("Move")] 
        public float moveSpeed;
    }
}