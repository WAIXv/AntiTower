using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;
using XFramework.Extend;

/// <summary>
/// Win Panel
/// </summary>
public class WinPanel : BasePanel
{
    /// <summary>
    /// 路径
    /// </summary>
    static readonly string path = "Prefabs/UI/Panel/WinPanel";

    /// <summary>
    /// 设置面板
    /// </summary>
    public WinPanel() : base(new UIType(path)){}

    
    protected override void InitEvent()
    {
        //Press BtnNext to next level
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnNext").onClick.AddListener(() =>
        {
            Game.LoadScene(new Level2Scene());
        });
        //Press BtuQuit back to StartScene
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnQuit").onClick.AddListener(() =>
        {
            Game.LoadScene(new StartScene());
        });
    }
}
