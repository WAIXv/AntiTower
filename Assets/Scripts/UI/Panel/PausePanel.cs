using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;
using XFramework.Extend;

/// <summary>
/// 暂停面板
/// </summary>
public class PausePanel : BasePanel
{
    /// <summary>
    /// 路径
    /// </summary>
    static readonly string path = "Prefabs/UI/Panel/PausePanel";

    /// <summary>
    /// 设置面板
    /// </summary>
    public PausePanel() : base(new UIType(path)){}

    
    protected override void InitEvent()
    {
        //Press BtnExit to continue game
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnExit").onClick.AddListener(() =>
        {
            Pop();
        });
        //Press BtuQuit back to StartScene
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnQuit").onClick.AddListener(() =>
        {
            Game.LoadScene(new StartScene());
        });
    }
}
