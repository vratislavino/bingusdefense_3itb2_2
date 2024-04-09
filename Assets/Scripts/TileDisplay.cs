using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDisplay : MonoBehaviour
{
    private Tile tileData;
    public Tile TileData {  get { return tileData; }  set { tileData = value; } }

    [SerializeField]
    private Transform buildPlace;

    void Start()
    {
        
    }

    public void Build(Building building)
    {
        Instantiate(building, buildPlace.position, Quaternion.identity);
        tileData.tileType = TileType.Occupied;
    }

    private void OnMouseDown()
    {
        if (BuildingsUI.Instance.CanBuild)
        {
            CommandQueue.Instance.EnqueueCommand(new BuildCommand()
            {
                where = this,
                what = BuildingsUI.Instance.BuildingButton.BuildingData.Prefab //BuildingManager.Instance.CurrentBuilding
            });
            BuildingsUI.Instance.DeselectCurrentButton();
        }
        //Destroy(gameObject);
    }
}
