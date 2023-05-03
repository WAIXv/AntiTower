
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameCache
{
    public static int screenWidth = 1856;
    public static int screenHeight = 812;
    public static ScreenType screenType = ScreenType.Screen_1;

    public static List<Transform> pointList1 = new List<Transform>();
    public static List<Transform> pointList2 = new List<Transform>();
    public static Vector3[] path1;
    public static Vector3[] path2;

    public static Dictionary<string, Sprite> iconDic = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();

    public static SceneType currentScene = SceneType.Null;

    
    //初始化
    public static void Init()
    {
        int width = Screen.resolutions[Screen.resolutions.Length - 1].width;
        int height = Screen.resolutions[Screen.resolutions.Length - 1].height;

        Screen.SetResolution(width, height, true);
        //加载图片资源
        Sprite[] icons = Resources.LoadAll<Sprite>("icons");
        for (int i = 0; i < icons.Length; i++)
        {
            string name = icons[i].name;
            if (iconDic.ContainsKey(name))
            {
                iconDic[name] = icons[i];
            }
            else
            {
                iconDic.Add(name, icons[i]);
            }
        }
    }

    

}
