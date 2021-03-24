using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLvl
{


 
    

    
    private Collider2D m_targetCollider;
    private List<Vector2> m_unWalkables = null;


    public SearchLvl(LayerMask obstacles, Collider2D target,List<Vector2> unableToWalk)
    {

        
        m_unWalkables = unableToWalk;
        
        m_targetCollider = target;
        
  
       
    }

    public bool isWalkable(float posX, float posY)
    {
       
        Vector2 myPosition = new Vector2(posX, posY);

        if (m_unWalkables.Contains(myPosition))
         {
            
             return false;
         }
         else
         {
           
             return true;
         }

         
        
      
        
        
        
    }
/*
    public bool isInList(Vector2 checking)
    {

        for(int i =0; i == m_unWalkables.Count; i++)
        {
            if(m_unWalkables[i].x == checking.x && m_unWalkables[i].y == checking.y)
            {
                return true;
            }
        }
        return false;
    }
    */

    public List<Node.Position> getAdjacentNodes(float posX, float posY, float colWidth)
    { 

        //ADD A STEP INSTEAD OF 1 THAT IS THE SIZE OF THE GRID CELL
        List<Node.Position> m_results = new List<Node.Position>();
        Node.Position current = new Node.Position();
        current.setValues(posX,posY);
       
        if(isWalkable(current.x+ (colWidth), current.y) == true)
            {
            Node.Position plusOneX = new Node.Position();
            plusOneX.setValues(posX+ (colWidth), posY );
            m_results.Add(plusOneX);

            }

        if (isWalkable(current.x - (colWidth ), current.y) == true)
        {
            Node.Position minusOneX = new Node.Position();
            minusOneX.setValues(posX - (colWidth), posY);
            m_results.Add(minusOneX);

        }

        if (isWalkable(current.x , current.y + (colWidth)) == true)
        {
            Node.Position plusOneY = new Node.Position();
            plusOneY.setValues(posX , posY + colWidth);
            m_results.Add(plusOneY);

        }

        if (isWalkable(current.x, current.y - (colWidth)) == true)
        {
            Node.Position minusOneY = new Node.Position();
            minusOneY.setValues(posX , posY - colWidth);
            m_results.Add(minusOneY);

        }

        if (isWalkable(current.x + colWidth , current.y + (colWidth)) == true)
        {
            Node.Position plusOneXplusY = new Node.Position();
            plusOneXplusY.setValues(posX + colWidth , posY + colWidth);
            m_results.Add(plusOneXplusY);

        }
        if (isWalkable(current.x + colWidth, current.y - colWidth) == true)
        {
            Node.Position plusOneXminusY = new Node.Position();
            plusOneXminusY.setValues(posX + colWidth , posY - colWidth );
            m_results.Add(plusOneXminusY);

        }
        if (isWalkable(current.x - colWidth , current.y - colWidth) == true)
        {
            Node.Position minusOneXminusY= new Node.Position();
            minusOneXminusY.setValues(posX - colWidth , posY - colWidth);
            m_results.Add(minusOneXminusY);

        }
        if (isWalkable(current.x - colWidth , current.y + colWidth ) == true)
        {
            Node.Position minusOneXplusY = new Node.Position();
            minusOneXplusY.setValues(posX - colWidth , posY + colWidth);
            m_results.Add(minusOneXplusY);

        }

        //checks all the neighbors and adds them to the results list if they are walkable
        return m_results;

    }
}
