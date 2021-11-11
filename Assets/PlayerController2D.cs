using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
	
	[Header("Movement")]
	public float speed;
  //  public Animator animator;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
	
	[Header("Scoring")]
	public TMPro.TMP_Text healthText;
	public TMPro.TMP_Text collectText;
    public TMPro.TMP_Text winText;
    public int health;
	public int collect;
	
	[Header("Animation")]
	public Animator animator;
	
	//[Header("Enemies")]
	//public GameObject

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
//		health = 10;
        SetHealthText ();
        winText.text = "";

    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
		
		SetHealthText();
		
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
	
	
	void SetHealthText ()
    {
        if (health >= 0)
		{
			healthText.text = "Health: " + health.ToString ();
			collectText.text = "Items: " + collect.ToString ();
		}
		
        if (health == 0)
        {
            winText.text = "You loose!";
        }
		//Debug.Log("health");
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Seaweed"))
		{
			health = health - 1;
			animator.SetBool("flashHit", true);
		}
		
		if (other.gameObject.CompareTag("Collect"))
		{
			collect = collect + 1;
			other.gameObject.SetActive(false);
		}
		
		if (other.gameObject.CompareTag("Die"))
		{
			health = health - 1;
			animator.SetBool("flashHit", true);
		}
		
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("exit");
		//animator.SetBool("flashHit", false);
		if (other.gameObject.CompareTag("Seaweed"))
		{
			animator.SetBool("flashHit", false);
		}
				
		if (other.gameObject.CompareTag("Collect"))
		{
			animator.SetBool("flashHit", false);
		}
		
		if (other.gameObject.CompareTag("Die"))
		{
			animator.SetBool("flashHit", false);
		}
	}
	
	
	
}
