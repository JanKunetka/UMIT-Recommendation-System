using BoubakProductions.Core;
using DoubleMasters.WorldBuilderVR.Editors.Data.Models;
using UnityEngine;

namespace DoubleMasters.WorldBuilderVR.Editors.Core
{
    /// <summary>
    /// Works like a bridge between the game and <see cref="EditorOverseer"/>.
    /// </summary>
    public class EditorOverseerMono : MonoSingleton<EditorOverseerMono>
    {
        [SerializeField] private ModelPackAsset modelPack;
        
        private EditorOverseer editor;
        
        protected override void Awake()
        {
            editor = EditorOverseer.Instance;
            editor.AssignAsset(modelPack);
        }

    }
}