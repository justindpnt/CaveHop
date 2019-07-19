using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    // Configuration parameters
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start(){
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if (IsFacingRight()) {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        } else {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
   
    }

    // Function to return if the enemy is facing to the right
    bool IsFacingRight() {
        return transform.localScale.x > 0;
    }

    // Flip the enemy sprite if the enemy reaches the edge of a platform
    private void OnTriggerExit2D(Collider2D collision) {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}
