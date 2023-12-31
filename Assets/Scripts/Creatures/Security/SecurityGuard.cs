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

    [SerializeField] private Animation handAnim;
    [SerializeField] private Animation anim;


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

        handAnim = transform.GetChild(0).GetComponent<Animation>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.zero;

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
        if (rb.velocity.x > 0)
        {
            sprite.flipX = true;
            transform.GetChild(0).transform.localPosition = new Vector2(0.13f, transform.GetChild(0).transform.localPosition.y);
            transform.GetChild(0).transform.eulerAngles = new Vector3(0,0,90);
        }
        else if (rb.velocity.x < 0)
        {
            sprite.flipX = false;
            transform.GetChild(0).transform.localPosition = new Vector2(-0.13f, transform.GetChild(0).transform.localPosition.y);
            transform.GetChild(0).transform.eulerAngles = new Vector3(0, 0, 270);
        }
        //�������� ����
    }
    public void PointReached()
    {
        curStayTime = 0;
        isStay = true;
        HandRotate();
    }

    private void HandRotate()
    {
        //Left Rotate
        //Right Rotate
        if(sprite.flipX == true)
            handAnim.Play("RightHandRotate");
        else
            handAnim.Play("LeftHandRotate"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
            GameManager.Instance.Lose();
    }
}
