 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//快速注释 ctrlK+ctrlC，解除注释ctrlK+ctrlU
/// <summary>
/// 角色各种动作逻辑
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    #region variables
    Rigidbody2D playerRigidbody2D;
    public Collider2D hitBox;
    public Animator anim;
    public GameObject NormalWeapon;
    public GameObject SpiritWeapon;
    public GameObject NormalBackground;
    public GameObject SpiritBackground;
    public RuntimeAnimatorController NormalAnim;
    public RuntimeAnimatorController SpiritAnim;
    private bool doubleJump = false;
    public float jumpVelocity;
    public float fallMultiplier = 2.2f;
    [Header("current speed on X axis")]
    public float speedX;
    [Header("current speed on Y axis")]
    public float speedY;
    [Header("current direction on X axis")]
    public float horizontalDirection;//between -1~1

    //[Header("force put on player on X axis")]
    //public float ForceX;
    //[Header("force put on player on Y axis")]
    //public float ForceY;
    /// <summary>
    /// dash movement variables
    /// </summary>
    [Header("Dash variables")]
    public bool airDashed = false;
    public bool isDashing = false;
    private float DashTime = 0;
    public float StartDashTime;
    public float DashSpeed;
    #endregion
    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }

    public bool DashKey
    {
        get
        {
            return Input.GetMouseButtonDown(1);
        }
    }

    void TryDash()
    {
        if (isGround && airDashed)
        {
            airDashed = false;
        }
        if (DashKey && !isDashing && !airDashed)
        {
            Dash();
        }
    }
    /// <summary>
    /// change velocity of rigidbody to jump
    /// </summary>
    void TryJump()
    {
        if (Time.timeScale!=0 && controllable)
        {
            if (isGround && JumpKey)
            {
                //playerRigidbody2D.AddForce(Vector2.up * ForceY);
                playerRigidbody2D.velocity = Vector2.up * jumpVelocity * Time.deltaTime * 55 * 1 / Time.timeScale;
                doubleJump = true;
            }
            if (!isGround && JumpKey && doubleJump)
            {
                Instantiate(dashEFX, transform.position, Quaternion.identity);

                playerRigidbody2D.velocity = Vector2.up * (jumpVelocity - 0.5f) * Time.deltaTime * 55 * 1 / Time.timeScale;
                doubleJump = false;
            }

            if (playerRigidbody2D.velocity.y < 0)   //falling
            {
                playerRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime * 1 / Time.timeScale;
            }
        }
    }

    [Header("max speed on X axis")]
    public float maxSpeedX;

    public void ControlSpeed()
    {
        speedX = playerRigidbody2D.velocity.x;
        speedY = playerRigidbody2D.velocity.y;
        if (!isDashing)
        {
            float newSpeedY = Mathf.Clamp(speedY, -15, 50);
            playerRigidbody2D.velocity = new Vector2(speedX, newSpeedY);
        }
    }

    [Header("distance from the ground")]
    [Range(0, 0.5f)]
    public float distance;
    [Header("start point of the ray")]
    public Transform groundCheck;
    [Header("ground mask")]
    public LayerMask groundLayer;
    public bool grounded;
    //shoot a really short ray from the bottom of the player, if the ray hits the ground, then the player is on the ground.
    bool isGround
    {
        get
        {
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);
            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);
            return grounded;
        }
    }
    public Transform wallCheck;
    public bool HitWall;
    public float distanceToWall;
    public LayerMask wallLayer;
    bool isWall
    {
        get
        {
            Vector2 start = wallCheck.position;
            Vector2 end;
            switch (horizontalDirection)
            {
                case 1:
                    end = new Vector2(start.x + distanceToWall, start.y);
                    break;
                case -1:
                    end = new Vector2(start.x - distanceToWall, start.y);
                    break;
                default:
                    end = new Vector2(start.x - distanceToWall, start.y);
                    break;
            }
            Debug.DrawLine(start, end, Color.blue);
            HitWall = Physics2D.Linecast(start, end, wallLayer);
            return HitWall;

        }
    }

    void Start()
    {

        playerRigidbody2D = GetComponent<Rigidbody2D>();
        DashTime = StartDashTime;
        controllable = true;
    }
    /// <summary>
    /// 主角在X轴上移动
    /// </summary>
    public Vector3 LeftDirection;
    public Vector3 RightDirection;
    public Vector3 currentSpeed;
    void MovementX()
    {
        LeftDirection = new Vector3(0, -180, 0);
        RightDirection = new Vector3(0, 0, 0);
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        //playerRigidbody2D.AddForce(new Vector2(ForceX * horizontalDirection, 0));//（惯性移动）
        if (Time.timeScale != 0 && controllable)

        {
            if (horizontalDirection != 0)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
            if (!isDashing)
            {
                if (horizontalDirection < 0)
                {
                    playerRigidbody2D.transform.eulerAngles = LeftDirection;
                }
                else if (horizontalDirection > 0)
                {
                    playerRigidbody2D.transform.eulerAngles = RightDirection;
                }

                currentSpeed = new Vector3(20 * horizontalDirection, playerRigidbody2D.velocity.y, 0);
            }
            if (!isWall)
            {
                transform.position += currentSpeed * Time.deltaTime * (1 / Time.timeScale);
            }
            else
            {
                transform.position += new Vector3(0, currentSpeed.y, 0) * Time.deltaTime * (1 / Time.timeScale);
            }
        }

    }
    public GameObject GameOver;
    public bool controllable = true;
    public void die()
    {
        Time.timeScale = 0;
        GameOver.SetActive(true);
        CursorVis.SetActive(true);
        //Destroy(gameObject);
    }

    public void InvincibleOn()
    {
        hitBox.enabled = false;
    }

    public void InvincibleOff()
    {
        hitBox.enabled = true;
    }

    //public void Dazed(float dir)
    //{
    //    if (dir > transform.position.x)
    //    {
    //        playerRigidbody2D.velocity = new Vector2(-10.0f, 7.5f);
    //    }
    //    else
    //    {
    //        playerRigidbody2D.velocity = new Vector2(10.0f, 7.5f);
    //    }
    //}
   

    void SpiritShift()
    {
        if (Random.Range(0,100)>99)
        FindObjectOfType<AudioManager>().Play("TheWorld");
        else
        FindObjectOfType<AudioManager>().Play("SpiritShift");

        Time.timeScale = .2f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Physics2D.gravity = new Vector2(0, -110);
        fallMultiplier = 2f;
        StartDashTime = 0.04f;
        NormalWeapon.SetActive(false);
        SpiritWeapon.SetActive(true);
        SpiritBackground.SetActive(true);
        NormalBackground.SetActive(false);
        anim.runtimeAnimatorController = SpiritAnim as RuntimeAnimatorController;
        anim.SetTrigger("SpiritShiftEnd");
        
    }
    public Collider2D AttackArea1;
    public Collider2D AttackArea2;
    void SpiritShiftEnd()
    {
        AttackArea1.enabled = false;
        AttackArea2.enabled = false;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Physics2D.gravity = new Vector2(0, -30);
        fallMultiplier = 2.2f;
        StartDashTime = 0.2f;
        NormalWeapon.SetActive(true);
        SpiritWeapon.SetActive(false);
        NormalBackground.SetActive(true);
        SpiritBackground.SetActive(false);
        anim.runtimeAnimatorController = NormalAnim as RuntimeAnimatorController;

    }

    public GameObject PauseMenu;
    public GameObject CursorVis;
    private bool paused = false;
    public GameObject dashEFX;
    void Dash()
    {
        if (Time.timeScale != 0 && controllable)
        {
            FindObjectOfType<AudioManager>().Play("Dash");

            Instantiate(dashEFX, transform.position, Quaternion.identity);
            DashTime = StartDashTime;
            if (!isGround)
            {
                playerRigidbody2D.gravityScale = 0;
                GetComponent<Animator>().SetTrigger("Dash");
                airDashed = true;
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Dash");
            }
            isDashing = true;
        }
    }
    void RootMotionOn() 
    {
        anim.applyRootMotion = true;
        }
    void RootMotionOff() 
    {
        anim.applyRootMotion = false;
      }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    Time.timeScale = .2f;
        //    Time.fixedDeltaTime = 0.02f * Time.timeScale;
        //    Physics2D.gravity = new Vector2(0,-110);
        //    fallMultiplier = 2f;
        //    StartDashTime = 0.04f;
        //    NormalWeapon.SetActive(false);
        //    SpiritWeapon.SetActive(true);
        //    anim.runtimeAnimatorController = SpiritAnim as RuntimeAnimatorController;
        //    anim.SetTrigger("SpiritShiftEnd");

        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    Time.timeScale = 1;
        //    Time.fixedDeltaTime = 0.02f * Time.timeScale;
        //    Physics2D.gravity = new Vector2(0, -30);
        //    fallMultiplier = 2.2f;
        //    StartDashTime = 0.2f;
        //    NormalWeapon.SetActive(true);
        //    SpiritWeapon.SetActive(false);
        //    anim.runtimeAnimatorController = NormalAnim as RuntimeAnimatorController;
        //    InvincibleOff();
        //}

        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Time.timeScale = 0;
            Physics2D.gravity = new Vector2(0, -30);
            fallMultiplier = 2.2f;
            StartDashTime = 0.2f;
            InvincibleOff();
            NormalWeapon.SetActive(true);
            SpiritWeapon.SetActive(false);
            NormalBackground.SetActive(true);
            SpiritBackground.SetActive(false);
            anim.runtimeAnimatorController = NormalAnim as RuntimeAnimatorController;
            PauseMenu.SetActive(true);
            CursorVis.SetActive(true);
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            FindObjectOfType<AudioManager>().Play("Click");
            PauseMenu.SetActive(false);
            CursorVis.SetActive(false);
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            paused = false;
        }

        if (isGround && Input.GetAxisRaw("Horizontal") != 0)
        {
            FindObjectOfType<AudioManager>().UnMute("PlayerRun");
        }
        else
        {
            FindObjectOfType<AudioManager>().Mute("PlayerRun");
        }

        TryJump();
        TryDash();

        if (isDashing && DashTime > 0)
        {
            horizontalDirection = Input.GetAxisRaw("Horizontal");
            DashTime -= Time.deltaTime;

            currentSpeed.x = DashSpeed * horizontalDirection;
            currentSpeed.y = 0;

        }
        else if (DashTime <= 0)
        {
            isDashing = false;
            playerRigidbody2D.gravityScale = 1;
        }
    }

    void FixedUpdate()
    {
        //FindObjectOfType<AudioManager>().Play("");
        ControlSpeed();
        MovementX();
    }

}
