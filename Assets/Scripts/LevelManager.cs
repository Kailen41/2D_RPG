using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Tilemap _tilemap;

    private Vector3 _bottomLeftEdge;
    private Vector3 _topRightEdge;

    void Start()
    {
        _bottomLeftEdge = _tilemap.localBounds.min + new Vector3(0.5f, 1f, 0f);
        _topRightEdge = _tilemap.localBounds.max + new Vector3(-0.5f, -1f, 0f); 

        PlayerManager.instance.SetLimits(_bottomLeftEdge, _topRightEdge);
    }

    void Update()
    {
        
    }
}
