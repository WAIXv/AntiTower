using UnityEngine;
using UnityEngine.Serialization;

namespace Charactor
{
    [CreateAssetMenu(fileName = "NewCharactorData", menuName = "Charactor/Config/Charactor Data", order = 0)]
    public class CharactorDataSO : ScriptableObject
    {
        [Header("Move")] 
        public float moveSpeed;

        [Header("Coin")] 
        public int costValue;
        
        [Header("Broadcasting on")]
        public IntEventChannelSO CharactorArrivedEvnet;
    }
}