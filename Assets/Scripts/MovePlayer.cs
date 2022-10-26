using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    int j;
    private List<Vector3> positionMouse=new List<Vector3>();
    private bool checkMove=false;
    
    Transform[] points;
    
    public LineRenderer line;

    private void Awake()
    {
        j = 0;
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.positionCount = 1;
      
    }

    private void Start()
    {
       line.SetPosition(1, transform.position);
    }


    
    void Update()
    {
        /*  if (Input.touchCount == 1)
          {
              Move();
          }*/
        if (Input.GetMouseButtonDown(0))
        {           
            Move();
        }
      
       
        
        if (checkMove)
        {
            Player();
            if (transform.position == positionMouse[j])
            {
                checkMove = false;
                j++;
                Player();
                checkMove = true;

            }
           
        }
        
    }
    void Move()
    {      
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))
        {      
            positionMouse.Add(hit.point);  
           
            Debug.Log(positionMouse[0]);
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, hit.point);


            checkMove = true;

        }
        
    }

  
    void Player()
    {
      
        transform.position = Vector3.MoveTowards(transform.position, positionMouse[j], 5f * Time.deltaTime);
            
    }
}
