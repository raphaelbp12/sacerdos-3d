using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavMeshBuilder = UnityEngine.AI.NavMeshBuilder;
using UnityEngine.AI;
using Scrds.Classes;

namespace Scrds.Core
{
    public class TileGeneratorController : MonoBehaviour
    {
        public UnityEngine.Object[] allTiles;
        public int width = 3;
        public int height = 3;
        // Start is called before the first frame update
        private List<List<TileData>> tilesMatrix = new List<List<TileData>>();
        private List<List<GameObject>> tilesGameObjectMatrix = new List<List<GameObject>>();
        private List<List<int>> tilesMaskMatrix = new List<List<int>>();
        
        public NavMeshSurface surface;

        public GameObject playerPrefab;
        public GameObject enemyPrefab;
        // public GameObject portalPrefab;
        // public GameObject towerPrefab;
        public GameObject tileTesterPrefab;
        public GameObject camera;
        public int numberOfEnemies;

        private Vector3 towerPosition;

        public void Rebake()
        {
            if (surface)
            {
                surface.BuildNavMesh();
            }
        }
        void Start()
        {
            allTiles = Resources.LoadAll("Game/World/Tiles", typeof(GameObject));
            tilesMatrix = GenerateTilesMatrix();

            for (int i = 0; i < tilesMatrix.Count; i++)
            {
                List<TileData> row = tilesMatrix[i];

                for (int j = 0; j < row.Count; j++)
                {
                    TileData tile = row[j];
                    Vector3 position = new Vector3(j*35, 0, i*-35);
                    if (tile != null) {
                        GameObject tileObject = GetTileObjectByName(tile.name);
                        float angle = -90*tile.rotation;
                        Instantiate(tileObject, position, Quaternion.Euler(0, angle, 0));
                    }
                }
                Rebake();
            }


            // towerPosition = new Vector3(UnityEngine.Random.Range(0,35f*width), 0, UnityEngine.Random.Range(0, -35f*height));
            towerPosition = new Vector3(0, 0, 0);

            // GameObject towerGameObject = SpawnAtPoint(towerPrefab, towerPosition);
            // towerPosition = towerGameObject.transform.position;

            GameObject player = SpawnAtPoint(playerPrefab, towerPosition);

            FollowCamera followCamera = camera.GetComponent<FollowCamera>();
            followCamera.target = player.transform;

            for (int i = 0; i < numberOfEnemies; i++)
            {
                bool pathFound = false;

                while (!pathFound)
                {
                    Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-17.5f,(35f*width-17.5f)), 0, UnityEngine.Random.Range(17.5f, (-35f*height+17.5f)));
                    GameObject portalGameObject = SpawnAtPoint(enemyPrefab, randomPosition);
                    NavMeshAgent portalNavMeshAgent = portalGameObject.GetComponent<NavMeshAgent>();

                    if (!CalculateNewPath(portalNavMeshAgent, towerPosition))
                    {
                        // Vector3 pos = portalGameObject.transform.position;
                        // int row = (int)Math.Round(pos.z/35);
                        // int column = (int)Math.Round(pos.x/35);
                        
                        // if (tilesMaskMatrix[row][column] == 1) {
                        //     tilesMaskMatrix[row][column] = 0;
                        // }

                        Destroy(portalGameObject);

                    } else {
                        pathFound = true;
                    }
                }
            }
        }

        bool CalculateNewPath(NavMeshAgent spawnPosition, Vector3 targetPosition) {
            NavMeshPath navMeshPath = new NavMeshPath();
            spawnPosition.CalculatePath(targetPosition, navMeshPath);
            Debug.Log("New path calculated");
            if (navMeshPath.status != NavMeshPathStatus.PathComplete) {
                return false;
            }
            else {
                return true;
            }
        }

        int GetNumberOfConnectedTiles(int x, int y)
        {
            if (OutOfBounds(x, y))
            {
                return 0;
            }

            TileData tile = tilesMatrix[y][x];

            if (tile.alreadyCounted)
            {
                return 0;
            }
            return 1;
        }

        bool OutOfBounds(int x, int y)
        {
            if (x < 0)
            {
                return true;
            }

            if (y < 0)
            {
                return true;
            }

            if (x > width)
            {
                return true;
            }

            if (y > height)
            {
                return true;
            }

            return false;
        }

        GameObject GetTileObjectByName(string name)
        {
            foreach (UnityEngine.Object tilePrefab in allTiles)
            {
                TileController tileController = ((GameObject)tilePrefab).GetComponent<TileController>();

                if (tileController.name == name)
                {
                    return (GameObject)tilePrefab;
                }
            }
            return null;
        }

        GameObject SpawnAtPoint(GameObject prefab, Vector3 position)
        {
            NavMeshHit hit;
            NavMesh.SamplePosition(position, out hit, 100, 1);
            position = hit.position;
            float angle = UnityEngine.Random.Range(0f,360f);
            return Instantiate(prefab, position, Quaternion.Euler(0, angle, 0));
        }

        GameObject SearchTile(int indexI, int indexJ, ConnectionTypes first, ConnectionTypes second, ConnectionTypes? third = null, ConnectionTypes? fourth = null)
        {
            List<GameObject> tilesFound = new List<GameObject>();
            foreach (UnityEngine.Object tile in allTiles)
            {
                List<ConnectionTypes> connectionsDoubled = new List<ConnectionTypes>();
                bool hasFirst = false;
                bool hasSecond = false;
                int firstIndex = 0;
                TileController tileController = ((GameObject)tile).GetComponent<TileController>();
                connectionsDoubled.AddRange(tileController.connections);
                connectionsDoubled.AddRange(tileController.connections);
                for (int i = 0; i < connectionsDoubled.Count; i++)
                {
                    ConnectionTypes connection = connectionsDoubled[i];
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
                        continue;
                    }

                    hasFirst = false;
                    hasSecond = false;
                }
            }
            
            if (tilesFound.Count > 0) {
                GameObject tileFound = tilesFound[UnityEngine.Random.Range(0, tilesFound.Count)];
                TileController tileController = ((GameObject)tileFound).GetComponent<TileController>();
                return tileFound;
            } else {
                return null;
            }
        }

        List<List<TileData>> GenerateTilesMatrix()
        {
            List<List<TileData>> result = new List<List<TileData>>();

            for (int i = 0; i < height; i++)
            {
                List<TileData> row = new List<TileData>();
                for (int j = 0; j < width; j++)
                {
                    row.Add(null);
                }
                result.Add(row);
            }

            GameObject firstTile = SearchTile(0, 0, ConnectionTypes.empty, ConnectionTypes.empty);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j == 0 && i == 0) {
                        result[0][0] = new TileData(firstTile);
                    } else {
                        ConnectionTypes secondConnection = ConnectionTypes.empty;

                        int previousTileIndex = j - 1;
                        TileData previousTile = result[0][0];
                        ConnectionTypes firstConnection = ConnectionTypes.empty;
                        int connectionIndex = 0;
                        if (j == 0) {
                            previousTile = result[i - 1][0];
                            connectionIndex = (previousTile.rotation + 3)%4;
                            secondConnection = previousTile.connectionTypes[connectionIndex];
                            firstConnection = ConnectionTypes.empty;
                        } else {
                            if (result[i][j - 1] != null) {
                                previousTile = result[i][j - 1];
                                connectionIndex = (previousTile.rotation + 2)%4;
                                firstConnection = previousTile.connectionTypes[connectionIndex];
                            } else {
                                firstConnection = ConnectionTypes.empty;
                            }

                            if (i == 0) {
                                secondConnection = ConnectionTypes.empty;
                            } else {
                                if (result[i -1][j] == null) {
                                    continue;
                                }
                                TileData previousRowTile = result[i -1][j];
                                connectionIndex = (previousRowTile.rotation + 3)%4;
                                secondConnection = previousRowTile.connectionTypes[connectionIndex];
                            }
                        }

                        ConnectionTypes? thirdConnection = null;

                        GameObject tile = SearchTile(i, j, firstConnection, secondConnection, thirdConnection);
                        if (tile != null)
                        {
                            result[i][j] = new TileData(tile);
                        } else {
                            result[i][j] = null;
                        }
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
}