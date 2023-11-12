using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public Camera cam;
    Vector2 mousePos;
    Vector2 move;
    Rigidbody2D rgbd2d;
    Animate animate;


    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        move = new Vector2();
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


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        /*rgbd2d.MovePosition(rgbd2d.position + move * speed * Time.fixedDeltaTime);
        Vector3 lookDirection = mousePos - rgbd2d.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rgbd2d.rotation = angle;*/
    }

    public void Kill()
    {
        GameManager.Instance.Gamestatus(true);
    }
}
