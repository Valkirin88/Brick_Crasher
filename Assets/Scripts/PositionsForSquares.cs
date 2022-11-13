using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PositionsForSquares", menuName = "ScriptableObjects/PositionsForSquares")]
public class PositionsForSquares : ScriptableObject
{
    [SerializeField]
    private List<Transform> _positions;

    public List<Transform> Positions  => _positions; 
}
