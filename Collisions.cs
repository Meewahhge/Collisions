using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float sprintMultiplier = 3;
    public float sneakMultiplier = .5f;
    public float turnSpeed = 100;
    public Rigidbody strafe = null;
    public float JumpForce = 1;
    float raycastHeight = 1.25f;
    public int maxJumpCount = 2;
    float jumpsRemaining = 2;
    
    void Start()
    {
        jumpsRemaining = maxJumpCount;
    }

   
    void Update()
    {
        float targetSpeed = this.moveSpeed;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            targetSpeed = this.moveSpeed * sprintMultiplier;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            targetSpeed = this.moveSpeed * sneakMultiplier;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 currentPosition = this.gameObject.transform.localPosition;
            this.gameObject.transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + targetSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 currentPosition = this.gameObject.transform.localPosition;
            this.gameObject.transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - targetSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 currentPosition = this.gameObject.transform.localPosition;
            this.gameObject.transform.localPosition = new Vector3(currentPosition.x + targetSpeed * Time.deltaTime, currentPosition.y, currentPosition.z);

        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 currentPosition = this.gameObject.transform.localPosition;
            this.gameObject.transform.localPosition = new Vector3(currentPosition.x - targetSpeed * Time.deltaTime, currentPosition.y, currentPosition.z);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpsRemaining > 0)
            {
                jumpsRemaining--;
                this.strafe.AddForce(new Vector3(0, 1, 0) * JumpForce, ForceMode.Impulse);
            }
            else if(Physics.Raycast(this.transform.position, Vector3.down, raycastHeight))
            {
                jumpsRemaining = maxJumpCount;
                this.strafe.AddForce(new Vector3(0, 1, 0) * JumpForce, ForceMode.Impulse);
                jumpsRemaining--;
            }
                
        }
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(this.transform.position, Vector3.down * raycastHeight);
    }

    public void JumpPadInteraction()
    {
            this.strafe.AddForce(new Vector3(0, 1, 0) * 200, ForceMode.Impulse);
    }

   /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "JumpPad")
        {
            this.strafe.AddForce(new Vector3(0, 1, 0) * 200, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Autosave Game");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Spawn Enemies In This Room!");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Has Left The Room");
    }*/
}