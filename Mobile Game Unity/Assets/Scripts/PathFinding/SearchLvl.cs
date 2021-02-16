using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLvl
{


    private LayerMask m_walls;
    private LayerMask m_obstacles;
    private LayerMask m_enemies;
    private float m_height = 0f;
    private float m_width = 0f;
    

    public SearchLvl(float height, float width,LayerMask walls,LayerMask obstacles,LayerMask enemies)
    {
        m_obstacles = obstacles;
        m_enemies = enemies;
        m_height = height;
        m_width = width;
        m_walls = walls;
    }

    public bool isWalkable(float posX, float posY)
    {
        Vector2 myPosition = new Vector2(posX, posY);
        Vector2 size = new Vector2(1, 1);
        
        Physics2D.OverlapBox(myPosition, size, 0, m_walls); 
        if ((Physics2D.OverlapBox(myPosition, size, 0, m_walls) ==true) || (Physics2D.OverlapBox(myPosition, size, 0, m_obstacles) ==true ) || (Physics2D.OverlapBox(myPosition,size,0,m_enemies) ==true))
        {
            //check if you overlap with enemies, walls or obstacles [defined by layermasks]
            return false;
        }
        else
        {
            return true;
        }
        
    }

    public List<Node.Position> getAdjacentNodes(float posX, float posY)
    { 

        //ADD A STEP INSTEAD OF 1 THAT IS THE SIZE OF THE GRID CELL
        List<Node.Position> m_results = new List<Node.Position>();
        Node.Position current = new Node.Position();
        current.setValues(posX,posY);
       
        if(isWalkable(current.x+1,current.y) == true)
            {
            Node.Position plusOneX = new Node.Position();
            plusOneX.setValues(posX+1, posY);
            m_results.Add(plusOneX);

            }

        if (isWalkable(current.x - 1, current.y) == true)
        {
            Node.Position minusOneX = new Node.Position();
            minusOneX.setValues(posX - 1, posY);
            m_results.Add(minusOneX);

        }

        if (isWalkable(current.x , current.y +1 ) == true)
        {
            Node.Position plusOneY = new Node.Position();
            plusOneY.setValues(posX , posY + 1 );
            m_results.Add(plusOneY);

        }

        if (isWalkable(current.x, current.y -1 ) == true)
        {
            Node.Position minusOneY = new Node.Position();
            minusOneY.setValues(posX , posY -1 );
            m_results.Add(minusOneY);

        }

        if (isWalkable(current.x + 1, current.y + 1) == true)
        {
            Node.Position plusOneXplusY = new Node.Position();
            plusOneXplusY.setValues(posX + 1, posY +1);
            m_results.Add(plusOneXplusY);

        }
        if (isWalkable(current.x + 1, current.y -1 ) == true)
        {
            Node.Position plusOneXminusY = new Node.Position();
            plusOneXminusY.setValues(posX + 1, posY -1 );
            m_results.Add(plusOneXminusY);

        }
        if (isWalkable(current.x - 1, current.y - 1) == true)
        {
            Node.Position minusOneXminusY= new Node.Position();
            minusOneXminusY.setValues(posX -1, posY -1);
            m_results.Add(minusOneXminusY);

        }
        if (isWalkable(current.x - 1, current.y +1) == true)
        {
            Node.Position minusOneXplusY = new Node.Position();
            minusOneXplusY.setValues(posX -1, posY +1);
            m_results.Add(minusOneXplusY);

        }

        //checks all the neighbors and adds them to the results list if they are walkable
        return m_results;

    }
}
