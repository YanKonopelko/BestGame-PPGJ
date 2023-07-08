using UnityEngine;


public class SecurityGuard : MonoBehaviour
{
    [SerializeField] private GameObject Way;
    Point[] Points;

    private Transform _trasform;
    private Rigidbody2D rb;

    private bool isStay = false;
    private float curStayTime = 0;
    private int curPoint = 0;
    private bool isGoBack = false;
    [SerializeField] private float movementSpeed = 1;
    private SpriteRenderer sprite;

    void Start()
    {
        Points = new Point[Way.transform.childCount];
       for(int i = 0; i < Way.transform.childCount; i++) 
        {
            Points[i] = Way.transform.GetChild(i).GetComponent<Point>();
        }
        _trasform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    void FixedUpdate()
    {
        if (isStay)
        {
            rb.velocity = Vector2.zero;
            curStayTime += Time.deltaTime;
            if (curStayTime >= Points[curPoint].stayTime)
            {
                isStay = false;
                GoToNextPoint();
            }
        }
        if (!isStay) {
            Move();
            Rotate();
        }
    }

    private void GoToNextPoint()
    {

        if (!isGoBack)
        {
            if (curPoint < Points.Length - 1)
                curPoint++;
            else
            {
                isGoBack = true;
                GoToNextPoint();
            }
        }
        else
        {
            if (curPoint > 0)
                curPoint--;
            else
            {
                isGoBack = false;
                GoToNextPoint();
            }
        }
    }

    private void Move()
    {
        Vector2 moveDir = ( Points[curPoint].transform.position - _trasform.position).normalized;
        rb.velocity = moveDir * movementSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        if (rb.velocity.x < 0)
            sprite.flipX = true;
        else if (rb.velocity.x > 0)
            sprite.flipX = false;
    }
    public void PointReached()
    {
        curStayTime = 0;
        Debug.Log("Reached");
        isStay = true;
    }
}
