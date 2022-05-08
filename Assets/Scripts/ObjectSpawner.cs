using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private GameObject _missleLauncher;
    [SerializeField] private Terrain _terrain;

    private List<GameObject> _coinsList = new List<GameObject>();
    private List<GameObject> _bombsList = new List<GameObject>();
    private List<GameObject> _misslesList = new List<GameObject>();
    private Vector3 _terrainSize;

    public void ObjectListUpdate(GameObject obj)
    {
        if (obj.GetComponent<Coin>())
        {
            _coinsList.Remove(obj);
        }
        else if (obj.GetComponent<Bomb>())
        {
            _bombsList.Remove(obj);
        }
    }
    
    private void Awake()
    {
        _terrainSize = _terrain.GetComponent<UnityEngine.Terrain>().terrainData.size;
        GenerateObjects(_coin, _coinsList, 100, 90, 90);
        GenerateObjects(_bomb, _bombsList, 10, 100, 100);
        GenerateObjects(_missleLauncher, _misslesList, 5, 150, 100);
    }

    private void GenerateObjects(GameObject objectToSpawn, List<GameObject> list, int startOffset, int increment, int endOffset)
    {
        int xDistance = Convert.ToInt32(_terrainSize.x);
        int yDistance = Convert.ToInt32(_terrainSize.y);
        int zDistance = Convert.ToInt32(_terrainSize.z);
        
        int[,,] coinsPositions = new int[xDistance, yDistance, zDistance];
        int objectsCounter = 0;

        for (int i = startOffset; i < coinsPositions.GetLength(0) - endOffset; i+= increment)
        {
            for (int j = startOffset; j < coinsPositions.GetLongLength(1) - endOffset; j+= increment)
            {
                for (int k = startOffset; k < coinsPositions.GetLength(2) - endOffset; k+= increment)
                {
                    GameObject newObject = Instantiate(objectToSpawn, new Vector3(i, j, k), Quaternion.identity, transform);
                    list.Add(newObject);
                    objectsCounter++;
                }
            }
        }
        Debug.Log(objectsCounter);
    }

    public int GetObjectsAmount()
    {
        return _coinsList.Count;
    }
}
