using Transit.Framework.Modularity;

namespace Transit.Addon.RoadExtensions
{
    [Module("Transit.Addon.Mod", "NetworkExtensions.Mod")]
    public partial class RExModule : ModuleBase
    {
        public const string REX_OBJECT_NAME = "BRoads For NExt";

        public const string ROAD_NETCOLLECTION = "Road";
        public const string REX_NETCOLLECTION = "BTAM Road";
        public const string REX_PROPCOLLECTION = "BTAM Prop";

        public override string Name
        {
            get { return "Roads"; }
        }

        public override int Order
        {
            get { return 1; }
        }
    }
}
