using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
namespace TurretKiller
{
    [BepInPlugin("TurretKiller", "TurretKiller", "0.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new("TurretKiller");
        internal static ManualLogSource logger;

        private void Awake()
        {
            harmony.PatchAll();
            // Plugin startup TurretKiller
            Logger.LogInfo($"Plugin TurretKiller is loaded!");

        }
    }
}
