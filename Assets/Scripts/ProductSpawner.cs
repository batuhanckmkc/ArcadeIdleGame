using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawner : MonoBehaviour
{
    public static ProductSpawner productSpawner;

    [SerializeField] public List<GameObject> productList;

    [SerializeField] GameObject productCube;
    [SerializeField] private int _spawnAmount;
    [SerializeField] Transform cubeSpawnPos;
    [SerializeField] float productsDistance;

    Vector3 randomVec;

    void Start()
    {
        StartCoroutine(nameof(SpawnProducts));
    }

    IEnumerator SpawnProducts()
    {
        yield return new WaitForSeconds(1f);
      
        if (productList.Count < _spawnAmount)
        {
            if (productList.Count % 5 == 0)
            {
                randomVec.z += productsDistance;
                randomVec.x = 5;
            }
            else
            {
                randomVec.x += productsDistance;
            }

            cubeSpawnPos.position = new Vector3(randomVec.x, cubeSpawnPos.position.y, randomVec.z);
            productList.Add(Instantiate(productCube, cubeSpawnPos.position, Quaternion.identity));
            StartCoroutine(nameof(SpawnProducts));
        }
    }
}
