using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
    private Rigidbody playerRB;
    public float jumpForce =10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver =false;
    private Animator playerAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } else if(collision.gameObject.CompareTag("Obsticle"))
        {
            gameOver = true;
            Debug.Log("gameover");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_init", 1);
        }
    }
}
