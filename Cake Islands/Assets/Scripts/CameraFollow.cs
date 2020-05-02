using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // public variables for the camera follow
    public Transform camTarget;
    public float trackingSpeed;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private void FixedUpdate()
    {
        //checks theat the cam transform valid
        if (camTarget != null)
        {
            //create a variable to lerp camera
            var newPos = Vector2.Lerp(transform.position,camTarget.position,Time.deltaTime * trackingSpeed);
            //variable for the camera position as a vector 3 the new x and y and -10 so its off the screen a bit
            var camPosition = new Vector3(newPos.x, newPos.y, -10f);
            //keeps thje cam pos in the min x and y
            var posX = Mathf.Clamp(camPosition.x, minX, maxX);
            var posY = Mathf.Clamp(camPosition.y, minY, maxY);
            //change the position to the new campos with thoughtk 5to the min and max y and x
            transform.position = new Vector3(posX, posY, -10f);
        }
    }

    
 
}
