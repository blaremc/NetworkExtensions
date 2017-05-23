using System.Collections.Generic;
using System.Linq;
using Transit.Addon.RoadExtensions.Compatibility;
using Transit.Addon.RoadExtensions.Props;
using Transit.Addon.RoadExtensions.Roads.Common;
using Transit.Framework;
using Transit.Framework.Builders;
using Transit.Framework.Network;
using UnityEngine;
#if DEBUG
using Debug = Transit.Framework.Debug;
#endif
namespace Transit.Addon.RoadExtensions.Roads.Avenues.LargeAvenue8LSideParking
{
    public partial class LargeAvenue8LSideParkingBuilder : Activable, IMultiNetInfoBuilderPart
    {
        public int Order { get { return 25; } }

        public string BasedPrefabName { get { return NetInfos.Vanilla.ROAD_4L; } }
        public string Name { get { return "FourDevidedLaneAvenue4Parking"; } }
        public string DisplayName { get { return "Four-Devided-Lane Avenue With 4 Parking"; } }
        public string Description { get { return "An four-lane road with paved median. Supports heavy urban traffic."; } }
        public string ShortDescription { get { return "No parking, zoneable, heavy urban traffic"; } }
        
        
        public NetInfoVersion SupportedVersions
        {
            get { return NetInfoVersion.Ground | NetInfoVersion.GroundGrass | NetInfoVersion.GroundTrees; }
        }

        public IEnumerable<IMenuItemBuilder> MenuItemBuilders
        {
            get
            {
                yield return new MenuItemBuilder
                {
                    UICategory = "RoadsMedium",
                    UIOrder = 17,
                    Name = "FourDevidedLaneAvenue4Parking",
                    DisplayName = "Four-Devided-Lane Avenue With 4 Parking",
                    Description = "A basic two lane road with a median and no parkings spaces. Supports local traffic.",
                    ThumbnailsPath = @"Roads\Avenues\LargeAvenue8LSideParking\thumbnails.png",
                    InfoTooltipPath = @"Roads\Avenues\LargeAvenue8LSideParking\infotooltip.png"
                };
                yield return new MenuItemBuilder
                {
                    UICategory = "RoadsMedium",
                    UIOrder = 18,
                    Name = "FourDevidedLaneAvenue4Parking Decoration Grass",
                    DisplayName = "Four-Devided-Lane Avenue With 4 Parking and Grass",
                    Description = "A basic two lane road with a grass median and with parkings spaces. Supports local traffic.",
                    ThumbnailsPath = @"Roads\Avenues\LargeAvenue8LSideParking\thumbnails_grass.png",
                    InfoTooltipPath = @"Roads\Avenues\LargeAvenue8LSideParking\infotooltip.png"
                };
                yield return new MenuItemBuilder
                {
                    UICategory = "RoadsMedium",
                    UIOrder = 19,
                    Name = "FourDevidedLaneAvenue4Parking Decoration Trees",
                    DisplayName = "Four-Devided-Lane Avenue With 4 Parking",
                    Description = "A basic two lane road with a grass median, trees and with parkings spaces. Supports local traffic.",
                    ThumbnailsPath = @"Roads\Avenues\LargeAvenue8LSideParking\thumbnails_trees.png",
                    InfoTooltipPath = @"Roads\Avenues\LargeAvenue8LSideParking\infotooltip.png"
                };
            }
        }

        public void BuildUp(NetInfo info, NetInfoVersion version)
        {
            ///////////////////////////
            // Template              //
            ///////////////////////////
            var roadTunnelInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.ROAD_4L_TUNNEL);
            var roadInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.ROAD_6L);
            ///////////////////////////
            // 3DModeling            //
            ///////////////////////////
            info.Setup32m3mSW2x3mMdnMesh(version);

            ///////////////////////////
            // Texturing             //
            ///////////////////////////
            SetupTextures(info, version);

            ///////////////////////////
            // Set up                //
            ///////////////////////////
            info.m_hasParkingSpaces = true;
            info.m_pavementWidth = (version == NetInfoVersion.Slope || version == NetInfoVersion.Tunnel ? 4 : 3);
            info.m_halfWidth = (version == NetInfoVersion.Tunnel ? 17 : 16);

