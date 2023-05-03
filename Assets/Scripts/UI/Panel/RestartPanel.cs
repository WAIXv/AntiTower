using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;
using XFramework.Extend;

/// <summary>
/// 暂停面板
/// </summary>
public class RestartPanel : BasePanel
{
    /// <summary>
    /// 路径
    /// </summary>
    static readonly string path = "Prefabs/UI/Panel/RestartPanel";

    /// <summary>
    /// 设置面板
    /// </summary>
    public RestartPanel() : base(new UIType(path)){}

    
    protected override void InitEvent()
    {
        //Press BtnNo to return current level
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnNo").onClick.AddListener(() =>
        {
            Pop();
        });
        //Press BtnYes to restart current level
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnYes").onClick.AddListener(() =>
        {
            Game.LoadScene(new MainScene());
        });
    }
}
