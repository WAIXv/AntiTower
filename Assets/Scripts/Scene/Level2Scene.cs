using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XFramework;

public class Level2Scene : SceneState
{
    /// <summary>
    /// Level2 Scene
    /// </summary>
    public Level2Scene()
    {
        sceneName = "Level2";
    }

    public override void OnEnter()
    {
        panelManager.Push(new Level2Panel());
    }
}