            if (version == NetInfoVersion.Tunnel)
            {
                info.m_setVehicleFlags = Vehicle.Flags.Transition | Vehicle.Flags.Underground;
                info.m_setCitizenFlags = CitizenInstance.Flags.Transition | CitizenInstance.Flags.Underground;
                info.m_class = roadTunnelInfo.m_class.Clone(NetInfoClasses.NEXT_XLARGE_ROAD_TUNNEL);
            }
            else
            {
                info.m_class = info.m_class.Clone("NEXTFourDevidedLaneParkingAvenue4Parking" + version.ToString());
            }
            info.m_canCrossLanes = false;
            // Setting up lanes
            info.SetRoadLanes(version, new LanesConfiguration
            {
                IsTwoWay = true,
              //  LanesToAdd = 2,
                LaneWidth = version == NetInfoVersion.Slope ? 2.75f : 3,
                PedPropOffsetX = version == NetInfoVersion.Slope ? 1.5f : 1f,
                CenterLane = CenterLaneType.Median,
                CenterLaneWidth = 2,
                BusStopOffset = 0f
            });
        

            var carLanes = info.m_lanes.Where(l => l.m_laneType == NetInfo.LaneType.Vehicle).ToList();
            var pedkLanes = info.m_lanes.Where(l => l.m_laneType == NetInfo.LaneType.Pedestrian).ToList();
            var parking = info.m_lanes.Where(l => l.m_laneType == NetInfo.LaneType.Parking).ToList();

            var parkLane1 = parking[0].ShallowClone();
            parkLane1.m_width = 2;
            parkLane1.m_position = -4f;
            parking.Add(parkLane1);


            var parkLane2 = parking[1].ShallowClone();
            parkLane2.m_width = 2;
            parkLane2.m_position = 4f;
            parking.Add(parkLane2);



     
            carLanes[0].m_direction = NetInfo.Direction.Backward;
            carLanes[0].m_finalDirection = NetInfo.Direction.Backward;
            carLanes[0].m_position = -9.5f;
            carLanes[0].m_speedLimit = .2f;
            // RoadHelper.SetupAnyDirectionProps(carLanes[0], carLanes[2]);


        ///    RoadHelper.SetupAnyDirectionProps(carLanes[1], carLanes[0]);

            carLanes[1].m_position =  -1.5f;
            carLanes[1].m_direction = NetInfo.Direction.Backward;
            carLanes[1].m_finalDirection = NetInfo.Direction.Backward;


            carLanes[2].m_position = 1.5f;
            carLanes[2].m_direction = NetInfo.Direction.Forward;
            carLanes[2].m_finalDirection = NetInfo.Direction.Forward;


            carLanes[3].m_position = 9.5f;
            carLanes[3].m_speedLimit = .2f;
            carLanes[3].m_direction = NetInfo.Direction.Forward;
            carLanes[3].m_finalDirection = NetInfo.Direction.Forward;

            var tempProps = carLanes[0].m_laneProps.m_props.ToList();
            tempProps.RemoveProps("arrow");
            carLanes[0].m_laneProps.m_props = tempProps.ToArray();

            tempProps = carLanes[3].m_laneProps.m_props.ToList();
            tempProps.RemoveProps("arrow");
            carLanes[3].m_laneProps.m_props = tempProps.ToArray();

      

            var leftPedLane = info.GetLeftRoadShoulder();
            var rightPedLane = info.GetRightRoadShoulder();
       

            var leftPed = info.GetLeftRoadShoulder().FullClone();
            leftPed.m_width = 1f;
            leftPed.m_position = -5.5f;
            leftPed.m_stopType = VehicleInfo.VehicleType.Car;

            var rightPed = info.GetRightRoadShoulder().FullClone();      
            rightPed.m_position = 5.5f;
            rightPed.m_width = 1f;
            rightPed.m_stopType = VehicleInfo.VehicleType.Car;

              var props = rightPed.m_laneProps.m_props.ToList();
            props.RemoveProps("light");
            props.RemoveProps("limit");
            props.RemoveProps("random");
            rightPed.m_laneProps.m_props = props.ToArray();

            props = leftPed.m_laneProps.m_props.ToList();
            props.RemoveProps("light");
            props.RemoveProps("limit");
            props.RemoveProps("random");
            leftPed.m_laneProps.m_props = props.ToArray();

        


            var centerLane1 = info.GetMedianLane().CloneWithoutStops();
            var centerLane2 = info.GetMedianLane().CloneWithoutStops();
            centerLane1.m_width = 2f;
            centerLane2.m_width = 2f;
            centerLane1.m_position = -6f;
            centerLane2.m_position = 6f;



            var leftPedLaneProps = leftPedLane.m_laneProps.m_props.ToList();
            var rightPedLaneProps = rightPedLane.m_laneProps.m_props.ToList();

            var centerLane1PedLaneProps = centerLane1.m_laneProps.m_props.ToList();
            var centerLane2PedLaneProps = centerLane2.m_laneProps.m_props.ToList();

            var trafficLight = Prefabs.Find<PropInfo>("Traffic Light 01");
            var centerLane1StreetLight = centerLane1PedLaneProps?.FirstOrDefault(p => {
                if (p == null || p.m_prop == null)
                {
                    return false;
                }
                return p.m_prop.name.ToLower().Contains("avenue light");
            });

