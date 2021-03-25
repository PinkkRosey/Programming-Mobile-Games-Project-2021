using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCheck : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] public static List<Vector2> unWalkable;
    private static float tileWid;
    private static float tileHeigh;
    [SerializeField] static List<Sprite> wallList;
    [SerializeField] private  Sprite sprite0;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private  Sprite sprite2;
    [SerializeField] private  Sprite sprite3;
    [SerializeField] private  Sprite sprite4;
    [SerializeField] private  Sprite sprite5;
    [SerializeField] private  Sprite sprite6;
    [SerializeField] private  Sprite sprite7;
    
    // Start is called before the first frame update
    public void Awake()
    {
        wallList = new List<Sprite>();
        addWalls();
        tileWid = 0.5f;
        tileHeigh = 0.5f;
        unWalkable = new List<Vector2>();

     
        getUnwalkable();
        
    }

    // Update is called once per frame


   private void addWalls()
    {
        wallList.Add(sprite0);
        wallList.Add(sprite1);
        wallList.Add(sprite2);
        wallList.Add(sprite3);
        wallList.Add(sprite4);
        wallList.Add(sprite5);
        wallList.Add(sprite6);
        wallList.Add(sprite7);
        
    }
    private void getUnwalkable()
    {
        BoundsInt bounds = tilemap.cellBounds;
        foreach (Vector3Int posi in bounds.allPositionsWithin)
        {
            Tile tile = tilemap.GetTile<Tile>(posi);
            if (tile != null)
            {
                
                if(wallList.Contains(tile.sprite))
                {
                    if(tile.sprite ==sprite0)
                    {
                        Vector2 pos1 = new Vector2(posi.x+0.5f + tileWid / 2, posi.y+ 0.5f + tileHeigh / 2);
                        if (!unWalkable.Contains(pos1))
                        {
                            unWalkable.Add(pos1);
                        }
                    }
                    else if(tile.sprite == sprite1)
                    {
                        Vector2 pos1 = new Vector2(posi.x+ 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                        if (!unWalkable.Contains(pos1))
                        {
                            unWalkable.Add(pos1);
                        }

                    }
                    else if(tile.sprite ==sprite2)
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        if (!unWalkable.Contains(pos1))
                        {
                            unWalkable.Add(pos1);
                        }

                    }
                    else if (tile.sprite == sprite3)
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        if (!unWalkable.Contains(pos1))
                        {
                            unWalkable.Add(pos1);
                        }
                    }
                    else if (tile.sprite == sprite4)
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        if (!unWalkable.Contains(pos1))
                        {
                            unWalkable.Add(pos1);
                        }
                        if (!unWalkable.Contains(pos2))
                        {
                            unWalkable.Add(pos2);
                        }

                    }
                    else if (tile.sprite == sprite5)
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                        if (!unWalkable.Contains(pos1))
                        {
                            unWalkable.Add(pos1);
                        }
                        if (!unWalkable.Contains(pos2))
                        {
                            unWalkable.Add(pos2);
                        }

                    }
                    else if (tile.sprite == sprite6)
                    {
                        Vector2 pos1= new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        if (!unWalkable.Contains(pos1))
                        {
                            unWalkable.Add(pos1);
                        }
                        if (!unWalkable.Contains(pos2))
                        {
                            unWalkable.Add(pos2);
                        }

                    }
                    else
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                        if (!unWalkable.Contains(pos1))
                        {
                            unWalkable.Add(pos1);
                        }
                        if (!unWalkable.Contains(pos2))
                        {
                            unWalkable.Add(pos2);
                        }

                    }

                }
                else
                {
                    
                    Vector2 pos1 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                    Vector2 pos2 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                    Vector2 pos3 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                    Vector2 pos4 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2);

                    if (!unWalkable.Contains(pos1))
                    {
                        unWalkable.Add(pos1);
                    }
                    if (!unWalkable.Contains(pos2))
                    {
                        unWalkable.Add(pos2);
                    }
                    if (!unWalkable.Contains(pos3))
                    {
                        unWalkable.Add(pos3);
                    }
                    if (!unWalkable.Contains(pos4))
                    {
                        unWalkable.Add(pos4);
                    }

                }
              


             
            }

            
        }
    }

        void helper()
        {
            for (int i = 0; i < unWalkable.Count; i++)
            {
                float xVal = unWalkable[i].x;
                float yVal = unWalkable[i].y;
                lineDrawer(xVal, yVal,0.5f,0.5f);


            }

        }
    void lineDrawer(float x, float y,float wid,float heigh)
    {
        Debug.DrawLine(new Vector2(x - wid / 2, y -heigh/ 2), new Vector2(x - wid / 2, y + heigh / 2), Color.green, 2, false);
        Debug.DrawLine(new Vector2(x - wid / 2, y + heigh / 2), new Vector2(x + wid / 2, y + heigh / 2), Color.green, 2, false);
        Debug.DrawLine(new Vector2(x + wid / 2, y + heigh / 2), new Vector2(x + wid / 2, y - heigh / 2), Color.green, 2, false);
        Debug.DrawLine(new Vector2(x + wid/ 2, y - heigh / 2), new Vector2(x - wid / 2, y - heigh / 2), Color.green, 2, false);

    }
}