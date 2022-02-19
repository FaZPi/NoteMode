﻿using HarmonyLib;
using NoteMode.Configuration;
using System.Reflection;

namespace NoteMode.HarmonyPatches
{
    [HarmonyPatch(typeof(BeatmapObjectManager), "SpawnBasicNote")]
    public class BeatmapObjectManagerSpawnBasicNote
    {

        static bool Prefix(ref NoteData noteData)
        {
            if ((noteData.colorType == ColorType.ColorA) && PluginConfig.Instance.noRed)
            {
                return false;
            }
            else if ((noteData.colorType == ColorType.ColorB) && PluginConfig.Instance.noBlue)
            {
                return false;
            }

            if (PluginConfig.Instance.noNotesBomb)
            {
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(BeatmapObjectManager), "SpawnBombNote")]
    public class BeatmapOjbectManagerSpawnBombNote
    {
        static bool Prefix(ref NoteData noteData)
        {
            if (PluginConfig.Instance.noNotesBomb)
            {
                return false;
            }
            return true;
        }
    }
}