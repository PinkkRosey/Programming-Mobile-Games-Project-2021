using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedList 
{
    
        private List<Node> m_closedList = new List<Node>();
    public void insertToClosedList(Node n)
    {
        m_closedList.Add(n);
    }
  


    public bool isInClosedList(Node.Position myPos)
    {
        for (int i = 0; i < m_closedList.Count; i++)
        {
            Node.Position currentTest = m_closedList[i].getPosition();
            if (currentTest.isEqual(currentTest, myPos))
            {
                return true;
            }


        }

        return false;
    }


}
