using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;
using XFramework.Extend;

public class MainPanel : BasePanel
{
    /// <summary>
    /// 路径
    /// </summary>
    static readonly string path = "Prefabs/UI/Panel/MainPanel";

    /// <summary>
    /// 主面板 = level1
    /// </summary>
    public MainPanel() : base(new UIType(path))
    {

    }

    protected override void InitEvent()
    {
        // ActivePanel.GetOrAddComponentInChildren<Button>("BtnSetting").onClick.AddListener(() =>
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnPause").onClick.AddListener(() =>
        {
            Push(new PausePanel());
        });
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnRestart").onClick.AddListener(() =>
        {
            Push(new RestartPanel());
            // Game.LoadScene(new StartScene());
        });

        ActivePanel.GetOrAddComponentInChildren<Button>("BtnWin").onClick.AddListener(() =>
        {
            Push(new WinPanel());
        });
        // ActivePanel.GetOrAddComponentInChildren<Button>("BtnMsg").onClick.AddListener(() =>
        // {
        //     Push(new TaskPanel());
        // });
        // Transform parent = ActivePanel.GetOrAddComponentInChildren<Transform>("skillPanel");
        // for (int i = 0; i < parent.childCount; i++)
        // {
        //     int index = i + 1;
        //     parent.GetChild(i).GetComponent<Button>().onClick.AddListener(() =>
        //     {
        //         Push(new WarningPanel($"这是技能{index}"));
        //     });
        // }
    }
}
