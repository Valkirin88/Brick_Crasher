using System;
using UnityEngine;

public class StartPositionCollider : MonoBehaviour
{
    public Action<Ball> IsInStartPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ball>() && collision.GetComponent<Ball>().IsGoingToStart)
        {
            
            var ball = collision.GetComponent<Ball>();
            IsInStartPosition?.Invoke(ball); 
        }
    }
}
