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
        helper();
        
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
                    //ALWAYS ADD .5 TO BOTH SIDES DUE TO ANCHORING (TO GET THE CENTER POINT) - DO NOT CHANGE THE ANCHOR IN THE MAP OR YOU MIGHT FACE UNWANTED BEHAVIOUR IN RENDERING
                    //THIS HAS A SIZE OF .25, DIVIDES EACH NORMAL SIZED BLOCK INTO .4TH OF ITS SIZE ( OUR GAP WHICH IS tileHeigh) 
                    //.4 IS DECIDED SINCE THE SMALLEST WALL TILES ARE AROUND THIS SIZE ALWAYS MATCH YOUR SMALLEST WALL IF YOU WANT SMOOTH ENEMY MOVEMENT
                    //ADD 0.5 TO EACH VALUE BECAUSE OF ANCHORING, THEY ARENT ACTUALLY POSITIONED WHERE THEY SAY THEY ARE IF WE WANT MID POINT
                    //ADD ONE ROW BELOW AND ABOVE SINCE WE KNOW WE CANWT WALK THERE AS OUR SPRITE IS +2 "GAP" HEIGHT 
                    //MEANING WEVE DESIGNED OUR ENEMIES AS AROUND 3 HIGH 1 WIDE IN OUR GAP TERMS
                    //REMEMBER TO KEEP TILE WID + TILE HEIGH CONSTANT BETWEEN THIS FILE AND PATH CHANGING

                    //ALL THESE TILES ARE ADDED TO A LIST, PLEASE ONLY ADD BORDERS OF WALLS FOR OPTIMAZATION IF THE WDITH OF A WALL IS CREATER THAN ONE TILE UNIT WE CANT WALK IN THAT TILE ANYWAY, MOVE IT TO FLOOR!!!
                    //THESE TILES ALL HAVE DIFFERENT COLLIDERS MEANING DIFFERENT UNLWALKABLE POSITION ADD EACH SPRITE YOU WISH TO USE THAT HAS A DIFFERENT COLLIDER
                    //ELSE SHOULD BE A NORMAL SQUARE
                    //OBJECTS SHOULD ALSO BE MARKED AS WALL IF YOU DONT WANT THE ENEMY TO WALK THROUGH THEM + ADDED TO THE SPRITE WITH CUSTOM LOGIC BEFORE ELSE
                    if(tile.sprite ==sprite0)
                    {
                        Vector2 pos1 = new Vector2(posi.x+0.5f + tileWid / 2, posi.y+ 0.5f + tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2+ tileHeigh );
                        Vector2 pos3 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f +tileHeigh / 2 -tileHeigh);
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
                    }
                    else if(tile.sprite == sprite1)
                    {
                        Vector2 pos1 = new Vector2(posi.x+ 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2 + tileHeigh);
                        Vector2 pos3 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2 - tileHeigh);
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
                    }
                    else if(tile.sprite ==sprite2)
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2 +tileHeigh);
                        Vector2 pos3 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2 + tileHeigh);
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

                    }
                    else if (tile.sprite == sprite3)
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2 +tileHeigh);
                        Vector2 pos3 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2 -tileHeigh);
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

                    }
                    else if (tile.sprite == sprite4)
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2);

                        Vector2 pos3 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2 +tileHeigh);
                        Vector2 pos4 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2 -tileHeigh);
                        
                        Vector2 pos5 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2 - tileHeigh);
                        Vector2 pos6 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2 + tileHeigh);
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
                        if (!unWalkable.Contains(pos5))
                        {
                            unWalkable.Add(pos5);
                        }
                        if (!unWalkable.Contains(pos6))
                        {
                            unWalkable.Add(pos6);
                        }

                    }
                    else if (tile.sprite == sprite5)
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                       
                        Vector2 pos3 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2 -tileHeigh) ;
                        Vector2 pos4 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2 -tileHeigh) ;
                        
                        Vector2 pos5 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2 +tileHeigh);
                        Vector2 pos6 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2 + tileHeigh);
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
                        if (!unWalkable.Contains(pos5))
                        {
                            unWalkable.Add(pos5);
                        }
                        if (!unWalkable.Contains(pos6))
                        {
                            unWalkable.Add(pos6);
                        }

                    }
                    else if (tile.sprite == sprite6)
                    {
                        Vector2 pos1= new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2);

                        Vector2 pos3 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2 +tileHeigh);
                        Vector2 pos4 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2 + tileHeigh) ;
                        
                    



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
                    else
                    {
                        Vector2 pos1 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                        Vector2 pos2 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                        Vector2 pos3 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2 -tileHeigh);
                        Vector2 pos4 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2 +tileHeigh);
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
                else
                {
                    
                    Vector2 pos1 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                    Vector2 pos2 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2);
                    Vector2 pos3 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2);
                    Vector2 pos4 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2);


                    Vector2 pos5 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f - tileHeigh / 2 - tileHeigh );
                    Vector2 pos6 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f - tileHeigh / 2 -tileHeigh );
                    Vector2 pos7 = new Vector2(posi.x + 0.5f - tileWid / 2, posi.y + 0.5f + tileHeigh / 2 + tileHeigh );
                    Vector2 pos8 = new Vector2(posi.x + 0.5f + tileWid / 2, posi.y + 0.5f + tileHeigh / 2 +tileHeigh);

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
                    if (!unWalkable.Contains(pos5))
                    {
                        unWalkable.Add(pos5);
                    }
                    if (!unWalkable.Contains(pos6))
                    {
                        unWalkable.Add(pos6);
                    }
                    if (!unWalkable.Contains(pos7))
                    {
                        unWalkable.Add(pos7);
                    }
                    if (!unWalkable.Contains(pos8))
                    {
                        unWalkable.Add(pos8);
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
                lineDrawer(xVal, yVal,tileWid,tileHeigh);


            }

        }

    //HELPER JUST CREATES LINES BASED ON CELLSIZE(0.5) TO VISUALIZE THE UNLWALKABLE POSITIONS,CELLSIZE == TRAVEL GAP
    void lineDrawer(float x, float y,float wid,float heigh)
    {
        Debug.DrawLine(new Vector2(x - wid / 2, y -heigh/ 2), new Vector2(x - wid / 2, y + heigh / 2), Color.green, 10, false);
        Debug.DrawLine(new Vector2(x - wid / 2, y + heigh / 2), new Vector2(x + wid / 2, y + heigh / 2), Color.green, 10, false);
        Debug.DrawLine(new Vector2(x + wid / 2, y + heigh / 2), new Vector2(x + wid / 2, y - heigh / 2), Color.green, 10, false);
        Debug.DrawLine(new Vector2(x + wid/ 2, y - heigh / 2), new Vector2(x - wid / 2, y - heigh / 2), Color.green, 10, false);

    }
}