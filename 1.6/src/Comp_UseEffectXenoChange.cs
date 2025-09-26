using RimWorld;
using Verse;

namespace LichGenePatch;

public class Comp_UseEffectXenoChange : CompUseEffect
{
    public CompProperties_UseEffectXenoChange Props => (CompProperties_UseEffectXenoChange) props;

    public override void DoEffect(Pawn pawn)
    {
        if (pawn == null || pawn.Dead || pawn.Destroyed || pawn.genes == null || Props.targetXenotype == null)
            return;
        pawn.genes.SetXenotype(Props.targetXenotype);
        Messages.Message("Aotrs_XenoChange_UseMessage".Translate(pawn.NameShortColored), pawn, MessageTypeDefOf.NeutralEvent, true);
    }
}
