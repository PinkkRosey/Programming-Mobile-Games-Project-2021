using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OpenList
{
   
    private List<Node> m_openList = new List<Node>();

    private bool m_isEmpty;
    public void insertToOpenList(Node n)
    {
        m_openList.Add(n);
        sortOpenList();

    }
    public int findFromOpenList(Node.Position myPos)
    {
        for (int i =0; i< m_openList.Count; i++)
        {
            Node.Position currentTest = m_openList[i].getPosition();
           if (currentTest.isEqual(currentTest,myPos))
            {
                return i;
            }
               
              
        }

        return -1;
    }
    public void sortOpenList()
    {
        m_openList.Sort((x, y) => x.getCombinedDistance().CompareTo(y.getCombinedDistance()));
        
    }

    public void remove0Fromlist()
    {
        m_openList.RemoveAt(0);
    }

    public Node get0()
    {
        return m_openList[0];
    }

    public Node returnAt(int iterat)
    {
        return m_openList[iterat];
    }

    
    public bool isEmpty()
    {
        m_isEmpty = !m_openList.Any();
        return m_isEmpty;
    }


}
