using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;


namespace AotrsLichCreationTome
{
    public class CompTargetEffect_LichCreationEffect : CompTargetEffect
    {
        public List<string> blackListedXenotypes = new List<string>()
        {
            "VREA_AndroidBasic",
            "VREA_AndroidAwakened"
        };
        
        public CompProperties_TargetEffect_LichCreationEffect Props
        {
            get => (CompProperties_TargetEffect_LichCreationEffect) ((ThingComp) this).props;
        }
        
        public virtual void DoEffectOn(Pawn user, Thing target)
        {
            if (!user.IsColonistPlayerControlled || !ReservationUtility.CanReserveAndReach(user, LocalTargetInfo.op_Implicit(target), (PathEndMode) 2, (Danger) 3, 1, -1, (ReservationLayerDef) null, false))
                return;
            Pawn pawn = target as Pawn;
            if (pawn.health.hediffSet.GetFirstHediffOfDef(InternalDefOf.AG_GeneRemovalComa, false) == null)
            {
                Pawn_GeneTracker genes = pawn.genes;
                if (genes != null && genes.GenesListForReading.Count > 0)
                {
                    foreach (Gene gene in pawn.genes?.GenesListForReading)
                        pawn.genes?.RemoveGene(gene);
                }
                XenotypeDef xenotypeDef = Aotrs_Lich;
                pawn.genes?.SetXenotype(xenotypeDef);
                user.carryTracker.DestroyCarriedThing();
                pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(InternalDefOf.AG_UsedXenotypeInjector, (Pawn) null, (Precept) null);
                if (AlphaGenes_Mod.settings.AG_GeneRemovalComa)
                    pawn.health.AddHediff(InternalDefOf.AG_GeneRemovalComa, (BodyPartRecord) null, new DamageInfo?(), (DamageWorker.DamageResult) null);
            }
        }
    }
}