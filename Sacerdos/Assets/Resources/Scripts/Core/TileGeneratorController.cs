using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneratorController : MonoBehaviour
{
    public Object[] allTiles;
    public int width = 3;
    public int height = 3;
    // Start is called before the first frame update
    public List<List<GameObject>> tilesMatrix = new List<List<GameObject>>();
    void Start()
    {
        allTiles = Resources.LoadAll("Game/World/Tiles", typeof(GameObject));
        tilesMatrix = GenerateTilesMatrix();
    }

    GameObject SearchTile(ConnectionTypes first, ConnectionTypes second, ConnectionTypes? third = null, ConnectionTypes? fourth = null)
    {
        List<GameObject> tilesFound = new List<GameObject>();
        foreach (Object tile in allTiles)
        {
            bool hasFirst = false;
            bool hasSecond = false;
            int firstIndex = 0;
            TileController tileController = ((GameObject)tile).GetComponent<TileController>();
            for (int i = 0; i < tileController.connections.Count; i++)
            {
                ConnectionTypes connection = tileController.connections[i];
                if (!hasFirst && connection == first) {
                    hasFirst = true;
                    firstIndex = i;
                    continue;
                }
                
                if (hasFirst && !hasSecond && connection == second) {
                    hasSecond = true;
                    continue;
                }

                if (hasFirst && hasSecond) {
                    if (third != null && connection != third) {
                        continue;
                    }

                    tileController.rotation = firstIndex;
                    tilesFound.Add(((GameObject)tile));
                    if (connection != first) {
                        hasFirst = false;
                        hasSecond = false;
                    }
                }

                hasFirst = false;
                hasSecond = false;
            }
        }
        
        if (tilesFound.Count > 0) {
            return tilesFound[Random.Range(0, tilesFound.Count)];
        } else {
            return null;
        }
    }

    List<List<GameObject>> GenerateTilesMatrix()
    {
        List<List<GameObject>> result = new List<List<GameObject>>();

        for (int i = 0; i < height; i++)
        {
            List<GameObject> row = new List<GameObject>();
            for (int j = 0; j < width; j++)
            {
                row.Add(null);
            }
            result.Add(row);
        }

        GameObject firstTile = SearchTile(ConnectionTypes.empty, ConnectionTypes.empty);

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j == 0 && i == 0) {
                    result[0][0] = firstTile;
                } else {
                    ConnectionTypes secondConnection = ConnectionTypes.empty;

                    int previousTileIndex = j - 1;
                    TileController previousTile = firstTile.GetComponent<TileController>();
                    ConnectionTypes firstConnection = ConnectionTypes.empty;
                    int connectionIndex = 0;
                    if (j == 0) {
                        previousTile = result[i - 1][0].GetComponent<TileController>();
                        connectionIndex = (previousTile.rotation + 3)%4;
                        secondConnection = previousTile.connections[connectionIndex];
                        firstConnection = ConnectionTypes.empty;
                    } else {
                        previousTile = result[i][j - 1].GetComponent<TileController>();
                        connectionIndex = (previousTile.rotation + 2)%4;
                        firstConnection = previousTile.connections[connectionIndex];

                        if (i == 0) {
                            secondConnection = ConnectionTypes.empty;
                        } else {
                            if (result[i -1][j] == null) {
                                continue;
                            }
                            TileController previousRowTile = result[i -1][j].GetComponent<TileController>();
                            connectionIndex = (previousRowTile.rotation + 3)%4;
                            secondConnection = previousRowTile.connections[connectionIndex];
                        }
                    }

                    ConnectionTypes? thirdConnection = null;
                    if (j == width - 1) {
                        thirdConnection = ConnectionTypes.empty;
                    }

                    GameObject tile = SearchTile(firstConnection, secondConnection, thirdConnection);
                    result[i][j] = tile;
                }
            }
        }

        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
