using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using GHPC.Weapons;
using GHPC.Player; 

namespace ClearThermals
{
    public class ClearThermalsMod : MelonMod {
        GameObject mission; 

        public override void OnSceneWasInitialized(int buildIndex, string sceneName) {
            mission = GameObject.Find("_APP_GHPC_");
        }

        public override void OnUpdate() {
            if (mission == null) 
                return;

            if (mission.GetComponent<PlayerInput>() == null) 
                return;

            if (mission.GetComponent<PlayerInput>().CurrentPlayerWeapon == null)
                return;

            PlayerInput player = mission.GetComponent<PlayerInput>();
            FireControlSystem FCS = player.CurrentPlayerWeapon.FCS;
            GHPC.Camera.CameraSlot optic = null;

            if (FCS == null || FCS.MainOptic == null)
                return;

            optic = FCS.MainOptic.slot;
            
            if (optic != null && optic.VisionType == GHPC.Equipment.Optics.NightVisionType.Thermal)
            {
                optic.BaseBlur = 0;           
            }
        }
    }
}
