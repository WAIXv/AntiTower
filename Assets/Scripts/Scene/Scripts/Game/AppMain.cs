using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class AppMain : MonoBehaviour
{
    public ScreenType screenType = ScreenType.Screen_1;
    public GameObject scene1;
    public GameObject scene2;

    void Awake()
    {
        //场景初始化
        if (scene1!= null && scene2 != null)
        {
            scene1.SetActive(screenType == ScreenType.Screen_1 || screenType == ScreenType.Total);
            scene2.SetActive(screenType == ScreenType.Screen_2 || screenType == ScreenType.Total);
        }
        //数据初始化
        GameCache.screenType = screenType;
        GameCache.Init();
        ActionCenter.Instance.Init();
        //加载图片资源
        string path = Application.streamingAssetsPath;
       // string[] picPath = Directory.GetFiles(path);
        //for (int i = 0; i < picPath.Length; i++)
        //{
        //    if (!picPath[i].EndsWith(".meta"))
        //    {
        //        WebService.Instance.GetTexture(picPath[i], OnGetTexture);
        //    }
        //}
        //场景开始
        ActionCenter.Instance.DoActionDelay(StartScene, 0.3f);
    }

    void StartScene()
    {
        //ActionCenter.Instance.DoAction(GameEvent.OpenPage, PageType.Main);
        ActionCenter.Instance.DoAction(GameEvent.SwitchScene, SceneType.Main);
    }


    void Update()
    {
        //截图操作
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    string name = Application.dataPath + "/screenShot_" + UnityEngine.Random.Range(1, 10000) + ".png";
        //    ScreenCapture.CaptureScreenshot(name);
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }

    void OnGetTexture(string path, Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        sprite.name = Path.GetFileNameWithoutExtension(path);
        if (GameCache.imageDic.ContainsKey(sprite.name))
        {
            GameCache.imageDic[sprite.name] = sprite;
        }
        else
        {
            GameCache.imageDic.Add(sprite.name, sprite);
        }
    }





}