            /*
            var centerLane1TrafficLight = centerLane1PedLaneProps?.FirstOrDefault(p => {
                if (p == null || p.m_prop == null)
                {
                    return false;
                }
                return p.m_prop.name.ToLower().Contains("traffic light");
            });
            */
            if (centerLane1StreetLight != null)
            {
                centerLane1StreetLight.m_finalProp =
                 centerLane1StreetLight.m_prop = Prefabs.Find<PropInfo>(MediumAvenueSideLightBuilder.NAME);
                centerLane1StreetLight.m_angle = 180;
                var lefttLigth = centerLane1StreetLight.ShallowClone();
                lefttLigth.m_position = new Vector3(0, 0, 0);
               leftPedLaneProps.AddProp(lefttLigth);
            }
/*
            if (centerLane1TrafficLight != null)
            {
                centerLane1StreetLight.m_finalProp =
                centerLane1StreetLight.m_prop = trafficLight.ShallowClone();
            }
            */
            var centerLane2StreetLight = centerLane2PedLaneProps?.FirstOrDefault(p =>
            {
                if (p == null || p.m_prop == null)
                {
                    return false;
                }
                return p.m_prop.name.ToLower().Contains("avenue light");
            });
            if (centerLane2StreetLight != null)
            {
                centerLane2StreetLight.m_finalProp =
                 centerLane2StreetLight.m_prop = Prefabs.Find<PropInfo>(MediumAvenueSideLightBuilder.NAME);
                centerLane2StreetLight.m_angle = 0;
                var rightLigth = centerLane2StreetLight.ShallowClone();
                rightLigth.m_position = new Vector3(0, 0, 0);
                rightPedLaneProps.AddProp(rightLigth);
            }

            if (centerLane1PedLaneProps != null)
            {
                      centerLane1PedLaneProps.RemoveProps("avenue");
                centerLane1PedLaneProps.RemoveProps("bus");
         //       centerLane1PedLaneProps.RemoveProps("light");
                centerLane1PedLaneProps.RemoveProps("50 Speed Limit");
            }
            if (centerLane2PedLaneProps != null)
            {
                    centerLane2PedLaneProps.RemoveProps("avenue");
                centerLane2PedLaneProps.RemoveProps("bus");
          //      centerLane2PedLaneProps.RemoveProps("light");
                centerLane2PedLaneProps.RemoveProps("50 Speed Limit");
            }
       
    
           // var centerLaneProps = new List<NetLaneProps.Prop>();
            if (version == NetInfoVersion.GroundTrees)
            {
                var treeProp = new NetLaneProps.Prop()
                {
                    m_tree = Prefabs.Find<TreeInfo>("Tree2variant"),
                    m_repeatDistance = 50,
                    m_probability = 100,
                };
                treeProp.m_position.x = 0;
                centerLane1PedLaneProps.Add(treeProp.ShallowClone());
                centerLane2PedLaneProps.Add(treeProp.ShallowClone());
            }
            
            centerLane1.m_laneProps.m_props = centerLane1PedLaneProps.ToArray();
            centerLane2.m_laneProps.m_props = centerLane2PedLaneProps.ToArray();

            leftPedLane.m_laneProps.m_props = leftPedLaneProps.ToArray();
            rightPedLane.m_laneProps.m_props = rightPedLaneProps.ToArray();

            var pedLanes = new List<NetInfo.Lane>();
            pedLanes.Add(rightPed);
            pedLanes.Add(leftPed);
            pedLanes.Add(leftPedLane);
            pedLanes.Add(rightPedLane);
            //carLanes[4].m_position += 1;
            var tempLanes = new List<NetInfo.Lane>();
            tempLanes.Add(centerLane1);
            tempLanes.Add(centerLane2);
            tempLanes.AddRange(pedLanes);
          //  tempLanes.AddRange(pedkLanes);
            tempLanes.AddRange(carLanes);
            tempLanes.AddRange(parking);
            info.m_lanes = tempLanes.ToArray();

            

            // AI
            var owPlayerNetAI = roadInfo.GetComponent<PlayerNetAI>();
            var playerNetAI = info.GetComponent<PlayerNetAI>();

            if (owPlayerNetAI != null && playerNetAI != null)
            {
                playerNetAI.m_constructionCost = owPlayerNetAI.m_constructionCost * 2; // Charge by the lane?
                playerNetAI.m_maintenanceCost = owPlayerNetAI.m_maintenanceCost * 2; // Charge by the lane?
            }

            var roadBaseAI = info.GetComponent<RoadBaseAI>();

            if (roadBaseAI != null)
            {
                roadBaseAI.m_trafficLights = true;
            }
        }

    }
}

