﻿using System;
using Transit.Framework.ExtensionPoints.PathFindingFeatures.Contracts;
using Transit.Framework.Network;

namespace Transit.Framework.ExtensionPoints.PathFindingFeatures.Implementations
{
    public class VanillaRoadRestrictionManager : IRoadRestrictionManager
    {
		public bool CanUseLane(uint laneId, ExtendedUnitType unitType) {
			return true;
		}

		public bool CanUseLane(ushort segmentId, byte laneIndex, uint laneId, NetInfo.Lane laneInfo, ExtendedUnitType unitType) {
			return true;
		}
	}
}
