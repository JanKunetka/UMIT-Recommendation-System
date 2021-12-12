using UnityEngine;

namespace DoubleMasters.WorldBuilderVR.Editors.Data.Models
{
    /// <summary>
    /// A Model Pack containing data about worlds and models.
    /// </summary>
    [CreateAssetMenu(fileName = "New Model Pack", menuName = "World Builder VR/Model Pack", order = 0)]
    public class ModelPackAsset : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField, TextArea] private string description;
        [SerializeField] private string authors;
        [Space]
        [SerializeField] private ModelAsset[] models;

        public string Title => title;
        public string Description => description;
        public string Authors => authors;
        public ModelAsset[] Models => models;
    }
}