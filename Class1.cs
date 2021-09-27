using System;
using System.Collections.Generic;
using HarmonyLib;
using BepInEx;
using UnityEngine;
using System.Reflection;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.UI;
using System.IO;
using System.Net;
using Photon.Realtime;
using UnityEngine.Rendering;

namespace NoTagLag
{
    [BepInPlugin("org.kokuchi.monkeytag.notaglag", "BE GONE TAGLAG!", "1.0.0")]
    public class MyMenuPatcher : BaseUnityPlugin
    {
        public void Awake()
        {
            var harmony = new Harmony("com.kokuchi.monkeytag.notaglag");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("Update", MethodType.Normal)]
    public class Class1
    {
        static bool triggerDown = false;
        static void Postfix(GorillaLocomotion.Player __instance)
        {
                {
                    List<InputDevice> list = new List<InputDevice>();
                    InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller, list);
                    list[0].TryGetFeatureValue(CommonUsages.triggerButton, out triggerDown);

                    // LEAVE LOBBY \\
                    if(triggerDown)
                    {
                        PhotonNetwork.Disconnect();
                    }
                }
            }
        }
    }

// MADE BY KOKUCHI \\