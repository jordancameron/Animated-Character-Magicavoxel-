using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseMovement
{
    [SerializeField]
    private AnimatorController myAnim;
    
    private Vector3 tempMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Move(tempMovement);
        if (myAnim)
        {
            if(tempMovement.magnitude > 0f)
            {
                myAnim.ChangeAnimBoolValue("Running", true);
            }
            else
            {
                myAnim.ChangeAnimBoolValue("Running", false);
            }
        }
    }
}
