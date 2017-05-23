using Transit.Addon.RoadExtensions.Roads.Common;
using Transit.Framework;
using Transit.Framework.Texturing;
#if DEBUG
using Debug = Transit.Framework.Debug;
#endif
namespace Transit.Addon.RoadExtensions.Roads.WideAvenues.Avenue6LBusCenterBike
{

    public partial class Avenue6LBusCenterBikeBuilderBus
    {
        private static void SetupTextures(NetInfo info, NetInfoVersion version)
        {

            switch (version)
            {

                case NetInfoVersion.Ground:

                    info.SetAllSegmentsTexture(
                       new TextureSet
                           (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_Bus__MainTex.png",
                           $@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_SegmentConcrete_Bus__APRMap.png"),
                   new LODTextureSet
                           (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__MainTex.png",
                          $@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_SegmentConcrete_LOD__APRMap.png",
                           @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__XYSMap.png"));


                    info.SetAllNodesTexture(
                     new TextureSet
                         (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node__MainTex.png",
                         @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node__APRMap.png"),
                     new LODTextureSet
                        (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_LOD__MainTex.png",
                         @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_LOD__APRMap.png",
                         @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__XYSMap.png"));

                    break;


            }
        }
    }


    public partial class Avenue6LBusCenterBikeBuilderBeforeEndNode
    {
        private static void SetupTextures(NetInfo info, NetInfoVersion version)
        {

            switch (version)
            {

                case NetInfoVersion.Ground:
                case NetInfoVersion.GroundGrass:
                case NetInfoVersion.GroundTrees:

                    var inverted = string.Empty;
                   
                    var isGrass = version.ToString().Substring(6).Length > 0;
                    var suffix = isGrass ? "Grass" : "Concrete";

                    info.SetAllSegmentsTexture(
                       new TextureSet
                           (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_Before_End__MainTex.png",
                           $@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment{suffix}BeforeEnd__APRMap.png"),
                   new LODTextureSet
                           (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__MainTex.png",
                          $@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_SegmentConcrete_LOD__APRMap.png",
                           @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__XYSMap.png"));

                    for (int i = 0; i < info.m_segments.Length; i++)
                    {

                        var invertMe = !(((info.m_segments[i].m_backwardForbidden & NetSegment.Flags.Invert) == 0));
                        if (invertMe)
                            inverted = "_Inverted";
                        
                        info.m_segments[i].SetTextures(
                                new TextureSet
                                    (string.Format(@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_Before_End{0}__MainTex.png", inverted),
                                    string.Format(@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment{1}BeforeEnd{0}__APRMap.png", inverted, suffix)),
                                new LODTextureSet
                                   (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__MainTex.png",
                                  $@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_SegmentConcrete_LOD__APRMap.png",
                                   @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__XYSMap.png"));
                        
                    }


                    info.SetAllNodesTexture(
                     new TextureSet
                         (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_End__MainTex.png",
                         @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_End__APRMap.png"),
                     new LODTextureSet
                        (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_LOD__MainTex.png",
                         @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_LOD__APRMap.png",
                         @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__XYSMap.png"));

                    break;

            }
        }
    }

    public partial class Avenue6LBusCenterBikeBuilderEndNode
    {
        private static void SetupTextures(NetInfo info, NetInfoVersion version)
        {

            switch (version)
            {

                case NetInfoVersion.Ground:
                case NetInfoVersion.GroundGrass:
                case NetInfoVersion.GroundTrees:


                    var isGrass = version.ToString().Substring(6).Length > 0;
                    var suffix = isGrass ? "Grass" : "Concrete";

                    info.SetAllSegmentsTexture(
                       new TextureSet
                           (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_End__MainTex.png",
                           $@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment{suffix}End__APRMap.png"),
                   new LODTextureSet
                           (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__MainTex.png",
                          $@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_SegmentConcrete_LOD__APRMap.png",
                           @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__XYSMap.png"));


                    info.SetAllNodesTexture(
                     new TextureSet
                         (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_End__MainTex.png",
                         @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_End__APRMap.png"),
                     new LODTextureSet
                        (@"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_LOD__MainTex.png",
                         @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Node_LOD__APRMap.png",
                         @"Roads\WideAvenues\Avenue6LBusCenterBike\Textures\Ground_Segment_LOD__XYSMap.png"));

                    break;

            }
        }
    }
}

