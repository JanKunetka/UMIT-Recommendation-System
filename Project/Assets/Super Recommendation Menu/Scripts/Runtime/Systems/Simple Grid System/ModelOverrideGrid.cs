using BoubakProductions.Safety;
using DoubleMasters.WorldBuilderVR.Editors.Core;
using DoubleMasters.WorldBuilderVR.Systems.Catalog;
using UnityEngine;

namespace DoubleMasters.WorldBuilderVR.Systems.GridSystem
{
    /// <summary>
    /// A grid that shows spawned models and overrides existing grids when new ones show up.
    /// </summary>
    public class ModelOverrideGrid : MonoBehaviour
    {
        [SerializeField] private Vector2Int size;
        [SerializeField] private float spacing;
        
        private EditorOverseer editor;

        private ObjectGrid<GameObject> dataGrid;
        private Vector2Int gridPosition;        

        private void Start()
        {
            editor = EditorOverseer.Instance;
            dataGrid = new ObjectGrid<GameObject>(size.x, size.y, () => null);
            gridPosition = Vector2Int.zero;
        }

        private void OnEnable()
        {
            CatalogItem.OnAssetActivate += SetValue;
        }

        private void OnDisable()
        {
            CatalogItem.OnAssetActivate -= SetValue;
        }

        /// <summary>
        /// Spawn a model into the grid.
        /// </summary>
        /// <param name="index">The index of the model on the list.</param>
        private void SetValue(int index)
        {
            DestroyFromGridIfExists(gridPosition);
            SpawnToGrid(editor.CurrentPack.Models[index].Model);
            IncrementGridPosition(gridPosition, size.x, size.y);
        }

        /// <summary>
        /// Destroy object if it exists in the grid..
        /// </summary>
        private void DestroyFromGridIfExists(Vector2Int gridPos)
        {
            if (dataGrid.GetValue(gridPos) == null) return;
            
            Destroy(dataGrid.GetValue(gridPos));
            dataGrid.SetValue(gridPos, null);
        }

        /// <summary>
        /// Spawns a new object and saves it tot the grid.
        /// </summary>
        /// <param name="model">The model object to spawn.</param>
        private void SpawnToGrid(GameObject model)
        {
            SafetyNet.EnsureIsNotNull(model, "Spawnable model");
            
            Vector3 spawnPos = new Vector3(transform.position.x + (gridPosition.x / spacing),
                                           transform.position.y,
                                           transform.position.z - (gridPosition.y / spacing));
                                        
            GameObject spawnedObject = Instantiate(model, spawnPos, Quaternion.identity, transform);
            dataGrid.SetValue(gridPosition, spawnedObject);
        }
        
        /// <summary>
        /// Increments a position in a <see cref="Vector2Int"/> horizontally within certain bounds.
        /// </summary>
        /// <param name="oldPosition">The position that is going to be incremented.</param>
        /// <param name="maxX">Maximum allowed X.</param>
        /// <param name="maxY">Maximum allowed Y.</param>
        private void IncrementGridPosition(Vector2Int oldPosition, int maxX, int maxY)
        {
            //Overflow on X
            if (oldPosition.x + 1 >= maxX)
            {
                //Overflow on Y
                if (oldPosition.y + 1 >= maxY)
                    gridPosition = Vector2Int.zero;
                else gridPosition = new Vector2Int(0, oldPosition.y + 1);
            }
            else gridPosition = new Vector2Int(oldPosition.x + 1, oldPosition.y);
        }
        
    }
}
