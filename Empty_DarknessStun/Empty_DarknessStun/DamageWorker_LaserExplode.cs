using RimWorld;
using Verse;

namespace Empty_DarknessStun
{
    public class DamageWorker_LaserExplode : DamageWorker_AddInjury
    {
        public override DamageResult Apply(DamageInfo dinfo, Thing thing)
        {
            var try_pawn = thing as Pawn;
            //just in case something goes south, which might be not under my control
            //i dont want any exceptions to be thrown during the game as it ruins user's experience.
            try
            {
                if ((try_pawn != null && (!try_pawn.Downed || try_pawn.Downed && try_pawn.HealthScale != 0) || thing.BlocksPawn(thing as Pawn) ||(thing as Building) != null))
                    GenExplosion.DoExplosion(thing.Position, thing.Map, 3f, DamageDefOf.Bomb, dinfo.Instigator, explosionSound: this.def.soundExplosion, damAmount: 20);
            }
            catch { }

            return base.Apply(dinfo, thing);
        }
    }
}
