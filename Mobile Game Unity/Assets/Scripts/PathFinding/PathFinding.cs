using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] private Node.Position m_end;
    [SerializeField] private Node.Position m_current;
    [SerializeField] private Node.Position m_start;



    [SerializeField] private Camera camera;
  
    [SerializeField] private LayerMask obstacles;
    [SerializeField] private Collider2D current;
    [SerializeField] private GameObject target;
    [SerializeField] private Collider2D gameArea;
    [SerializeField] private LayerMask targetMask;
    private float m_halfWidth;
    private float m_halfHeight;

    private int resultNotFound;
    private float m_mapWidth;
    private float m_mapHeight;
    private float speed = 000.3f;
    private int looperino = 0;

    private int finals = 2;
   private int d =0;

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
        m_current.setValues(this.transform.position.x, this.transform.position.y);
        Debug.Log("Width: " + m_mapWidth + " Height: " + m_mapHeight);
       

    }
    public void testing()
    {

            //transform.position = Vector3.MoveTowards(new Vector2(results.getPosition().x, results.getPosition().y), new Vector2(results.returnPrev().getPosition().x, results.returnPrev().getPosition().y), step);


            //Debug.Log(this.transform.position);
            

            //Vector3 targetVec = new Vector3(final.returnPrev().getPosition().x, final.returnPrev().getPosition().y, 0);
            //Debug.Log(targetVec);
            //transform.position = Vector3.MoveTowards(this.transform.position, targetVec, 1f);

            //final = final.returnPrev();
        
    }
   
    public void Lops()
    {
        int c =0;
        while(true)
        {
            c++;
            Debug.Log("this is c" + c);
            if (c>5)
            {
                finals = 1;
                break;
            }
                }
    }

    void Update()
    {
       m_current.setValues(this.transform.position.x, this.transform.position.y);

       
            doPathFinding();
        

        if(finals != 1)
        {
            Lops();
        }

       
       
       
    }

    

    void lineDrawer(float x, float y)
    {
        Debug.DrawLine(new Vector2(x - m_halfWidth, y - m_halfHeight),new Vector2(x - m_halfWidth, y + m_halfHeight), Color.green, 20, false);
        Debug.DrawLine(new Vector2(x - m_halfWidth, y + m_halfHeight), new Vector2(x + m_halfWidth, y + m_halfHeight), Color.green, 20, false);
        Debug.DrawLine(new Vector2(x + m_halfWidth, y + m_halfHeight), new Vector2(x + m_halfWidth, y - m_halfHeight), Color.green, 20, false);
        Debug.DrawLine(new Vector2(x + m_halfWidth, y - m_halfHeight), new Vector2(x - m_halfWidth, y - m_halfHeight), Color.green, 20, false);

    }
    
  
    public void doPathFinding()
    {
        Node results = null;
        
        Node firstNode = new Node(m_current, null, m_end, m_start);
        
        OpenList openedList = new OpenList();
        openedList.insertToOpenList(firstNode);
        
        ClosedList closedList = new ClosedList();
        SearchLvl search_lvl = new SearchLvl( obstacles,current,m_mapHeight,m_mapWidth);

        while(openedList.isEmpty() == false)
        {
            
            Node secondNode = openedList.get0();
            openedList.remove0Fromlist();
            closedList.insertToClosedList(secondNode);
            if( Physics2D.OverlapBox(new Vector2(secondNode.getPosition().x, secondNode.getPosition().y),Vector2.one,0,targetMask))
                {
                results = secondNode;
                
                break;
            }
           
            
            List<Node.Position> adjacentPositions = search_lvl.getAdjacentNodes(secondNode.getPosition().x, secondNode.getPosition().y,1, 1);
          
            for(int i = 0; i< adjacentPositions.Count; i++)
            {
                
                if(closedList.isInClosedList(adjacentPositions[i]))
                    {
                    
                    continue;

                }

                int inter = openedList.findFromOpenList(secondNode.getPosition()); //returns -1 if there was no match, iterator cant be negative anyway
                Node previousNode = new Node(adjacentPositions[i], firstNode, m_end, m_start);
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
                
                    
                    lineDrawer(previousNode.getPosition().x, previousNode.getPosition().y);
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
                    Debug.DrawLine(new Vector2(results.getPosition().x, results.getPosition().y), new Vector2(results.returnPrev().getPosition().x, results.returnPrev().getPosition().y), Color.red, 100, false);

                }
                d++;
                Debug.Log(d);
                //transform.position = Vector3.MoveTowards(new Vector2(results.getPosition().x, results.getPosition().y), new Vector2(results.returnPrev().getPosition().x, results.returnPrev().getPosition().y), step);

                //Debug.Log("X: " +results.getPosition().x);
                //Debug.Log(" New X: "+this.transform.position);
                //Debug.Log(testad);
                
                Vector3 targetVec = new Vector3(results.returnPrev().getPosition().x, results.returnPrev().getPosition().y, 0);
                //Debug.Log(targetVec);
                //transform.position = Vector3.MoveTowards(this.transform.position, targetVec, 1f);
                Debug.Log(results.returnPrev().getPosition().x);
                results = results.returnPrev();
            }
           
        }
        else
        {
            Debug.Log("not found");
            resultNotFound = 1;
            finals = 1;
        }

    }
}
