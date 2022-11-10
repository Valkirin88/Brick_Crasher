using System;
using UnityEngine;

public class BottomCollider : MonoBehaviour
{
    [SerializeField]
    private Transform _startPosition;

    public Action<Ball> IsInBottom;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ball>())
        {
            var ball = collision.GetComponent<Ball>();
            ball.IsGoingToStart = true;
            IsInBottom?.Invoke(ball);

        }
    }
   
}
