using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private Node.Position m_end;
    private Node.Position m_current;
    private Node.Position m_start;
    private float m_width;
    private float m_height;


    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask walls;
    [SerializeField] private LayerMask obstacles;
    [SerializeField] private LayerMask enemies;

    void Awake()
    {
        m_height = 0;
        m_width = 0;
        //TO BE EDITED
    }
    PathFinding(Node.Position end, Node.Position start,Node.Position current)
    {
        m_end = end;
        m_current = current;
        m_start = start;


    }

    
    public void doPathFinding()
    {
        Node results = null;
        Node firstNode = new Node(m_current, null, m_end, m_start);
        
        OpenList openedList = new OpenList();
        openedList.insertToOpenList(firstNode);
        
        ClosedList closedList = new ClosedList();
        SearchLvl search_lvl = new SearchLvl(m_width, m_height, walls,obstacles, enemies);

    }
}
