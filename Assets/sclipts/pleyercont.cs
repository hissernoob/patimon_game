using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pleyercont : MonoBehaviour
{
    /*
    public float speed = 0.5f;
    //void FixedUpdate()

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 x  = transform.right* speed;
        Vector3 z = transform.forward* speed;

        if (Input.GetKey ("w"))
        {
		    rb.AddForce(x);
		}
        if (Input.GetKey ("down"))
        {
            rb.AddForce(-x);
        }
        if (Input.GetKey("right"))
        {
            rb.AddForce(-z);
        }
        if (Input.GetKey ("left"))
        {
            rb.AddForce(z);
        }
        
    }
    */
    


    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    public float jumpPower;
    private bool isJumping = false;

    void Start ()
    {
        count = 0;
        SetCountText ();
        winText.text = "";
        rb = GetComponent<Rigidbody>();

        void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.CompareTag ("Pick Up"))
            {
                other.gameObject.SetActive (false);
            }
        }
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        //キー取得して、ムーブメントに割り当て（以下DSAも同じ）
        if (Input.GetKey ("w"))
        {
            movement.z += speed;
		}
        if (Input.GetKey ("s"))
        {
            movement.z -= speed;
        }
        if (Input.GetKey("d"))
        {
            movement.x += speed;;
        }
        if (Input.GetKey ("a"))
        {
            movement.x -= speed;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
        }

        rb.AddForce(movement);

//リスポーンスクリプト
    if (Input.GetKeyDown ("r"))
        {
            SceneManager.LoadScene (0);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("PP"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }

        if (other.gameObject.CompareTag ("Respawn"))
        {
            SceneManager.LoadScene (0);
        }

    }

    void SetCountText ()
    {
        countText.text = "ゲット数: " + count.ToString ();
        if (count >= 5)
        {
            winText.text = "ポケモンゲットだぜ!";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }
    }

}
