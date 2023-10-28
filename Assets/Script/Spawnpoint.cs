using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] spawn;
    private int spawnCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemies());
    }

    IEnumerator Enemies()
    {
        while (!GameManager.Instance.isEnd)
        {
            var pos = spawn[spawnCount];
            Instantiate(enemy, pos.position, Quaternion.identity);

            spawnCount = (spawnCount + 1) % spawn.Length;
            yield return new WaitForSeconds(2.0f);
        }
    }
}
