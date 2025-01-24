using UnityEngine;
using System.Collections;

public class ItsAlive : MonoBehaviour
{
    public float strength;
    public float speed;
    public Vector2 direction;


    private float nextTime = 0f;
    private FishData fishData;
    private Rigidbody2D rb; 
    private SpriteRenderer sb;

    
	private Vector2 sz;

    public 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //Retrieve screen size calculations
		sz.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(Vector2.zero),
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f - 1f;
		sz.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(Vector2.zero),
            Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f - 1f;

        rb = GetComponent<Rigidbody2D>();
        sb = GetComponent<SpriteRenderer>();

        //Start with no speed
            //rb.position.Set(Random.Range(-sz.x,sz.x), Random.Range(-sz.y,sz.y));
        direction = rb.position;
        rb.linearVelocity = Vector2.zero;
        nextTime += Time.time;

        // Generate fish data with random attributes and assign it
        fishData = new FishData(4f, 4f, rb.position);

        // Apply generated values to the fish
        sb.color = fishData.fishColor;
        strength = fishData.strength;
        speed = fishData.speed;

        //Validate position every 15 seconds
        InvokeRepeating("ValidatePos", 15f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        // Face left if moving left
        if(rb.linearVelocityX < 0){
            sb.flipX = true;
        } else {
            sb.flipX = false;
        }

        //Find new direction if current direction has been approximately reached
        if((rb.position - direction).magnitude < 2f){
            direction.Set(Random.Range(-sz.x,sz.x), Random.Range(-sz.y,sz.y));
        }

        //Just keep swimming
        if(Time.time > nextTime){
            nextTime += Random.Range(speed * 0.75f, speed * 1.5f);
            rb.AddForce((direction - rb.position).normalized * strength * 100);

            StartCoroutine(StretchEffect());  // Trigger the stretch animation
        }
    }

    void ValidatePos(){
        //Reset position and speed if out of bounds
        if(rb.position.x > 4f * sz.x || rb.position.y > 4f * sz.y){
            rb.linearVelocity = Vector2.zero;
            rb.position = Vector2.zero;
        }
    }

    IEnumerator StretchEffect()
    {
        float dd = speed / 40f;
        float et = 0f;

        Vector2 os = new Vector2(1f, 1f);
        Vector2 st = new Vector2(os.x * 1.2f, os.y * 0.8f);  // Slight stretch
        Vector2 sq = new Vector2(os.x * 0.8f, os.y * 1.2f);  // Slight stretch

        transform.localScale = os; 
        
        while (et < dd){
            transform.localScale = Vector2.Lerp(os, sq, et/dd);
            et += Time.deltaTime;
            yield return null;
        }

        transform.localScale = sq;
        dd *= 2;
        et = 0f;

        while (et < dd){
            transform.localScale = Vector2.Lerp(sq, st, et/dd);
            et += Time.deltaTime;
            yield return null;
        }

        transform.localScale = st;
        dd *= 1;
        et = 0f;

        while (et < dd){
            transform.localScale = Vector2.Lerp(st, os, et/dd);
            et += Time.deltaTime;
            yield return null;
        }

        transform.localScale = os;   
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))  // (0 = left, 1 = right, 2 = middle)
        {
        //Debug.Log("Fish deleted!");
        Destroy(gameObject);  // Destroy this fish GameObject
        }
    }

}
