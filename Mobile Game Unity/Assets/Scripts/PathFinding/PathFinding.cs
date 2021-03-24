using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinding : MonoBehaviour
{
    [SerializeField] private Node.Position m_end;
    [SerializeField] private Node.Position m_current;
    [SerializeField] private Node.Position m_start;

    [SerializeField] private LayerMask obstacles;
    [SerializeField] private BoxCollider2D current;
    [SerializeField] private GameObject target;

    [SerializeField] private LayerMask targetMask;

    [SerializeField] private EnemyMovement enemyMove;
    [SerializeField] private TileCheck tileCheck;
    private float distanceTo;
    private float m_halfWidth;
    private float m_halfHeight;

    private int resultNotFound;
    private float m_mapWidth;
    private float m_mapHeight;
    private bool activatePath = false;
    private Node results = new Node();
    public EnemyPathing finalPath = null;
    private Node.Position m_old;
    private Node.Position m_new;
    [SerializeField] public bool donePathFind;
    
    private List<Vector2> unWalkable;
    [SerializeField] Sprite[] smallWalls;
    private float tileWid;
    private Vector3 movementTarget;
    PathFinding(Node.Position end, Node.Position start, Node.Position current)
    {
        m_end = end;
        m_current = current;
        m_start = start;


    }
    void Awake()
    {
        tileWid = 0.5f;
        m_halfWidth = 0.5f;
        m_halfHeight = 0.5f;

        //m_halfWidth = current.bounds.size.x / 2;
        //m_halfHeight = current.bounds.size.y / 2;

    }
    void Start()
    {
        unWalkable = new List<Vector2>();
       
        unWalkable = tileCheck.unWalkable;
        m_start.setValues(transform.position.x, transform.position.y);
        m_end.setValues(target.transform.position.x, target.transform.position.y);
        m_old.setValues(-100f, -100f);
        m_new = m_end;
        m_current.setValues(transform.position.x, transform.position.y);

       
        
       
    }

  

   
        
    
    void FixedUpdate()
    {
      
      
        float distanceTo = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, target.transform.position.y));
        
       
        if (distanceTo <= 4)
        {
            activatePath = true;
        }


        if (activatePath == true)
        {
            if (finalPath == null)
            {
                m_new.setValues(target.transform.position.x, target.transform.position.y);
                m_current.setValues(this.transform.position.x, this.transform.position.y);


                m_end.setValues(target.transform.position.x, target.transform.position.y);

                doPathFinding();
                m_old = m_new;
                if (finalPath == null)
                {

                    return;
                } //if its still null after checking for path


            }
            else
            {
                if(finalPath.returnCount()>0)
                {
                    movementTarget = new Vector3(finalPath.get0().getPosition().x, finalPath.get0().getPosition().y, 0);
                }
              
            }

            if (transform.position == movementTarget)
            {
                m_new.setValues(target.transform.position.x, target.transform.position.y);
                m_current.setValues(this.transform.position.x, this.transform.position.y);


                m_end.setValues(target.transform.position.x, target.transform.position.y);



                //Only do this everytime the player has moved once, dont keep checking!

                if (m_old.x != m_new.x || m_old.y != m_new.y) //check if the values have changed since last update also do an extra check if there is a path(results) BUT for some reason our final path is null!! THIS SHOULD NEVER OCCUR!!! But if it were to i want to make a go around
                {

                    if (enemyMove.disableMovement == false)
                    {

                        doPathFinding();
                        m_old = m_new;

                    }

                }

            }

        }
       
        

       
       
       
       
    }

    

    void lineDrawer(float x, float y)
    {
        Debug.DrawLine(new Vector2(x - m_halfHeight/2, y - m_halfHeight / 2),new Vector2(x - m_halfHeight / 2, y + m_halfHeight / 2), Color.green, 2, false);
        Debug.DrawLine(new Vector2(x - m_halfHeight / 2, y + m_halfHeight / 2), new Vector2(x + m_halfWidth / 2, y + m_halfHeight / 2), Color.green, 2, false);
        Debug.DrawLine(new Vector2(x + m_halfHeight / 2, y + m_halfHeight / 2), new Vector2(x + m_halfWidth / 2, y - m_halfHeight / 2), Color.green, 2, false);
        Debug.DrawLine(new Vector2(x + m_halfHeight / 2, y - m_halfHeight / 2), new Vector2(x - m_halfWidth / 2, y - m_halfHeight / 2), Color.green, 2, false);

    }


    public void doPathFinding()
    {
        



        Node firstNode = new Node(m_current, null, m_end, m_start);
        lineDrawer(m_current.x, m_current.y);
            finalPath = new EnemyPathing();
        
    OpenList openedList = new OpenList();
        
        openedList.insertToOpenList(firstNode);
        
        ClosedList closedList = new ClosedList();
        SearchLvl search_lvl = new SearchLvl( obstacles,current,unWalkable);

        while(openedList.isEmpty() == false)
        {
          
             Node secondNodes = openedList.get0();
            Node secondNode = new Node(secondNodes.getPosition(), secondNodes.returnPrev(),m_end, m_start);
         
           
            openedList.remove0Fromlist();
            closedList.insertToClosedList(secondNode);
            if( Physics2D.OverlapBox(new Vector2(secondNode.getPosition().x, secondNode.getPosition().y),new Vector2(m_halfWidth / 2, m_halfWidth / 2),0,targetMask))
                {

                results = secondNode;
              
                break;
            }

           
            List<Node.Position> adjacentPositions = search_lvl.getAdjacentNodes(secondNode.getPosition().x, secondNode.getPosition().y, tileWid);
          
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
                
                    
                    //lineDrawer(previousNode.getPosition().x, previousNode.getPosition().y); 
                    //This method just creates a box, used for debugging purposes only!
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
                    finalPath.insertToPath(results);
                    results = null;
                    donePathFind = true;
                    
                    


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
            donePathFind = true;
            finalPath = null;
            Debug.Log("not found");
            
            
        }

    }

    private void onCompletion()
    {
        donePathFind = true;
        results = null;
    }
}
