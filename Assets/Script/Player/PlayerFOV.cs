/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
    public float radius = 5f;
    [Range(1, 360)] public float angle = 45f;

    private LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public GameObject playerRef;

    public bool canSeePlayer {  get; private set; }

    public Sprite fieldOfViewSprite;
    private SpriteRenderer fieldOfViewRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindWithTag("Player");
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;

            Vector2 directionToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

}
*/