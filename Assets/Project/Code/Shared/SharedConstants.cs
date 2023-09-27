namespace Assets.Project.Code.Shared
{
    public static class SharedConstants
    {
        public static class AppFileConfigs
        {
            public const string SavesFilesFolder = "/Saves/";
            public const string SavesFileName = "Save_";
        }

        public static class AppDefaultSettings
        {
            public const byte InventoryFixedSize = 3;
            public const float EffectsVolume = 1f;
        }

        public static class ScenesConstants
        {
            public const string BootstrapScene = "Bootstrap";
            public const string LoadScene = "Loading";
            public const string MetaScene = "Meta";
            public const string CoreScene = "Core";
        }
    }
}