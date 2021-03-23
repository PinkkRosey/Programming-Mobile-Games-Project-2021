using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] private Node.Position m_end;
    [SerializeField] private Node.Position m_current;
    [SerializeField] private Node.Position m_start;



  
    [SerializeField] private LayerMask obstacles;
    [SerializeField] private BoxCollider2D current;
    [SerializeField] private GameObject target;
    [SerializeField] private BoxCollider2D gameArea;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private bool test2;
    [SerializeField] private EnemyMovement enemyMove;
    private float m_halfWidth;
    private float m_halfHeight;

    private int resultNotFound;
    private float m_mapWidth;
    private float m_mapHeight;
    private float speed = 000.3f;
    private int looperino = 0;

    private int finals = 2;
   private int d =0;
    private bool runThis =false;
    
     private Node results = new Node();
   public EnemyPathing finalPath = null;
    private Node.Position m_old;
    private Node.Position m_new;
   

    PathFinding(Node.Position end, Node.Position start,Node.Position current)
    {
        m_end = end;
        m_current = current;
        m_start = start;

        
    }
     void Awake()
    {
        m_halfWidth = 0.5f;
        m_halfHeight = 0.5f;
        m_mapWidth = gameArea.bounds.size.x;
        m_mapHeight = gameArea.bounds.size.y;
        //m_halfWidth = current.bounds.size.x / 2;
        //m_halfHeight = current.bounds.size.y / 2;

    }
    void Start()
    {
        
        
        m_start.setValues(this.transform.position.x, this.transform.position.y);
        m_end.setValues(target.transform.position.x, target.transform.position.y);
       
        m_new = m_end;
        m_current.setValues(this.transform.position.x, this.transform.position.y);
        Debug.Log("Width: " + m_mapWidth + " Height: " + m_mapHeight);
       

    }


    void Update()
    {
        if (enemyMove.hasMovedToNextPos)
        {


            //Only do this everytime the player has moved once, dont keep checking!
            m_current.setValues(this.transform.position.x, this.transform.position.y);

            m_new.setValues(target.transform.position.x, target.transform.position.y);
            if (m_old.x != m_new.x || m_old.y != m_new.y || (finalPath == null && results != null)) //check if the values have changed since last update also do an extra check if there is a path(results) BUT for some reason our final path is null!! THIS SHOULD NEVER OCCUR!!! But if it were to i want to make a go around
            {
                if (this.gameObject.GetComponent<EnemyMovement>().disableMovement == false)
                {
                    m_end.setValues(target.transform.position.x, target.transform.position.y);
                    doPathFinding();
                }

            }
            m_old = m_new;
        }
           
        
       
        

       
       
       
       
    }

    

    void lineDrawer(float x, float y)
    {
        Debug.DrawLine(new Vector2(x - m_halfWidth, y - m_halfHeight),new Vector2(x - m_halfWidth, y + m_halfHeight), Color.green, 2, false);
        Debug.DrawLine(new Vector2(x - m_halfWidth, y + m_halfHeight), new Vector2(x + m_halfWidth, y + m_halfHeight), Color.green, 2, false);
        Debug.DrawLine(new Vector2(x + m_halfWidth, y + m_halfHeight), new Vector2(x + m_halfWidth, y - m_halfHeight), Color.green, 2, false);
        Debug.DrawLine(new Vector2(x + m_halfWidth, y - m_halfHeight), new Vector2(x - m_halfWidth, y - m_halfHeight), Color.green, 2, false);

    }


    public void doPathFinding()
    {
        Debug.Log(current.size.x + "Y:"+ current.size.y);


        Node firstNode = new Node(m_current, null, m_end, m_start);
        finalPath = new EnemyPathing();
    OpenList openedList = new OpenList();
        
        openedList.insertToOpenList(firstNode);
        
        ClosedList closedList = new ClosedList();
        SearchLvl search_lvl = new SearchLvl( obstacles,current,m_mapHeight,m_mapWidth);

        while(openedList.isEmpty() == false)
        {
            
             Node secondNodes = openedList.get0();
            Node secondNode = new Node(secondNodes.getPosition(), secondNodes.returnPrev(),m_end, m_start);
         
           
            openedList.remove0Fromlist();
            closedList.insertToClosedList(secondNode);
            if( Physics2D.OverlapBox(new Vector2(secondNode.getPosition().x, secondNode.getPosition().y),Vector2.one,0,targetMask))
                {

                results = secondNode;
              
                break;
            }

            Debug.Log(current.size.x + current.size.y);
            List<Node.Position> adjacentPositions = search_lvl.getAdjacentNodes(secondNode.getPosition().x, secondNode.getPosition().y,current.size.x, current.size.y);
          
            for(int i = 0; i< adjacentPositions.Count; i++)
            {
                
                if(closedList.isInClosedList(adjacentPositions[i]))
                    {
                    
                    continue;

                }

                int inter = openedList.findFromOpenList(secondNode.getPosition()); //returns -1 if there was no match, iterator cant be negative anyway
                Node previousNode = new Node(adjacentPositions[i], secondNode, m_end, m_start);
                if (inter != -1)
                {
                    //has been found in open list
                   if(openedList.returnAt(inter).getDistanceFromStart() > previousNode.getDistanceFromStart()) //the new distance is smaller
                    {
                        openedList.returnAt(inter).setPrev(secondNode);
                        //setting the previous node that is found at the index
                    }

                }
                
                else
                {
                
                    
                    //lineDrawer(previousNode.getPosition().x, previousNode.getPosition().y); This method just creates a box, used for debugging purposes only!
                    openedList.insertToOpenList(previousNode);
                }

            }
            
        }
        if (results != null)
        {


           
            while (results != null)
            {
                
                if(results.returnPrev() == null)
                {
                    break;
                }
                else
                {
                    Debug.DrawLine(new Vector2(results.getPosition().x, results.getPosition().y), new Vector2(results.returnPrev().getPosition().x, results.returnPrev().getPosition().y), Color.red, 1, false);
                    finalPath.insertToPath(results);
                  //draw a line to prev
                    results = results.returnPrev();
                }
                
            
            }
           finalPath.Reversed();
           
        }
        else
        {
            finalPath = null;
            Debug.Log("not found");
            
            
        }

    }


}
