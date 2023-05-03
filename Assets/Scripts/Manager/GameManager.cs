using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "Game/Game Manager")]
public class GameManager : ScriptableObject
{
    [Header("Level Config")] 
    [SerializeField] private List<LevelConfigSO> _levelConfigList;

    [Header("Charactors")]
    [SerializeField] private GameObject _charactor_0_prefab;
    [SerializeField] private GameObject _charactor_1_prefab;
    [SerializeField] private GameObject _charactor_2_prefab;

    [Header("Broadcasting on")]
    [SerializeField] private IntEventChannelSO CurrentCoinValueChangeEvent;
    [SerializeField] private IntEventChannelSO CoinToWinValueChangeEvent;

    [Header("Listening to")] 
    [SerializeField] private IntEventChannelSO CharactorArrivedEvent;

    public int CurrentCoin { get; set; }
    public int CoinToWin { get; set; }
    public PathNodeCube LevelStartCube { get; set; }

    private void OnEnable()
    {
        CharactorArrivedEvent.OnEventRaised += OnCharactorArrived;
    }

    private void OnDisable()
    {
        CharactorArrivedEvent.OnEventRaised -= OnCharactorArrived;
    }

    public void SpawnCharactor(int id)
    {
        GameObject go;
        switch (id)
        {
            case 0:
                go = _charactor_0_prefab;
                break;
            case 1:
                go = _charactor_1_prefab;
                break;
            case 2:
                go = _charactor_2_prefab;
                break;
            default:
                go = null;
                break;
        }
        
        if(CurrentCoin < go.GetComponent<Charactor.CharactorBrain>().data.costValue) 
            return;
        
        //角色初始化
        var target = LevelStartCube.transform;
        go = Instantiate(go, target.position, target.rotation);
        var charactor = go.GetComponent<Charactor.CharactorBrain>();
        
        charactor.CurrentCube = LevelStartCube;

        CurrentCoin -= charactor.data.costValue;
        CurrentCoinValueChangeEvent.RaiseEvent(CurrentCoin);
    }

    private void OnCharactorArrived(int delta)
    {
        CoinToWin -= delta;
        CoinToWinValueChangeEvent.RaiseEvent(CoinToWin);
    }

    public void OnNewLevelLoad(int index)
    {
        CurrentCoin = _levelConfigList[index].InitCoin;
        CoinToWin = _levelConfigList[index].CoinToWin;
        CurrentCoinValueChangeEvent.RaiseEvent(CurrentCoin);
        CoinToWinValueChangeEvent.RaiseEvent(CoinToWin);
    }
}
