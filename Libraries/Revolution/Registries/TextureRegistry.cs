﻿using Microsoft.Xna.Framework.Graphics;
using Revolution.Registries.Containers;
using System.Collections.Generic;

namespace Revolution.Registries
{
    public class TextureRegistry
    {
        private static Registry<string, Texture2D> _textureRegistryInstance;
        private static Registry<string, Texture2D> RegistryInstance => _textureRegistryInstance ?? (_textureRegistryInstance = new Registry<string, Texture2D>());

        private static Registry<string, ModTexture> _modTextureRegistryInstance;
        private static Registry<string, ModTexture> ModTextureRegistryInstance => _modTextureRegistryInstance ?? (_modTextureRegistryInstance = new Registry<string, ModTexture>());

        #region Standard Texture Registry

        public static IEnumerable<Texture2D> GetRegisteredTextures()
        {
            return RegistryInstance.GetRegisteredItems();
        }

        public static Texture2D GetItem(string itemId)
        {
            return RegistryInstance.GetItem(itemId);
        }
        
        public static void RegisterItem(string itemId, Texture2D item)
        {
            RegistryInstance.RegisterItem(itemId, item);
        }

        public static void UnregisterItem(string itemId)
        {
            RegistryInstance.UnregisterItem(itemId);
        }

        #endregion
        #region ModTexture Registry

        public static IEnumerable<Texture2D> GetRegisteredModTextures()
        {
            return RegistryInstance.GetRegisteredItems();
        }

        public static void RegisterItem(ModManifest mod, string itemId, ModTexture item)
        {
            ModTextureRegistryInstance.RegisterItem(GetModSpecificItemId(mod, itemId), item);
        }

        public static void UnregisterItem(ModManifest mod, string itemId)
        {
            ModTextureRegistryInstance.UnregisterItem(GetModSpecificItemId(mod, itemId));
        }

        public static ModTexture GetItem(ModManifest mod, string itemId)
        {
            return ModTextureRegistryInstance.GetItem(GetModSpecificItemId(mod, itemId));
        }

        #endregion
        #region Helper Functions
        private static string GetModSpecificPrefix(ModManifest mod)
        {
            return $"\\{mod.UniqueId}\\";
        }

        private static string GetModSpecificItemId(ModManifest mod, string itemId)
        {
            var modPrefix = GetModSpecificPrefix(mod);
            return $"{modPrefix}{itemId}";
        }
        #endregion
    }
}