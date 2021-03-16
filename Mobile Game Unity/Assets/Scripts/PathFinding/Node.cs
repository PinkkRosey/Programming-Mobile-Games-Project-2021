using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Node 
{

    public struct Position
    {
        public float x;
        public float y;

        public void setValues(float askedX, float askedY)
        {
            x = askedX;
            y = askedY;

        }
        public bool isEqual(Position first, Position second)
        {
            if((first.x == second.x) && (first.y == second.y))
            {
              
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    //Struct to hold positions
    private Node prevNode;
    private Position currentPos;
    private Position startingPos;
    private Position endingPos;
    private float m_combinedDistance;
    private float m_distanceFromStart;
    private float m_distanceToEnd;


    public Node(Position curPos, Node prev, Position endPos,Position startPos)
    {
        prevNode = null;
        currentPos = curPos;
        endingPos = endPos;
        startingPos = startPos;
        m_distanceToEnd = getDistanceToEnd();
        m_distanceFromStart = 0;
        resetPrevious(prev);

    }
    public Node()
    {
        prevNode = null;
     

    }

    private void resetPrevious(Node prev)
    {
        prevNode = prev;
        if(prev == null)
        {
            m_distanceFromStart = 0.0f;
            m_combinedDistance = m_distanceToEnd;
        }
        else
        {
            float cx = currentPos.x - prevNode.currentPos.x;
            float cy = currentPos.y - prevNode.currentPos.y;
            m_distanceFromStart = Mathf.Sqrt(cx*cx + cy*cy) + prevNode.m_distanceFromStart;
            m_combinedDistance = m_distanceFromStart + m_distanceToEnd;
        }

        //sets the values of the node

    }

  
    public Position getPosition()
    {
        return currentPos;
    }
    public float getDistanceFromStart()
    {
        return m_distanceFromStart;
    }
    public Node returnPrev()
    {
        return prevNode;
    }

    public void setPrev(Node previousOne)
    {
        prevNode = previousOne;
    }

    public float getDistanceToEnd()
    {
        float dx = endingPos.x - currentPos.x;
        float dy = endingPos.y - currentPos.y;
        m_distanceToEnd = Mathf.Sqrt(dx * dx + dy * dy);
        return m_distanceToEnd;

        //calculates distance to the end
    }

    public float getCombinedDistance()
    {
        return m_combinedDistance;
    }

}
