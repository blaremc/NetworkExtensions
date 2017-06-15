using System.Collections.Generic;
using System.Linq;
using Transit.Addon.RoadExtensions.Menus;
using Transit.Addon.RoadExtensions.Menus.Roads;
using Transit.Addon.RoadExtensions.Roads.Common;
using Transit.Framework;
using Transit.Framework.Builders;
using Transit.Framework.Network;
using UnityEngine;

namespace Transit.Addon.RoadExtensions.Roads.SmallRoads.OneWay1LParkingBicycle
{
    public partial class TestRoadBuilder : Activable, INetInfoBuilderPart
    {
        public int Order { get { return 20; } }
        public int UIOrder { get { return 12; } }

        public string BasedPrefabName { get { return NetInfos.Vanilla.ROAD_2L; } }
        public string Name { get { return "TestRoad"; } }
        public string DisplayName { get { return "TestRoad"; } }
        public string Description { get { return "TestRoad"; } }
        public string ShortDescription { get { return "Zoneable, medium traffic"; } }
        public string UICategory { get { return "RoadsSmall"; } }

        public string ThumbnailsPath    { get { return @"Roads\SmallRoads\TestRoad\thumbnails.png"; } }
        public string InfoTooltipPath   { get { return @"Roads\SmallRoads\TestRoad\infotooltip.png"; } }

        public NetInfoVersion SupportedVersions
        {
            get { return NetInfoVersion.Ground; }
        }

        public void BuildUp(NetInfo info, NetInfoVersion version)
        {
            ///////////////////////////
            // Template              //
            ///////////////////////////

            ///////////////////////////
            // 3DModeling            //
            ///////////////////////////
            info.Setup16m2mSWTestMesh(version);

            ///////////////////////////
            // Texturing             //
            ///////////////////////////
            SetupTextures(info, version);

            ///////////////////////////
            // Set up                //
            ///////////////////////////
            info.m_hasParkingSpaces = true;

            info.m_pavementWidth = (version != NetInfoVersion.Slope && version != NetInfoVersion.Tunnel ? 2 : 5);
            info.m_halfWidth = (version != NetInfoVersion.Slope && version != NetInfoVersion.Tunnel ? 8 : 11);
            info.m_canCrossLanes = false;
         
                info.m_class = info.m_class.Clone("NEXTTestRoad" + version.ToString());

            // Setting up lanes
            info.SetRoadLanes(version, new LanesConfiguration
            {
                IsTwoWay = true,
                LanesToAdd = 1,
                PedPropOffsetX = 0.5f,
                BusStopOffset = 0f,
                LaneWidth = 3.3f,
                SpeedLimit = 0.8f,

            });
            

            info.TrimAboveGroundProps(version);
            info.SetupNewSpeedLimitProps(50, 40);

            /*
            // AI
            var owPlayerNetAI = owRoadInfo.GetComponent<PlayerNetAI>();
            var playerNetAI = info.GetComponent<PlayerNetAI>();

            if (owPlayerNetAI != null && playerNetAI != null)
            {
                playerNetAI.m_constructionCost = owPlayerNetAI.m_constructionCost * 2; // Charge by the lane?
                playerNetAI.m_maintenanceCost = owPlayerNetAI.m_maintenanceCost * 2; // Charge by the lane?
            }
            */
            // TODO: make it configurable
            var roadBaseAI = info.GetComponent<RoadBaseAI>();
            if (roadBaseAI != null)
            {
                roadBaseAI.m_trafficLights = false;
            }
        }
    }
}
