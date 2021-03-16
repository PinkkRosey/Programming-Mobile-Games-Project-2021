using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLvl
{


 
    

    private LayerMask m_impactedLayers;
    private Collider2D m_targetCollider;
    private float m_height;
    private float m_width;
    

    public SearchLvl(LayerMask obstacles, Collider2D target,float height, float width)
    {
      
      
        
        m_impactedLayers = obstacles;
        m_targetCollider = target;
        m_height = height;
        m_width = width;
  
       
    }

    public bool isWalkable(float posX, float posY)
    {
        if(posX > (m_width/2) || posX < -(m_width/2) || posY >(m_height/2) || posY < -(m_height/2))
        {
            return false;
        }
        else
        {
            Vector2 myPosition = new Vector2(posX, posY);

            if (Physics2D.OverlapBox(myPosition, Vector2.one, 0, m_impactedLayers))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
      
        
        
        
    }

    public List<Node.Position> getAdjacentNodes(float posX, float posY,float colWidth, float colHeight)
    { 

        //ADD A STEP INSTEAD OF 1 THAT IS THE SIZE OF THE GRID CELL
        List<Node.Position> m_results = new List<Node.Position>();
        Node.Position current = new Node.Position();
        current.setValues(posX,posY);
       
        if(isWalkable(current.x+ colWidth, current.y) == true)
            {
            Node.Position plusOneX = new Node.Position();
            plusOneX.setValues(posX+ colWidth, posY);
            m_results.Add(plusOneX);

            }

        if (isWalkable(current.x - colWidth, current.y) == true)
        {
            Node.Position minusOneX = new Node.Position();
            minusOneX.setValues(posX - colWidth, posY);
            m_results.Add(minusOneX);

        }

        if (isWalkable(current.x , current.y + colHeight) == true)
        {
            Node.Position plusOneY = new Node.Position();
            plusOneY.setValues(posX , posY + colHeight);
            m_results.Add(plusOneY);

        }

        if (isWalkable(current.x, current.y - colHeight) == true)
        {
            Node.Position minusOneY = new Node.Position();
            minusOneY.setValues(posX , posY - colHeight);
            m_results.Add(minusOneY);

        }

        if (isWalkable(current.x + colWidth, current.y + colHeight) == true)
        {
            Node.Position plusOneXplusY = new Node.Position();
            plusOneXplusY.setValues(posX + colWidth, posY + colHeight);
            m_results.Add(plusOneXplusY);

        }
        if (isWalkable(current.x + colWidth, current.y - colHeight) == true)
        {
            Node.Position plusOneXminusY = new Node.Position();
            plusOneXminusY.setValues(posX + colWidth, posY - colHeight);
            m_results.Add(plusOneXminusY);

        }
        if (isWalkable(current.x - colWidth, current.y - colHeight) == true)
        {
            Node.Position minusOneXminusY= new Node.Position();
            minusOneXminusY.setValues(posX - colWidth, posY - colHeight);
            m_results.Add(minusOneXminusY);

        }
        if (isWalkable(current.x - colWidth, current.y + colHeight) == true)
        {
            Node.Position minusOneXplusY = new Node.Position();
            minusOneXplusY.setValues(posX - colWidth, posY + colHeight);
            m_results.Add(minusOneXplusY);

        }

        //checks all the neighbors and adds them to the results list if they are walkable
        return m_results;

    }
}
