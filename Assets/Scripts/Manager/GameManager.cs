using System;
using System.Collections.Generic;
using UI;
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

    [SerializeField] private UIActions UIActions;

    [Header("Broadcasting on")]
    [SerializeField] private IntEventChannelSO CurrentCoinValueChangeEvent;
    [SerializeField] private IntEventChannelSO CoinToWinValueChangeEvent;

    [Header("Listening to")] 
    [SerializeField] private IntEventChannelSO CharactorArrivedEvent;
    [SerializeField] private VoidEventChannelSO CharactorDieEvent;
    
    public int CurrentCoin { get; set; }
    public int CoinToWin { get; set; }
    public PathNodeCube LevelStartCube { get; set; }
    public int CurrentLevelIndex { get; set; } = 0;
    public int CurrentCharactorCount
    {
        get => _currentCharactorCount;
        set
        {
            _currentCharactorCount = value;
            if (_currentCharactorCount <= 0 && CurrentCoin < 10)
            {
                UIActions.OnGameLose();
            }
        }
    }

    private int _currentCharactorCount = 0;

    private void OnEnable()
    {
        CharactorArrivedEvent.OnEventRaised += OnCharactorArrived;
        CharactorDieEvent.OnEventRaised += OnCharactorDie;
    }

    private void OnDisable()
    {
        CharactorArrivedEvent.OnEventRaised -= OnCharactorArrived;
        CharactorDieEvent.OnEventRaised -= OnCharactorDie;
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
        CurrentCharactorCount++;
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
        CurrentCharactorCount--;
        
        if(CoinToWin < 0)
        {
            CoinToWin = 0;
            UIActions.OnGameWin();
        }
        CoinToWinValueChangeEvent.RaiseEvent(CoinToWin);
    }
    
    private void OnCharactorDie()
    {
        CurrentCharactorCount--;
    }
    

    public void OnNewLevelLoad(int index)
    {
        Time.timeScale = 1f;
        CurrentCoin = _levelConfigList[index].InitCoin;
        CoinToWin = _levelConfigList[index].CoinToWin;
        CurrentCharactorCount = 0;
        CurrentCoinValueChangeEvent.RaiseEvent(CurrentCoin);
        CoinToWinValueChangeEvent.RaiseEvent(CoinToWin);
    }
}
