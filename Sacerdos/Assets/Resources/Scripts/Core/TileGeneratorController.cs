using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneratorController : MonoBehaviour
{
    public Object[] allTiles;
    public GameObject tileFound;
    public int width = 3;
    public int height = 3;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = Resources.LoadAll("Game/World/Tiles", typeof(GameObject));
        tileFound = SearchTile(ConnectionTypes.empty, ConnectionTypes.empty);
    }

    GameObject SearchTile(ConnectionTypes first, ConnectionTypes second)
    {
        foreach (Object tile in allTiles)
        {
            bool hasFirst = false;
            TileController tileController = ((GameObject)tile).GetComponent<TileController>();
            foreach (ConnectionTypes connection in tileController.connections)
            {
                if (!hasFirst && connection == first) {
                    hasFirst = true;
                    continue;
                }
                
                if (hasFirst && connection == second) {
                    return ((GameObject)tile);
                }
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
