using System.Collections.Generic;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _balls;
    [SerializeField]
    private Transform _startPoint;
    [SerializeField]
    private float _speed = 60f;
    [SerializeField]
    private BottomCollider _bottom;
    [SerializeField]
    private StartPositionCollider _startPositionCollider;

    
    private List<Rigidbody2D> _circleRigidbody;

    private void Start()
    {
                
        _circleRigidbody = new List<Rigidbody2D>();
        _bottom.IsInBottom += MoveToStartPosition;
        _startPositionCollider.IsInStartPosition += StopMoving;

        foreach (var ball in _balls)
        {
            _circleRigidbody.Add(ball.GetComponent<Rigidbody2D>());
        }
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 0; i < _balls.Count; i++)
            {
                _circleRigidbody[i].velocity = (_mousePosition - _balls[i].transform.position).normalized * _speed;
            }
        }
    }

    private void MoveToStartPosition(Ball obj)
    {   
        var offset = Time.deltaTime * _speed;
        var objRigidbody = obj.GetComponent<Rigidbody2D>();
        var ToStartPosition = _startPoint.position - obj.transform.position;
        objRigidbody.velocity = ToStartPosition.normalized * _speed;
    }

    private void StopMoving(Ball obj)
    {
        var objRigidbody = obj.GetComponent<Rigidbody2D>();
        objRigidbody.velocity = Vector2.zero;
        obj.IsGoingToStart = false;
    }
}
