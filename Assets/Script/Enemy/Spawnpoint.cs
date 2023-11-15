using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] spawn;
    [SerializeField] private float spawnTime = 4.0f;

    private int spawnCount;
    private Barrel_Counter barrelCounter;
    private bool hasActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemies());
        barrelCounter = FindObjectOfType<Barrel_Counter>();
    }

    private void Update()
    {
        if (barrelCounter != null && barrelCounter.barrelPoint == 10 && !hasActivated)
        {
            spawnTime = 2.0f;
            hasActivated = true;
        }
    }

    IEnumerator Enemies()
    {
        while (!GameManager.Instance.isEnd)
        {
            var pos = spawn[spawnCount];
            Instantiate(enemy, pos.position, Quaternion.identity);

            spawnCount = (spawnCount + 1) % spawn.Length;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
