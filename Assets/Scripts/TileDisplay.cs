using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDisplay : MonoBehaviour
{
    public Tile tileData;

    public Transform buildPlace;

    void Start()
    {
        
    }

    public void Build(GameObject building)
    {
        Instantiate(building, buildPlace.position, Quaternion.identity);
        tileData.tileType = TileType.Occupied; // :(
    }

    private void OnMouseDown()
    {
        CommandQueue.Instance.EnqueueCommand(new BuildCommand() { 
            where = this,
            what = GameObject.CreatePrimitive(PrimitiveType.Sphere) //BuildingManager.Instance.CurrentBuilding
        });
        //Destroy(gameObject);
    }
}
