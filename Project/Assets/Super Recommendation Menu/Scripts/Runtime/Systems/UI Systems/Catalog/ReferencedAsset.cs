using DoubleMasters.WorldBuilderVR.Editors.Data.Core;

namespace DoubleMasters.WorldBuilderVR.Systems.Catalog
{
    /// <summary>
    /// Holds information about a given asset and an it's index of the position
    /// on a list where it was referenced from.
    /// </summary>
    public class ReferencedAsset
    {
        private IAssetBase asset;
        private int index;

        public ReferencedAsset(IAssetBase asset, int index)
        {
            this.asset = asset;
            this.index = index;
        }

        public IAssetBase Asset { get => asset;}
        public int Index {get => index;}
    }
}