﻿using Transit.Framework.Modularity;

namespace Transit.Addon.TrafficPP
{
    [Module(Mod = typeof(Mod))]
    public partial class TrafficPPModule : ModuleBase
    {
        public override string Name
        {
            get { return "Traffic++"; }
        }
    }
}