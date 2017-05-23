﻿using System.Collections.Generic;
using ColossalFramework.UI;
using Transit.Framework;
using Transit.Framework.Builders;
using UnityEngine;

namespace Transit.Addon.RoadExtensions.Menus.Roads.Textures
{
    public class RExExtendedSubBarAtlasBuilder : IAtlasBuilder
    {
        public IEnumerable<string> Keys
        {
            get
            {
                yield return RExExtendedMenus.ROADS_TINY;
                yield return RExExtendedMenus.ROADS_PEDESTRIANS;
                yield return RExExtendedMenus.ROADS_SMALL_HV;
                yield return RExExtendedMenus.ROADS_WIDE;
                yield return RExExtendedMenus.ROADS_WIDE_AVENUE;
                yield return RExExtendedMenus.ROADS_SMALL_HV;
                yield return RExExtendedMenus.ROADS_BUSWAYS;
            }
        }

        public UITextureAtlas Build()
        {
            var thumbnailAtlas = ScriptableObject.CreateInstance<UITextureAtlas>();
            thumbnailAtlas.padding = 0;
            thumbnailAtlas.name = "RExExtendedSubBar";

            var shader = Shader.Find("UI/Default UI Shader");
            if (shader != null) thumbnailAtlas.material = new Material(shader);

            const string PATH = @"Menus\Roads\Textures\RExExtendedSubBar.png";

            const string BASE = "SubBarButtonBase";
            const string ROADS_TINY_SUBBAR = "SubBar" + RExExtendedMenus.ROADS_TINY;
            const string ROADS_SMALL_HV_SUBBAR = "SubBar" + RExExtendedMenus.ROADS_SMALL_HV;
            const string ROADS_WIDE_SUBBAR = "SubBar" + RExExtendedMenus.ROADS_WIDE;
            const string ROADS_WIDE_AVENUE_SUBBAR = "SubBar" + RExExtendedMenus.ROADS_WIDE_AVENUE;
            const string ROADS_BUSWAYS_SUBBAR = "SubBar" + RExExtendedMenus.ROADS_BUSWAYS;
            const string ROADS_PED_SUBBAR = "SubBar" + RExExtendedMenus.ROADS_PEDESTRIANS;

            var versions = new[] { "", "Disabled", "Focused", "Hovered", "Pressed" };


            var texture = AssetManager.instance.GetTexture(PATH, TextureType.UI);
            texture.FixTransparency();

            thumbnailAtlas.material.mainTexture = texture;

            var x = 1;
            var y = 1;

            const int TEXTURE_W = 292;
            const int TEXTURE_H = 165;



            // Base -------------------------------------------------------------------------------
            const int BASE_ICON_W = 58;
            const int BASE_ICON_H = 25;

            foreach (var t in versions)
            {
                var sprite = new UITextureAtlas.SpriteInfo
                {
                    name = string.Format(BASE + "{0}", t),
                    region = new Rect(
                        (float)(x) / TEXTURE_W,
                        (float)(y) / TEXTURE_H,
                        (float)(BASE_ICON_W) / TEXTURE_W,
                        (float)(BASE_ICON_H) / TEXTURE_H),
                    texture = new Texture2D(BASE_ICON_W, BASE_ICON_H, TextureFormat.ARGB32, false)
                };

                thumbnailAtlas.AddSprite(sprite);

                x += BASE_ICON_W;
            }
            y += BASE_ICON_H;



            // Button Icons -----------------------------------------------------------------------
            var buttonIcons = new[] { ROADS_TINY_SUBBAR, ROADS_SMALL_HV_SUBBAR, ROADS_WIDE_SUBBAR, ROADS_WIDE_AVENUE_SUBBAR, ROADS_BUSWAYS_SUBBAR, ROADS_PED_SUBBAR };
            const int ICON_W = 32;
            const int ICON_H = 22;

            foreach (var bi in buttonIcons)
            {
                x = 1;
                y += 1;

                foreach (var t in versions)
                {
                    var sprite = new UITextureAtlas.SpriteInfo
                    {
                        name = string.Format(bi + "{0}", t),
                        region = new Rect(
                            (float)(x) / TEXTURE_W,
                            (float)(y) / TEXTURE_H,
                            (float)(ICON_W) / TEXTURE_W,
                            (float)(ICON_H) / TEXTURE_H),
                        texture = new Texture2D(ICON_W, ICON_H, TextureFormat.ARGB32, false)
                    };

                    thumbnailAtlas.AddSprite(sprite);

                    x += ICON_W;
                }

                y += ICON_H;
            }

            return thumbnailAtlas;
        }
    }
}
