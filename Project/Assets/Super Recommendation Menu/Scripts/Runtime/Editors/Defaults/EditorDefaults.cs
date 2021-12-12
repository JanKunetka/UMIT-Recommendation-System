using UnityEngine;

namespace DoubleMasters.WorldBuilderVR.Editors.Core.Defaults
{
    /// <summary>
    /// Contains all default values used by the editor.
    /// </summary>
    public static class EditorDefaults
    {
        //Pack
        public const string PackTitle = "New Pack";
        public const string PackDescription = "A new pack containing a bunch of models!";
        public static readonly Sprite PackIcon = Resources.Load<Sprite>("Defaults/tex_icon_DefaultPack");
        public const string Author = "NO_AUTHOR";
    }
}