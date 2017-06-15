using Transit.Framework;
using Transit.Framework.Texturing;

namespace Transit.Addon.RoadExtensions.Roads.SmallRoads.OneWay1LParkingBicycle
{
    public partial class TestRoadBuilder
    {
        private static void SetupTextures(NetInfo info, NetInfoVersion version)
        {
            switch (version)
            {
                case NetInfoVersion.Ground:
                case NetInfoVersion.GroundGrass:
                case NetInfoVersion.GroundTrees:


                    var inverted = "";
                  

                    info.m_segments[0].SetTextures(
                       new TextureSet
                            (@"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__MainTex.png",
                             @"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__AlphaMap.png"),
                       new LODTextureSet
                           (@"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__MainTex.png",
                           @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__AlphaMap.png",
                           @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__XYS.png"));
                    info.m_segments[1].SetTextures(
                     new TextureSet
                          (@"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__MainTex1.png",
                           @"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__AlphaMap.png"),
                     new LODTextureSet
                         (@"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__MainTex.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__AlphaMap.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__XYS.png"));

                    if ((((info.m_segments[2].m_backwardForbidden & NetSegment.Flags.Invert) == 0))
                            || (((info.m_segments[2].m_backwardForbidden & NetSegment.Flags.Invert) != 0)))
                    {
                        info.m_segments[2].SetTextures(
                   new TextureSet
                        (@"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__MainTex7.png",
                            @"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__AlphaMap.png"),
                    new LODTextureSet
                        (@"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__MainTex.png",
                        @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__AlphaMap.png",
                        @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__XYS.png"));
                    }else
                    {
                        info.m_segments[2].SetTextures(
                  new TextureSet
                       (@"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__MainTex2.png",
                        @"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__AlphaMap.png"),
                  new LODTextureSet
                      (@"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__MainTex.png",
                      @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__AlphaMap.png",
                      @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__XYS.png"));
                    }

                 
                    info.m_segments[3].SetTextures(
                     new TextureSet
                          (@"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__MainTex3.png",
                           @"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__AlphaMap.png"),
                     new LODTextureSet
                         (@"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__MainTex.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__AlphaMap.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__XYS.png"));
                    info.m_segments[4].SetTextures(
                     new TextureSet
                          (@"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__MainTex4.png",
                           @"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__AlphaMap.png"),
                     new LODTextureSet
                         (@"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__MainTex.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__AlphaMap.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__XYS.png"));
                    info.m_segments[5].SetTextures(
                     new TextureSet
                          (@"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__MainTex5.png",
                           @"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__AlphaMap.png"),
                     new LODTextureSet
                         (@"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__MainTex.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__AlphaMap.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__XYS.png"));
                    info.m_segments[6].SetTextures(
                     new TextureSet
                          (@"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__MainTex6.png",
                           @"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__AlphaMap.png"),
                     new LODTextureSet
                         (@"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__MainTex.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__AlphaMap.png",
                         @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__XYS.png"));

                    info.m_segments[7].SetTextures(
                new TextureSet
                     (@"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__MainTex7.png",
                      @"Roads\SmallRoads\TestRoad\Textures\Ground_Segment__AlphaMap.png"),
                new LODTextureSet
                    (@"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__MainTex.png",
                    @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__AlphaMap.png",
                    @"Roads\SmallRoads\TestRoad\Textures\Ground_SegmentLOD__XYS.png"));
                    break;
         
            }
        }
    }
}

