using DoubleMasters.WorldBuilderVR.Editors.Data.Core;
using UnityEngine;

namespace DoubleMasters.WorldBuilderVR.Editors.Data.Models
{
    /// <summary>
    /// An Asset holding a reference to a model.
    /// </summary>
    [CreateAssetMenu(fileName = "New Model Asset", menuName = "World Builder VR/Model Asset", order = 1)]
    public class ModelAsset : ScriptableObject, IAssetBase
    {
        [SerializeField] private string title;
        [SerializeField, TextArea] private string description;
        [SerializeField] private CategoryType category;
        [SerializeField] private string author;
        [Space]
        [SerializeField] private Sprite icon;
        [SerializeField] private GameObject model;

        public string Title { get => title;}
        public string Description { get => description;}
        public Sprite Icon { get => icon;}
        public CategoryType Category { get => category;}
        public string Author { get => author;}
        public GameObject Model { get => model;}
    }
}