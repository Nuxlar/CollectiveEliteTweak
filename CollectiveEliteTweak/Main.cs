using BepInEx;
using RoR2.ContentManagement;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CollectiveEliteTweak
{
  [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
  public class Main : BaseUnityPlugin
  {
    public const string PluginGUID = PluginAuthor + "." + PluginName;
    public const string PluginAuthor = "Nuxlar";
    public const string PluginName = "CollectiveEliteTweak";
    public const string PluginVersion = "1.0.0";

    internal static Main Instance { get; private set; }
    public static string PluginDirectory { get; private set; }

    public void Awake()
    {
      Instance = this;

      Log.Init(Logger);

      On.RoR2.AffixCollectiveAttachmentBehaviour.Awake += (orig, self) =>
      {
        orig(self);
        self.gameObject.AddComponent<NuxNoShieldinator>();
      };
    }
  }
}