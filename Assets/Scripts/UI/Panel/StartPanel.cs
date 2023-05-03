using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;
using XFramework.Extend;

/// <summary>
/// 开始面板
/// </summary>
public class StartPanel : BasePanel
{
    /// <summary>
    /// 路径
    /// </summary>
    static readonly string path = "Prefabs/UI/Panel/StartPanel";

    /// <summary>
    /// 开始面板
    /// </summary>
    public StartPanel() : base(new UIType(path))
    {

    }

    protected override void InitEvent()
    {
        // ActivePanel.GetOrAddComponentInChildren<Button>("BtnSetting").onClick.AddListener(() =>
        // {
        //     Push(new SettingPanel());
        // });

        // quit
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnQuit").onClick.AddListener(() =>
        {
            #if UNITY_EDITOR                                        // quit unity_editor
	            UnityEditor.EditorApplication.isPlaying = false;
            #else                                                   // quit game
	            UnityEngine.Application.Quit();
            #endif
        });

        // choose your level
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnGame").onClick.AddListener(() =>
        {
            Push(new LevelPanel());
        });

        // start game(to main = level1)
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnPlay").onClick.AddListener(() =>
        {
            Game.LoadScene(new MainScene());
        });
    }
}
