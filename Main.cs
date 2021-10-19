using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityModManagerNet;
using HarmonyLib;
using System.Reflection;

namespace AdofaiModTemplate {
    public static class Main {
        public static UnityModManager.ModEntry.ModLogger Logger;
        public static Harmony harmony;
        public static bool isEnabled = false;

        public static void Setup(UnityModManager.ModEntry modEntry) {
            Logger = modEntry.Logger;
            modEntry.OnToggle = onToggle;
        }

        private static bool onToggle(UnityModManager.ModEntry modEntry, bool value) {
            isEnabled = true;

            if(value) {
                harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            } else {
                harmony.UnpatchAll(modEntry.Info.Id);
            }
            return true;
        }
    }
}
