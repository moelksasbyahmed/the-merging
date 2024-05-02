
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controler : MonoBehaviour
{
    public static int deathTimes = 0;
    public GameObject deadPlayer;
    public void damaged()
    {
        Debug.Log("damaged");
        if(CheckPoint.lastCheckPoint != null)
        {
            Instantiate(deadPlayer,transform.position - new Vector3 { y = 0.5f}, transform.rotation);
            deathTimes++;

            transform.position = CheckPoint.lastCheckPoint.transform.position + new Vector3 { x = 2 };
  
        // hearts.less();
        }
        

    }
    public void getCoin()
    {
        Debug.Log("coined");

    }
    public void win(int levelPassed)
    {
        Debug.Log("winned");
        if (levelPassed >= 2)
        {
            Debug.Log("i loaded here");
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(3);
            Debug.Log(levelPassed);
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
            Debug.Log("loaded");
            SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));
        }

    }
  public  bool alive = true;
    //   public GameObject dieScreen;
    public void death()
    {
        alive = false;
        animator.SetBool("died", true);
        Destroy(gameObject, 6);


    }

    private void OnDestroy()
    {
        if (alive == false)
        {
            alive = true;
            animator.SetBool("died", false);
            // manageHealth.nHearts = 3;

            SceneManager.LoadScene(0);
        }
    }



    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float walkbehindSpeed = 3f;

    [SerializeField] private float maxVelocity = 30f;
    [SerializeField] private float jumpCooldown = 0.4f;
    [SerializeField] private float maxJumpHoldTime = 1f;

    [Header("Rotation Settings")]
    [SerializeField] private GameObject head;
    [SerializeField] private float rotationSpeed = 10f;

    private Animator animator;
    private Rigidbody2D rb;
    public bool isGrounded;
    // private bool canJump = true;

    [Header("Jump Settings")]
    [SerializeField] private float minJumpForce = 300f;
    [SerializeField] private float maxJumpForce = 1000f;

    private float currentJumpForce;
    private bool isChargingJump;

    //public climp climpcontroler;

    /*
       void handleclimping()
       {
           if(!isGrounded && Input.GetKeyDown(KeyCode.Space) && climpcontroler.theholdtarget != null)
          transform.GetComponent<holdinghandler>().thedeephandtarget.transform.position = climpcontroler.theholdtarget.transform.position;
       }
       */
    // manageHealth hearts;
    private void Start()
    {
        //  hearts = GameObject.Find("heart zone").GetComponent<manageHealth>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    playerstates currentstate = playerstates.idle;



    private void Update()

    {
        if (alive)
        {
            if(transform.position.y < -45f)
            {
                damaged();
            }
            handleWallJump();
            uppdateScale();
         //   checkGrounded();

            // fire();
            HandleMovement();
            // newJump();
            jumpwhilewalking();

            // newJump();
            UpdateAnimator();
            // HandleChargingJump();
            // HandleReadyToJumpAnimation();
        }

    }


    private void HandleReadyToJumpAnimation()
    {
        bool isWalking = animator.GetBool("walking");
        bool isRunning = animator.GetBool("running");

        if (!isWalking && !isRunning && Input.GetKey(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("readyToJump", true);
        }
        else
        {
            animator.SetBool("readyToJump", false);
        }
    }
    void movetofalling()
    {
        animator.Play("falling");
    }
    private float chargingtime;
    private float starttime;
    private bool allowed;
    public int normalJumpForce;
    void jumpwhilewalking()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&  /*&& canJump*/  isGrounded)
        {
           
           
                rb.AddForce(Vector2.up * normalJumpForce);

            
        }
    }
    private void newJump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded  /*&& canJump*/)
        {

            // Start the charging process
            isChargingJump = true;
            starttime = Time.time;
        }

        if (isChargingJump)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                chargingtime = Time.time - starttime;

            }
            else
            {

                currentJumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, (chargingtime / maxJumpHoldTime));
                //allow the jump function "thejump" to be called from the animation itself
                allowed = true;
                isChargingJump = false;
                animator.SetTrigger("jump");

                animator.SetBool("readyToJump", false);
            }
        }
    }

    public float wallJumpForce;
  [Tooltip("1 for the up foce to be fully there, 0 for the force o be only horizontal")]
    public float upForceWeaker;
    void handleWallJump()
    {
        if (!isGrounded && Input.GetKeyDown(KeyCode.Space) && GetComponentInChildren<wallJump>().walljumpAvailable)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce((new Vector3 { x = GetComponentInChildren<wallJump>().direction } * wallJumpForce) + (Vector3.up * wallJumpForce * upForceWeaker));
        }
    }

    //called in the animation
    void thejump()
    {
        if (allowed)
        {

            // Perform the actual jump with the charged force
            rb.AddForce(Vector2.up * currentJumpForce);

            currentJumpForce = 0f;
            isChargingJump = false;
            allowed = false;
        }
    }

    private void HandleChargingJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("readyToJump", true); // Start the ready to jump animation
        }

        if (animator.GetBool("readyToJump"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentJumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, Time.timeSinceLevelLoad / maxJumpHoldTime);
                currentJumpForce = Mathf.Clamp(currentJumpForce, minJumpForce, maxJumpForce);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("readyToJump", false);


                // Perform the actual jump with the charged force
                //  rb.AddForce(Vector2.up * currentJumpForce);
                //currentJumpForce = 0f; // Reset the current jump force
            }
        }
    }

    public float airControlSpeed;
    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float speed = (Input.GetKey(KeyCode.LeftShift) && isGrounded) ? runSpeed :(isGrounded)? walkSpeed:airControlSpeed;
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Apply smoothing to avoid sudden velocity changes
        rb.velocity = Vector2.Lerp(rb.velocity, movement, Time.deltaTime * 10f);

        // Clamp the velocity to avoid excessive speed
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), rb.velocity.y);





    }

    void uppdateScale()
    {
        transform.localScale = new Vector3 { x = Mathf.Sign(rb.velocity.x) * 1f, y = 1f, z = 1f };
    }


    /*
        private IEnumerator ResetJumpCooldown()
        {
            yield return new WaitForSeconds(jumpCooldown);
            canJump = true;
        }
    */
    private void UpdateAnimator()
    {

        float horizontalInput = Input.GetAxis("Horizontal") * GetComponent<Transform>().localScale.x;

        bool isWalking = Mathf.Abs(horizontalInput) > 0.001f;

        bool isRunning = Input.GetKey(KeyCode.LeftShift) && isWalking;

        animator.SetBool("walking", isWalking);

        animator.SetBool("running", isRunning);
        animator.SetBool("grounded", isGrounded);
        if (!isWalking && !isRunning && isGrounded)
            animator.SetBool("idle", true);
        else
            animator.SetBool("idle", false);
        ////change thr player state (delet the above)
        if (!isGrounded)
            currentstate = playerstates.inair;
        else if (isWalking)
            currentstate = playerstates.walkingforward;

        else if (isRunning)
            currentstate = playerstates.running;
        else
            currentstate = playerstates.idle;

    }

    enum playerstates
    {
        idle,
        walkingforward,
        walkingbehind,
        running,
        inair
    }
    ContactFilter2D sd;

    RaycastHit2D[] hit = new RaycastHit2D[3];
    int res;
    public void unground()
    {
        ungroundingtime = Time.time;
        isGrounded = false;

    }
    public float ungrouiidingtime = 0.4f;
    float ungroundingtime;
    void checkGrounded()
    {
        res = Physics2D.Raycast(transform.position, Vector2.down, sd, hit,3);
        if (res >= 1)
        {
                   if (hit[1].transform.gameObject.name == "Grid")
                {
                    if (Time.time - ungroundingtime > ungrouiidingtime || ungroundingtime == 0)
                    {
                        ungroundingtime = 0;

                        isGrounded = true;
                    }
                }
                else
                    isGrounded = false;
            
        }
        else
            isGrounded = false;

    }
  


}





