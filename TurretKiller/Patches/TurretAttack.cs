using System.Collections;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace TurretKiller
{

    [HarmonyPatch(typeof(Turret))]
    internal class TurretPatch
    {
        [HarmonyPatch(typeof(Turret), "IHittable.Hit")]
        [HarmonyPrefix]
        public static bool HitDisablePatch(ref TurretMode ___turretMode, ref Turret __instance)
        {

            if (!TurretPatch.turretHitPatchMB)
            {

                TurretPatch.turretHitPatchMB = __instance.gameObject.AddComponent<TurretPatch.TurretHitPatchMB>();
            }

            __instance.ToggleTurretEnabled(false);
            __instance.ToggleTurretClientRpc(false);
            __instance.ToggleTurretServerRpc(false);
            __instance.StopAllCoroutines();





            return false;

        }


        private static TurretPatch.TurretHitPatchMB turretHitPatchMB;

        public class TurretHitPatchMB : MonoBehaviour { }

    }
}
