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
            if (mission != null) {
                PlayerInput player = mission.GetComponent<PlayerInput>();

                if (player != null && player.CurrentPlayerWeapon != null)
                {
                    FireControlSystem FCS = player.CurrentPlayerWeapon.FCS;
                    GHPC.Camera.CameraSlot optic;

                    if (FCS.MainOptic != null)
                    {
                        optic = FCS.MainOptic.slot.LinkedNightSight;
                    }
                    else {
                        optic = FCS.gameObject.GetComponent<GHPC.Camera.CameraSlot>().LinkedNightSight;
                    }

                    if (optic && optic.VisionType == GHPC.Optics.NightVisionType.Thermal)
                    {
                        optic.BaseBlur = 0;           
                    }
                }
            }
        }
    }
}
