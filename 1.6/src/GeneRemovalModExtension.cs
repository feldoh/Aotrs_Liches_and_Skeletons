using System.Collections.Generic;
using Verse;

namespace LichGenePatch;

public class GeneRemovalModExtension : DefModExtension
{
    public GeneDef keyGene;
    public List<GeneDef> genesToRemove;

    public bool IsGeneDisallowed(GeneDef Gene)
    {
        return genesToRemove.Contains(Gene);
    }
}
