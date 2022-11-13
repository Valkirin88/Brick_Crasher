using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquaresFiller : MonoBehaviour
{
    private const string Square = "Square";
    private const string PositionsForSquares = "PositionsForSquares";

    [SerializeField]
    private GameObject _square;
    
    private GameObject[] _squares;
    private List<Transform> _transforms;
    
    private PositionsForSquares _positionsSet;
    private int _positionCount;

    private void Awake()
    {
        _positionsSet = Resources.Load<PositionsForSquares>(PositionsForSquares);
        GeTPositionsForSquares();
        _squares = new GameObject[PositionsForSquares.Length];

        for (int i = 0; i < _positionCount; i++)
        {
            _square = Resources.Load<GameObject>(Square);
            _squares[i] = Instantiate(_square, _transforms[i].position, Quaternion.identity);
        }
    }

    private void GeTPositionsForSquares()
    {
        _transforms = new List<Transform>();
        _positionCount = _positionsSet.Positions.Count;
        for (int i = 0; i < _positionCount; i++)
        {
            _transforms.Add(_positionsSet.Positions[i]);
        }
    }
}
