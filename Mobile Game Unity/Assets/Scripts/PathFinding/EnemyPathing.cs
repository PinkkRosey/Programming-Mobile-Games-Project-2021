using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyPathing 
{
    private List<Node> m_enemyPath = new List<Node>();
    private bool m_isEmpty;


    public void insertToPath(Node n)
    {
        m_enemyPath.Add(n);
    }


    public void Reversed()
    {
        m_enemyPath.Reverse();
    }
    public Node get0()
    {
        return m_enemyPath[0];
    }
    public void remove0Fromlist()
    {
        m_enemyPath.RemoveAt(0);
    }
    public bool isEmpty()
    {
        m_isEmpty = !m_enemyPath.Any();
        return m_isEmpty;
    }

   
}
