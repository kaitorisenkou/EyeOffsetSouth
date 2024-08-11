using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace EyeOffsetSouth {
    [StaticConstructorOnStartup]
    public class EyeOffsetSouth {
        static EyeOffsetSouth() {
            Log.Message("[EyeOffsetSouth] Now active");
            var harmony = new Harmony("kaitorisenkou.EyeOffsetSouth");
            harmony.Patch(
                AccessTools.Method(typeof(PawnDrawUtility), nameof(PawnDrawUtility.CalcAnchorData), null, null),
                null,
                new HarmonyMethod(typeof(EyeOffsetSouth), nameof(Patch_CalcAnchorData), null),
                null,
                null
                );
            Log.Message("[EyeOffsetSouth] Harmony patch complete!");
        }

        public static void Patch_CalcAnchorData(Pawn pawn, BodyTypeDef.WoundAnchor anchor, Rot4 pawnRot, ref Vector3 anchorOffset) {
            if ((anchor.tag == "LeftEye" || anchor.tag == "RightEye") && pawnRot.AsInt==2 && (!ModsConfig.BiotechActive || !pawn.DevelopmentalStage.Juvenile())) {
                Log.Message("[EyeOffsetSouth] " + anchorOffset);
                var modExt = pawn.story.headType.GetModExtension<ModExtension_EyeOffsetSouth>();
                if (modExt != null) {
                    anchorOffset += modExt.offset;
                }
            }
        }
    }
}
