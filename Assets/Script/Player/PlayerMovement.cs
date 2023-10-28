using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 move;
    Rigidbody2D rgbd2d;

    Animate animate;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        move = new Vector3();
        animate = GetComponent<Animate>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        animate.horizontal = move.x;

        move *= speed;
        rgbd2d.velocity = move;

    }

    public void Kill()
    {
        GameManager.Instance.Gamestatus(true);
    }
}
