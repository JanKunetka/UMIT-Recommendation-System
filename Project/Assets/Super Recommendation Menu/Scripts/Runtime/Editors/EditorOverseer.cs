using DoubleMasters.WorldBuilderVR.Editors.Data.Models;
using UnityEngine;

namespace DoubleMasters.WorldBuilderVR.Editors.Core
{
    /// <summary>
    /// Overseers everything happening in Edit Mode.
    /// </summary>
    public class EditorOverseer : IEditorOverseer
    {
        private ModelPackAsset currentPack;

        #region Singleton Pattern
        private static EditorOverseer instance;
        private static readonly object padlock = new object();
        public static EditorOverseer Instance 
        { 
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new EditorOverseer();
                    return instance;
                }
            }
        }
        #endregion
        
        public void AssignAsset(ModelPackAsset modelPack)
        {
            currentPack = modelPack;
        }
        
        public void CompleteEditing()
        {
            throw new System.NotImplementedException();
        }

        public ModelPackAsset CurrentPack
        {
            get
            {
                if (this.currentPack == null) throw new MissingReferenceException("The Current Model Pack is null. Did you forget to activate the editor?");
                return this.currentPack;
            }
        }
    }
}