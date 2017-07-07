using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public LayerMask collideMask;
    public float skinWidth;
    public int numberOfRay;

    private BoxCollider2D bc2D;
    private Bounds colliderBounds;
    private RaycastOrigins raycastOrigins;
    private float rangeOfTopToBotCollider;
    private float rangeOfLeftToRightCollider;
    private bool checkTop=false, checkBot=false, checkLeft=false, checkRight=false;
    private bool checkisColliding;
    private void Awake()
    {
        bc2D = GetComponent<BoxCollider2D>();
    }
    
    public PlayerStatus Move(Vector2 velocity)
    {
        UpdateColliderBounds();

        velocity = RaycastHorizontal(velocity);
        velocity = RaycastVertical(velocity);
        //return velocity;

        return new PlayerStatus
        {
            velocity = velocity,
            isCollidingBottom = checkBot,
            isCollidingLeft = checkLeft,
            isCollidingRight = checkRight,
            isCollidingTop = checkTop
        };
    }
    private float UpdateVelocity(Vector2 raycast1,Vector2 velocytyWithXY,float velocytyXY)
    {   RaycastHit2D newHit = Physics2D.Raycast(
           raycast1,
           velocytyWithXY,
           Mathf.Abs(velocytyXY) + skinWidth,
           collideMask);
        if (newHit)
        {
            velocytyXY = (newHit.distance - skinWidth) * Mathf.Sign(velocytyXY);
            checkisColliding = !false;
        }
        else
        {
            checkisColliding = !true;
        }
        return velocytyXY;
    }
    private Vector2 RaycastHorizontal(Vector2 velocity)
    {
        for (int i = 0; i < numberOfRay; i++)
        {
            Vector2 newRaycast = velocity.x > 0 ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;
            bool check = newRaycast.Equals(raycastOrigins.bottomRight) ? true : false;
            newRaycast += new Vector2(0,(rangeOfTopToBotCollider*i)/(numberOfRay-1));
            velocity.x = UpdateVelocity(newRaycast, velocity.WithY(0), velocity.x);
            if (check)
            {
                checkRight = checkisColliding;
            }else if(!check )
            {
                checkLeft = checkisColliding;
            }
   
        }
        return velocity;
    }

    private Vector2 RaycastVertical(Vector2 velocity)
    {
        for (int i = 0; i < numberOfRay; i++)
        {
            Vector2 newRaycast = velocity.y > 0 ? raycastOrigins.topLeft : raycastOrigins.bottomLeft;
            bool check = newRaycast.Equals(raycastOrigins.topLeft) ? true : false;
            newRaycast += new Vector2((rangeOfLeftToRightCollider * i) / (numberOfRay - 1), 0);
            velocity.y = UpdateVelocity(newRaycast, velocity.WithX(0), velocity.y);
            if(check)
            {
                checkTop = checkisColliding;
            }else if(!check)
            {
                checkBot = checkisColliding;
            }
        }
        return velocity;
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
        rangeOfTopToBotCollider = (colliderBounds.max.y-colliderBounds.min.y);
        rangeOfLeftToRightCollider = (colliderBounds.max.x - colliderBounds.min.x);
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