using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - transform.up*castDistance, boxSize);
    }
    
    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0 ,
            -transform.up, castDistance, groundLayer))
            return true;

        return false;
    }
}
