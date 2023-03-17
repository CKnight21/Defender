using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //The node that this one connects to
    public Movement next;

    //Will return the nexst node
    public virtual Movement GetNext()
    {
        return next;
    }

    //A callback function that gets called when its time to draw gizmos
    private void OnDrawGizmos()
    {
        if (!next) //Or if(next == null) //Both are fine
        {
            return;
        }

        //Sets the collor of the gizmos
        Gizmos.color = Color.yellow;

        //Draw a line between the position of the ohject and the positions of the "next" object
        Gizmos.DrawLine(transform.position, next.transform.position);


    }
}
