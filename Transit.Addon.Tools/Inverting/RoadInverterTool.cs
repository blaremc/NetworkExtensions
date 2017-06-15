// Generating a bug where it creates an hole in the terrain, to investigate

using ColossalFramework;
using ICities;
using System.Collections.Generic;
using Transit.Framework;
using Transit.Framework.UI;
using UnityEngine;
#if DEBUG
using Debug = Transit.Framework.Debug;
#endif
namespace Transit.Addon.Tools.Inverting
{
    public class RoadInverterTool : ThreadingExtensionBase
    {
        private List<uint> m_lastSegment = new List<uint>();
        private static bool GetIsUpgradeNetToolActive()
        {
            var tool = ToolsModifierControl.toolController.CurrentTool as NetTool;
            if (tool == null)
            {
                return false;
            }

            if (tool.m_mode != NetTool.Mode.Upgrade)
            {
                return false;
            }

            return true;
        }

        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {/*
            if (ToolsModifierControl.toolController == null)
            {
                return;
            }

            if (!GetIsUpgradeNetToolActive())
            {
                return;
            }
            var hoveringSegmentId = ExtendedToolBase.RayCastSegment();
            if (hoveringSegmentId == null)
            {
                return;
            }
            if (Input.GetMouseButton((int)MouseKeyCode.RightButton))
            {
                if (m_lastSegment.Contains(hoveringSegmentId.Value))
                {
                    Debug.Log("Return 1");
                    return;
                }
            }
            else
            {
                m_lastSegment.Clear();
                return;
            }

            var mgr = NetManager.instance;
            var hoveringSegment = mgr.m_segments.m_buffer[hoveringSegmentId.Value];
            var netInfo = hoveringSegment.Info;
            /*
            
            Debug.Message("==============================netInfo=================================", hoveringSegmentId.Value);
            Debug.Message("m_Atlas", netInfo.m_Atlas);
            Debug.Message("m_autoRemove", netInfo.m_autoRemove);
            Debug.Message("m_availableIn", netInfo.m_availableIn);
            Debug.Message("m_averageVehicleLaneSpeed", netInfo.m_averageVehicleLaneSpeed);
            Debug.Message("m_backwardVehicleLaneCount", netInfo.m_backwardVehicleLaneCount);
        //    Debug.Message("m_blockWater", netInfo.m_blockWater);
            Debug.Message("m_buildHeight", netInfo.m_buildHeight);
            Debug.Message("m_canCollide", netInfo.m_canCollide);
            Debug.Message("m_canCrossLanes", netInfo.m_canCrossLanes);
            Debug.Message("m_canDisable", netInfo.m_canDisable);
            Debug.Message("m_class", netInfo.m_class);
            Debug.Message("m_clipSegmentEnds", netInfo.m_clipSegmentEnds);
            Debug.Message("m_clipTerrain", netInfo.m_clipTerrain);
            Debug.Message("m_color", netInfo.m_color);
            Debug.Message("m_connectGroup", netInfo.m_connectGroup);
            Debug.Message("m_connectionClass", netInfo.m_connectionClass);
            Debug.Message("m_createGravel", netInfo.m_createGravel);
            Debug.Message("m_createPavement", netInfo.m_createPavement);
            Debug.Message("m_createRuining", netInfo.m_createRuining);
            Debug.Message("m_dlcRequired", netInfo.m_dlcRequired);
            Debug.Message("m_enableBendingNodes", netInfo.m_enableBendingNodes);
            Debug.Message("m_enableBendingSegments", netInfo.m_enableBendingSegments);
            Debug.Message("m_enableMiddleNodes", netInfo.m_enableMiddleNodes);
            Debug.Message("m_flatJunctions", netInfo.m_flatJunctions);
            Debug.Message("m_flattenTerrain", netInfo.m_flattenTerrain);
            Debug.Message("m_followTerrain", netInfo.m_followTerrain);
            Debug.Message("m_forwardVehicleLaneCount", netInfo.m_forwardVehicleLaneCount);
            Debug.Message("m_halfWidth", netInfo.m_halfWidth);
            Debug.Message("m_hasBackwardVehicleLanes", netInfo.m_hasBackwardVehicleLanes);
            Debug.Message("m_hasForwardVehicleLanes", netInfo.m_hasForwardVehicleLanes);
            Debug.Message("m_hasParkingSpaces", netInfo.m_hasParkingSpaces);
            Debug.Message("m_hasPedestrianLanes", netInfo.m_hasPedestrianLanes);
            Debug.Message("m_hasTerrainHeightProps", netInfo.m_hasTerrainHeightProps);
            Debug.Message("m_InfoTooltipAtlas", netInfo.m_InfoTooltipAtlas);
            Debug.Message("m_InfoTooltipThumbnail", netInfo.m_InfoTooltipThumbnail);
            Debug.Message("m_instanceChanged", netInfo.m_instanceChanged);
            Debug.Message("m_instanceID", netInfo.m_instanceID);
            Debug.Message("m_instanceNeeded", netInfo.m_instanceNeeded);
            Debug.Message("m_instancePool", netInfo.m_instancePool);
            Debug.Message("m_intersectClass", netInfo.m_intersectClass);
            Debug.Message("m_isCustomContent", netInfo.m_isCustomContent);
            Debug.Message("m_lanes", netInfo.m_lanes.Length);
            Debug.Message("m_laneTypes", netInfo.m_laneTypes);
            Debug.Message("m_lowerTerrain", netInfo.m_lowerTerrain);
            Debug.Message("m_maxBuildAngle", netInfo.m_maxBuildAngle);
            Debug.Message("m_maxBuildAngleCos", netInfo.m_maxBuildAngleCos);
            Debug.Message("m_maxHeight", netInfo.m_maxHeight);
            Debug.Message("m_maxPropDistance", netInfo.m_maxPropDistance);
            Debug.Message("m_maxSlope", netInfo.m_maxSlope);
            Debug.Message("m_maxTurnAngle", netInfo.m_maxTurnAngle);
            Debug.Message("m_maxTurnAngleCos", netInfo.m_maxTurnAngleCos);
            Debug.Message("m_minCornerOffset", netInfo.m_minCornerOffset);
            Debug.Message("m_minHeight", netInfo.m_minHeight);
            Debug.Message("m_netAI", netInfo.m_netAI);
            Debug.Message("m_netLayers", netInfo.m_netLayers);
            Debug.Message("m_nodeConnectGroups", netInfo.m_nodeConnectGroups);

            Debug.Message("m_nodes", netInfo.m_nodes.Length);
            for (var i = 0; i < netInfo.m_nodes.Length; i++)
            {
                Debug.Message("m_nodes[" + i + "].m_combinedLod", netInfo.m_nodes[i].m_combinedLod);
                Debug.Message("m_nodes[" + i + "].m_connectGroup", netInfo.m_nodes[i].m_connectGroup);
                Debug.Message("m_nodes[" + i + "].m_directConnect", netInfo.m_nodes[i].m_directConnect);
                Debug.Message("m_nodes[" + i + "].m_emptyTransparent", netInfo.m_nodes[i].m_emptyTransparent);
                Debug.Message("m_nodes[" + i + "].m_flagsForbidden", netInfo.m_nodes[i].m_flagsForbidden);
                Debug.Message("m_nodes[" + i + "].m_flagsRequired", netInfo.m_nodes[i].m_flagsRequired);
                Debug.Message("m_nodes[" + i + "].m_generateTangents", netInfo.m_nodes[i].m_generateTangents);
                Debug.Message("m_nodes[" + i + "].m_layer", netInfo.m_nodes[i].m_layer);
                Debug.Message("m_nodes[" + i + "].m_lodMaterial", netInfo.m_nodes[i].m_lodMaterial);
                Debug.Message("m_nodes[" + i + "].m_lodMesh", netInfo.m_nodes[i].m_lodMesh);
                Debug.Message("m_nodes[" + i + "].m_lodRenderDistance", netInfo.m_nodes[i].m_lodRenderDistance);
                Debug.Message("m_nodes[" + i + "].m_material", netInfo.m_nodes[i].m_material);
                Debug.Message("m_nodes[" + i + "].m_mesh", netInfo.m_nodes[i].m_mesh);
                Debug.Message("m_nodes[" + i + "].m_nodeMaterial", netInfo.m_nodes[i].m_nodeMaterial);
                Debug.Message("m_nodes[" + i + "].m_nodeMesh", netInfo.m_nodes[i].m_nodeMesh);
                Debug.Message("m_nodes[" + i + "].m_preserveUVs", netInfo.m_nodes[i].m_preserveUVs);
            }
            
                Debug.Message("m_notUsedGuide", netInfo.m_notUsedGuide);
            Debug.Message("m_overlayVisible", netInfo.m_overlayVisible);
            Debug.Message("m_pavementWidth", netInfo.m_pavementWidth);
            Debug.Message("m_placementCursor", netInfo.m_placementCursor);
            Debug.Message("m_placementStyle", netInfo.m_placementStyle);
            Debug.Message("m_prefabDataIndex", netInfo.m_prefabDataIndex);
            Debug.Message("m_prefabDataLayer", netInfo.m_prefabDataLayer);
            Debug.Message("m_prefabInitialized", netInfo.m_prefabInitialized);
            Debug.Message("m_propLayers", netInfo.m_propLayers);
            Debug.Message("m_requireContinuous", netInfo.m_requireContinuous);
            Debug.Message("m_requireDirectRenderers", netInfo.m_requireDirectRenderers);
            Debug.Message("m_requireSegmentRenderers", netInfo.m_requireSegmentRenderers);
            Debug.Message("m_requireSurfaceMaps", netInfo.m_requireSurfaceMaps);
            Debug.Message("m_segmentLength", netInfo.m_segmentLength);
            Debug.Message("m_segments", netInfo.m_segments.Length);

            for (var i = 0; i < netInfo.m_segments.Length; i++)
            {
                Debug.Message("m_segments[" + i + "].m_backwardForbidden", netInfo.m_segments[i].m_backwardForbidden);
                Debug.Message("m_segments[" + i + "].m_backwardRequired", netInfo.m_segments[i].m_backwardRequired);
                Debug.Message("m_segments[" + i + "].m_combinedLod", netInfo.m_segments[i].m_combinedLod);
                Debug.Message("m_segments[" + i + "].m_disableBendNodes", netInfo.m_segments[i].m_disableBendNodes);
                Debug.Message("m_segments[" + i + "].m_emptyTransparent", netInfo.m_segments[i].m_emptyTransparent);
                Debug.Message("m_segments[" + i + "].m_forwardForbidden", netInfo.m_segments[i].m_forwardForbidden);
                Debug.Message("m_segments[" + i + "].m_forwardRequired", netInfo.m_segments[i].m_forwardRequired);
                Debug.Message("m_segments[" + i + "].m_generateTangents", netInfo.m_segments[i].m_generateTangents);
             //   Debug.Message("m_segments[" + i + "].m_layer", netInfo.m_segments[i].m_layer);
                Debug.Message("m_segments[" + i + "].m_lodMaterial", netInfo.m_segments[i].m_lodMaterial);
                Debug.Message("m_segments[" + i + "].m_lodMesh", netInfo.m_segments[i].m_lodMesh);
          //      Debug.Message("m_segments[" + i + "].m_lodRenderDistance", netInfo.m_segments[i].m_lodRenderDistance);
                Debug.Message("m_segments[" + i + "].m_material", netInfo.m_segments[i].m_material);
                Debug.Message("m_segments[" + i + "].m_mesh", netInfo.m_segments[i].m_mesh);
                Debug.Message("m_segments[" + i + "].m_preserveUVs", netInfo.m_segments[i].m_preserveUVs);
       //         Debug.Message("m_segments[" + i + "].m_requireSurfaceMaps", netInfo.m_segments[i].m_requireSurfaceMaps);
       ///         Debug.Message("m_segments[" + i + "].m_requireWindSpeed", netInfo.m_segments[i].m_requireWindSpeed);
                Debug.Message("m_segments[" + i + "].m_segmentMaterial", netInfo.m_segments[i].m_segmentMaterial);
                Debug.Message("m_segments[" + i + "].m_segmentMesh", netInfo.m_segments[i].m_segmentMesh);

            }

            Debug.Message("m_setCitizenFlags", netInfo.m_setCitizenFlags);
            Debug.Message("m_setVehicleFlags", netInfo.m_setVehicleFlags);
            Debug.Message("m_snapBuildingNodes", netInfo.m_snapBuildingNodes);
            Debug.Message("m_sortedLanes", netInfo.m_sortedLanes);
            Debug.Message("m_straightSegmentEnds", netInfo.m_straightSegmentEnds);
            Debug.Message("m_surfaceLevel", netInfo.m_surfaceLevel);
            Debug.Message("m_terrainEndOffset", netInfo.m_terrainEndOffset);
            Debug.Message("m_terrainStartOffset", netInfo.m_terrainStartOffset);
            Debug.Message("m_Thumbnail", netInfo.m_Thumbnail);
            Debug.Message("m_twistSegmentEnds", netInfo.m_twistSegmentEnds);
            Debug.Message("m_UIPriority", netInfo.m_UIPriority);
            Debug.Message("m_UnlockMilestone", netInfo.m_UnlockMilestone);
            Debug.Message("m_upgradeCursor", netInfo.m_upgradeCursor);
            Debug.Message("m_useFixedHeight", netInfo.m_useFixedHeight);
            Debug.Message("m_vehicleTypes", netInfo.m_vehicleTypes);

            */

            /*
          
            if (!netInfo.HasAsymmetricalLanes())
            {
                return;
            }

            if ((hoveringSegment.m_flags & NetSegment.Flags.Created) == 0)
            {
                return;
            }


            var startNode = hoveringSegment.m_startNode;
            var endNode = hoveringSegment.m_endNode;
            var startDirection = hoveringSegment.m_startDirection;
            var endDirection = hoveringSegment.m_endDirection;

            var id = hoveringSegmentId.Value;
            ushort segmentId;
            var buildIndex = hoveringSegment.m_buildIndex;
            /*
            Debug.Message("==============================hoveringSegment=================================" , hoveringSegmentId.Value);

            Debug.Message("m_averageLength", hoveringSegment.m_averageLength);
            Debug.Message("m_blockEndLeft", hoveringSegment.m_blockEndLeft);
            Debug.Message("m_blockEndRight", hoveringSegment.m_blockEndRight);
            Debug.Message("m_blockStartLeft", hoveringSegment.m_blockStartLeft);
            Debug.Message("m_blockStartRight", hoveringSegment.m_blockStartRight);
            Debug.Message("m_bounds", hoveringSegment.m_bounds);
            Debug.Message("m_buildIndex", hoveringSegment.m_buildIndex);
            Debug.Message("m_condition", hoveringSegment.m_condition);
            Debug.Message("m_cornerAngleEnd", hoveringSegment.m_cornerAngleEnd);
            Debug.Message("m_cornerAngleStart", hoveringSegment.m_cornerAngleStart);
            Debug.Message("m_endDirection", hoveringSegment.m_endDirection);
            Debug.Message("m_endLeftSegment", hoveringSegment.m_endLeftSegment);
            Debug.Message("m_endNode", hoveringSegment.m_endNode);
            Debug.Message("m_endRightSegment", hoveringSegment.m_endRightSegment);
            Debug.Message("m_fireCoverage", hoveringSegment.m_fireCoverage);
            Debug.Message("m_flags", hoveringSegment.m_flags);
            Debug.Message("m_infoIndex", hoveringSegment.m_infoIndex);
            Debug.Message("m_lanes", hoveringSegment.m_lanes);
            Debug.Message("m_middlePosition", hoveringSegment.m_middlePosition);
            Debug.Message("m_modifiedIndex", hoveringSegment.m_modifiedIndex);
            Debug.Message("m_nameSeed", hoveringSegment.m_nameSeed);
            Debug.Message("m_nextGridSegment", hoveringSegment.m_nextGridSegment);
            Debug.Message("m_path", hoveringSegment.m_path);
            Debug.Message("m_problems", hoveringSegment.m_problems);
            Debug.Message("m_startDirection", hoveringSegment.m_startDirection);
            Debug.Message("m_startLeftSegment", hoveringSegment.m_startLeftSegment);
            Debug.Message("m_startNode", hoveringSegment.m_startNode);
            Debug.Message("m_startRightSegment", hoveringSegment.m_startRightSegment);
            Debug.Message("m_trafficBuffer", hoveringSegment.m_trafficBuffer);
            Debug.Message("m_trafficDensity", hoveringSegment.m_trafficDensity);
            Debug.Message("m_trafficLightState0", hoveringSegment.m_trafficLightState0);
            Debug.Message("m_trafficLightState1", hoveringSegment.m_trafficLightState1);
            Debug.Message("m_wetness", hoveringSegment.m_wetness);
            */




            /*
            hoveringSegment.m_startNode = endNode;
                         hoveringSegment.m_endNode = startNode;

                          hoveringSegment.m_startDirection = endDirection;
                           hoveringSegment.m_endDirection = startDirection;
            hoveringSegment.m_flags = NetSegment.Flags.Invert;

                           mgr.UpdateSegment(hoveringSegmentId.Value);
                       mgr.UpdateSegmentFlags(hoveringSegmentId.Value);
                       mgr.UpdateSegmentRenderer(hoveringSegmentId.Value, true);
                            mgr.UpdateSegmentRenderer(hoveringSegmentId.Value, false);
                       mgr.UpdateSegment(hoveringSegmentId.Value);
                */





            // mgr.ReleaseSegment(hoveringSegmentId.Value, true);  
            /*   mgr.CreateSegment
                      (out segmentId,
                       ref Singleton<SimulationManager>.instance.m_randomizer,
                       netInfo,
                       endNode,
                       startNode,
                       endDirection,
                       startDirection,
                       buildIndex,
                       Singleton<SimulationManager>.instance.m_currentBuildIndex,
                       false);*/
            // Debug.Log("----");

            //Debug.Log("m_currentBuildIndex=" + Singleton<SimulationManager>.instance.m_currentBuildIndex);
            //  Debug.Log("buildIndex=" + buildIndex);
            //   Singleton<SimulationManager>.instance.m_currentBuildIndex += 2u;
           // m_lastSegment.Add(hoveringSegmentId.Value);
        }
    }
}
