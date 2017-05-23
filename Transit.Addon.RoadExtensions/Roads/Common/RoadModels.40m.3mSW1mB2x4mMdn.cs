using Transit.Framework;
using Transit.Framework.Network;

namespace Transit.Addon.RoadExtensions.Roads.Common
{
    public static partial class RoadModels
    {
        public static NetInfo Setup40m3mSW1mB2x4mMdnMesh(this NetInfo info, NetInfoVersion version)
        {
            var highwayInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.ROAD_6L);
            var slopeInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.ROAD_4L_SLOPE);
            var defaultMaterial = highwayInfo.m_nodes[0].m_material;

            switch (version)
            {
                case NetInfoVersion.Ground:
                case NetInfoVersion.GroundGrass:
                case NetInfoVersion.GroundTrees:
                    {
                        var segments0 = info.m_segments[0];
                        var nodes0 = info.m_nodes[0];

                        segments0
                        .SetFlagsDefault()
                        .SetMeshes
                            (@"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground.obj",
                            @"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_LOD.obj");

                        nodes0.SetMeshes
                            (@"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node.obj",
                            @"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_LOD.obj");

                        info.m_segments = new[] { segments0 };
                        info.m_nodes = new[] { nodes0 };
                        break;
                    }

               
            }
            return info;
        }


        public static NetInfo Setup40m3mSW1mB2x4mMdnSpecialMesh(this NetInfo info, NetInfoVersion version, SpecailSegments special)
        {
            var highwayInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.ROAD_6L);
            var slopeInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.ROAD_4L_SLOPE);
            var defaultMaterial = highwayInfo.m_nodes[0].m_material;

            switch (special)
            {
                case SpecailSegments.BusStation:
                  {
                    var segments0 = info.m_segments[0];
                    var nodes0 = info.m_nodes[0];

                    segments0
                    .SetFlagsDefault()
                    .SetMeshes
                        (@"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Bus.obj",
                        @"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_LOD.obj");

                    nodes0.SetMeshes
                        (@"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node.obj",
                        @"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_LOD.obj");

                    info.m_segments = new[] { segments0 };
                    info.m_nodes = new[] { nodes0 };
                    break;
                }
                case SpecailSegments.EndNode:
                    {
                        var segments0 = info.m_segments[0];
                        var nodes0 = info.m_nodes[0];

                        segments0
                        .SetFlagsDefault()
                        .SetMeshes
                            (@"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_End.obj",
                            @"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_LOD.obj");

                        nodes0.SetMeshes
                            (@"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_5L.obj",
                            @"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_LOD.obj");

                        info.m_segments = new[] { segments0 };
                        info.m_nodes = new[] { nodes0 };
                        break;
                    }
                case SpecailSegments.BeforeEndNode:
                    {
                        var segments0 = info.m_segments[0];
                        var nodes0 = info.m_nodes[0];

                        segments0
                        .SetFlagsDefault()
                        .SetMeshes
                            (@"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Before_End.obj",
                            @"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_LOD.obj");

                        nodes0.SetMeshes
                            (@"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_5L.obj",
                            @"Roads\Common\Meshes\40m\3mSW1mB2x4mMdn\Ground_Node_LOD.obj");

                        info.m_segments = new[] { segments0 };
                        info.m_nodes = new[] { nodes0 };
                        break;
                    }


            }
            return info;
        }
    }
}