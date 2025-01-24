using UnityEngine;

public class ItsAlive : MonoBehaviour
{
    public float strength = 4f;
    public float speed = 4f;

    public Vector2 direction;
    private float nextTime = 1f;
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

        //Start at a random location with no speed
        //rb.position.Set(Random.Range(-sz.x,sz.x), Random.Range(-sz.y,sz.y));
        direction = rb.position;
        rb.linearVelocity = Vector2.zero;
        nextTime += Time.time;

        //Check position every 15 seconds
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
        }
    }

    void ValidatePos(){
        //Reset position and speed if out of bounds
        if(rb.position.x > 4f * sz.x || rb.position.y > 4f * sz.y){
            rb.linearVelocity = Vector2.zero;
            rb.position = Vector2.zero;
        }
    }
}
