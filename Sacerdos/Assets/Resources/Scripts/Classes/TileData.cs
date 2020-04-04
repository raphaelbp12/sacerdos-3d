using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Core;

namespace Scrds.Classes
{
    public class TileData
    {
        public string name;
        public int rotation;
        public List<ConnectionTypes> connectionTypes;

        public TileData(GameObject tileObject)
        {
            TileController tileController = tileObject.GetComponent<TileController>();
            name = tileController.name;
            rotation = tileController.rotation;
            connectionTypes = tileController.connections;
        }
    }
}