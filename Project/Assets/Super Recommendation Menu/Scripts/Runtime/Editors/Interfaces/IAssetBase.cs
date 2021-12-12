using UnityEngine;

namespace DoubleMasters.WorldBuilderVR.Editors.Data.Core
{
    /// <summary>
    /// A Base for all assets.
    /// </summary>
    public interface IAssetBase
    {
        public string Title { get; }
        public Sprite Icon { get; }
        public string Author { get; }
    }
}