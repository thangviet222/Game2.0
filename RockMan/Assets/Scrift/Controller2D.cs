using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public LayerMask collideMask;
    public float skinWidth;
    public int numberOfRayHonrizontal=2;
    public int numberOfRayVertical=2;

    private BoxCollider2D bc2D;
    private Bounds colliderBounds;
    private RaycastOrigins raycastOrigins;

    private float honrizontalSpacing;
    private float verticalSpacing;
    private void Awake()
    {
        bc2D = GetComponent<BoxCollider2D>();
        numberOfRayHonrizontal = numberOfRayHonrizontal < 2 ? 2 : numberOfRayHonrizontal;
        numberOfRayVertical = numberOfRayVertical < 2 ? 2 : numberOfRayVertical;

    }

    public PlayerStatus Move(Vector2 velocity)
    {
        PlayerStatus result = new PlayerStatus
        {
            velocity = velocity,
            isCollidingBottom = false,
            isCollidingLeft = false,
            isCollidingRight = false,
            isCollidingTop = false
        };
        UpdateColliderBounds();
        UpdateSpacing();
        result = RaycastHorizontal(result);
        result = RaycastVertical(result);
        //return velocity;
        return result;
    }
    private PlayerStatus RaycastHorizontal(PlayerStatus playerStatus)
    {
        Vector2 raycastOriginBottom = playerStatus.velocity.x > 0 ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;

        for (int i = 0; i < numberOfRayVertical; i++)
        {
            Vector2 rayOrigin = raycastOriginBottom + Vector2.up * i * verticalSpacing;

            RaycastHit2D hit = Physics2D.Raycast(
                rayOrigin,
                playerStatus.velocity.WithY(0),
                Mathf.Abs(playerStatus.velocity.x) + skinWidth,
                collideMask
            );

            if (hit)
            {
                playerStatus.velocity.x = (hit.distance - skinWidth) * Mathf.Sign(playerStatus.velocity.x);

                if (playerStatus.velocity.x > 0)
                {
                    playerStatus.isCollidingRight = true;
                }
                else
                {
                    playerStatus.isCollidingLeft = true;
                }
            }
        }

        return playerStatus;
    }


    private PlayerStatus RaycastVertical(PlayerStatus playerStatus)
    {
        Vector2 raycastOriginLeft = playerStatus.velocity.y > 0 ? raycastOrigins.topLeft : raycastOrigins.bottomLeft;


        for (int i = 0; i < numberOfRayHonrizontal; i++)
        {
            Vector2 rayOrigin = raycastOriginLeft + Vector2.right * i * honrizontalSpacing;

            RaycastHit2D hit = Physics2D.Raycast(
                rayOrigin,
                playerStatus.velocity.WithX(0),
                Mathf.Abs(playerStatus.velocity.y) + skinWidth,
                collideMask
            );

            if (hit)
            {
                playerStatus.velocity.y = (hit.distance - skinWidth) * Mathf.Sign(playerStatus.velocity.y);

                if (playerStatus.velocity.y > 0)
                {
                    playerStatus.isCollidingTop = true;
                }
                else
                {
                    playerStatus.isCollidingBottom = true;
                }
            }
        }

        return playerStatus;
    }

    private void UpdateColliderBounds()
    {
        colliderBounds = bc2D.bounds;
        colliderBounds.Expand(-skinWidth * 2);
       // Debug.Log(colliderBounds.extents.x);
        UpdateRaycastOrigins();
    }

    private void UpdateRaycastOrigins()
    {
        raycastOrigins.topLeft = new Vector2(
            colliderBounds.min.x,
            colliderBounds.max.y
        );
        raycastOrigins.bottomLeft = new Vector2(
            colliderBounds.min.x,
            colliderBounds.min.y
        );
        raycastOrigins.topRight = new Vector2(
            colliderBounds.max.x,
            colliderBounds.max.y
        );

        raycastOrigins.bottomRight = new Vector2(
            colliderBounds.max.x,
            colliderBounds.min.y
        );
    }
    private void UpdateSpacing()
    {
        honrizontalSpacing = (raycastOrigins.topRight.x - raycastOrigins.topLeft.x) / (numberOfRayHonrizontal - 1);
        verticalSpacing = (raycastOrigins.topRight.y - raycastOrigins.bottomRight.y) / (numberOfRayVertical - 1);

    }
}

struct RaycastOrigins
{
    public Vector2 topLeft;
    public Vector2 topRight;
    public Vector2 bottomLeft;
    public Vector2 bottomRight;
}

public struct PlayerStatus
{
    public Vector2 velocity;
    public bool isCollidingTop;
    public bool isCollidingRight;
    public bool isCollidingBottom;
    public bool isCollidingLeft;
}