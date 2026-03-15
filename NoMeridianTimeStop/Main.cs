using BepInEx;
using RoR2;
using RoR2.ContentManagement;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace NoMeridianTimeStop
{
  [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
  public class Main : BaseUnityPlugin
  {
    public const string PluginGUID = PluginAuthor + "." + PluginName;
    public const string PluginAuthor = "Nuxlar";
    public const string PluginName = "NoMeridianTimeStop";
    public const string PluginVersion = "1.0.0";

    internal static Main Instance { get; private set; }
    public static string PluginDirectory { get; private set; }

    public void Awake()
    {
      Instance = this;

      Log.Init(Logger);
      LoadAssets();
    }

    private static void LoadAssets()
    {
      AssetReferenceT<SceneDef> stage1Ref = new AssetReferenceT<SceneDef>(RoR2BepInExPack.GameAssetPaths.Version_1_39_0.RoR2_DLC2_meridian.meridian_asset);
      AssetAsyncReferenceManager<SceneDef>.LoadAsset(stage1Ref).Completed += (x) =>
      {
        SceneDef def = x.Result;
        UnityEngine.Debug.LogWarning("SCENE TYPE: " + def.sceneType);
        def.sceneType = SceneType.Stage;
      };
    }
  }
}