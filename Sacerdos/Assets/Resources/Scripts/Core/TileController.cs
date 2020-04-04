using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField] public List<ConnectionTypes> connections = new List<ConnectionTypes>(){ConnectionTypes.a, ConnectionTypes.a, ConnectionTypes.a, ConnectionTypes.a};
    [SerializeField] public int rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
