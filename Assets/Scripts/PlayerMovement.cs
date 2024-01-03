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

    private void Update()
    {
        //tempMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        tempMovement = Input.GetAxis("Horizontal") * Camera.main.transform.right + Input.GetAxis("Vertical") * Camera.main.transform.forward;
        tempMovement.y = 0f; // Ensure no vertical movement
    }

    // Update is called once per frame
    // FixedUpdate is called at a fixed time interval, good for physics calculations
    void FixedUpdate()
    {
        // Call PlayerMove and ChangeAnimation methods every FixedUpdate
        PlayerMove();
        ChangeAnimation();
    }

    // Method to handle player movement
    void PlayerMove()
    {
        //tempMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //float rot = Mathf.Atan2(tempMovement.z, tempMovement.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, rot, 0f);
  
        // Set the movement direction using the Move method from the BaseMovement class
        Move(tempMovement);
    }

    void ChangeAnimation()
    {
        // Check if the AnimationController reference is set
        if (myAnim)
        {
            // Check if the player is moving
            if (tempMovement.magnitude > 0f)
            {
                // Set the "Running" boolean parameter to true in the animator
                myAnim.ChangeAnimBoolValue("Running", true);

                // Calculate rotation angle based on movement direction for player orientation
                float rot = Mathf.Atan2(-tempMovement.z, tempMovement.x) * Mathf.Rad2Deg + 90f;
                transform.rotation = Quaternion.Euler(0f, rot, 0f);
            }
            else
            {
                // If not moving, set the "Running" boolean parameter to false
                myAnim.ChangeAnimBoolValue("Running", false);
            }
        }
    }
}
