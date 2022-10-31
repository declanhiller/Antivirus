using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Node parent = null;
    private Rect rect;
    private List<Node> child = new List<Node>();
    
    
    
    public bool IsPositionIsContained(Vector2 pos)
    {
        if (pos.x >= rect.xMin && pos.x <= rect.xMax && pos.y >= rect.yMin && pos.y <= rect.yMax)
        {
            return true;
        }

        return false;
    }
    
}