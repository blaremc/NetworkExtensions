﻿using Transit.Framework.ExtensionPoints.PathFindingFeatures.Contracts;
using Transit.Framework.Network;

namespace Transit.Addon.ToolsV2.PathFindingFeatures
{
    public class TPPRoadSpeedManager : IRoadSpeedManager
    {
        public float GetLaneSpeedLimit(ushort segmentId, uint laneIndex, uint laneId, NetInfo.Lane laneInfo, ExtendedUnitType unitType)
        {
            if ((unitType & TPPSupported.UNITS) == 0)
            {
                return laneInfo.m_speedLimit;
            }

			return TPPLaneDataManager.GetLaneSpeedRestriction(laneId, laneInfo);
        }
    }
}
