using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barrel_Counter : MonoBehaviour
{
    public int barrelPoint;
    public TextMeshProUGUI barrelCounter;
    void Update()
    {
        barrelCounter.text = barrelPoint.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrel"))
        {
            barrelPoint++;
            Destroy(collision.gameObject);
        }
    }
}
