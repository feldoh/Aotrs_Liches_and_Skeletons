using RimWorld;
using Verse;

namespace LichGenePatch;

public class CompProperties_UseEffectXenoChange : CompProperties_UseEffect
{
    public XenotypeDef targetXenotype;

    public CompProperties_UseEffectXenoChange()
    {
        compClass = typeof(Comp_UseEffectXenoChange);
    }

    public override void ResolveReferences(ThingDef parentDef)
    {
        base.ResolveReferences(parentDef);
        if (targetXenotype == null)
        {
            Log.Error($"Aotrs: {parentDef.defName} has CompProperties_UseEffectXenoChange but no targetXenotype defined.");
        }
    }
}
