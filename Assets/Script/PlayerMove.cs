using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public GameManager manager;
    Rigidbody2D rigid;
    float h;
    float v;
    bool isHorizonMove;
    private Animator animator;
    Vector3 dirVec;
    GameObject scanObject;
    AudioSource audiosrc;
    bool ismoving = false;
    //Mobile Key Var
    int up_Value;
    int down_Value;
    int left_Value;
    int right_Value;
    bool up_Down;
    bool down_Down;
    bool left_Down;
    bool right_Down;
    bool up_Up;
    bool down_Up;
    bool left_Up;
    bool right_Up;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        audiosrc = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        //PC
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal")+ right_Value + left_Value;
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical")+ up_Value + down_Value;
        //Mobile
        if (h!=0||v!=0)
        {
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }

        if (ismoving)
        {
            if (!audiosrc.isPlaying)
                audiosrc.Play();
        }
        else
        {
            audiosrc.Stop();
        }
        //pc
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal") || right_Down || left_Down;
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical")|| up_Down || down_Down;
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal") || right_Up || left_Up;
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical") || up_Up || down_Up;
        
        //Mobile
        //bool hDown = manager.isAction ? false : right_Down || left_Down;
        //bool vDown = manager.isAction ? false : up_Down || down_Down;
        //bool hUp = manager.isAction ? false : right_Up || left_Up;
        //bool vUp = manager.isAction ? false : up_Up || down_Up;

        if (hDown || vUp)
        {
            isHorizonMove = true;
        }
            
        else if (vDown || hUp)
        {
            isHorizonMove = false;
        }
            

        //Animation
        if (animator.GetInteger("hAxisRaw") != h)
        {
            animator.SetBool("isChange", true);
            animator.SetInteger("hAxisRaw", (int)h);
        }
        else if (animator.GetInteger("vAxisRaw") != v)
        {
            animator.SetBool("isChange", true);
            animator.SetInteger("vAxisRaw", (int)v);
        }
        else
            animator.SetBool("isChange", false);

        //Derection
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == -1)
            dirVec = Vector3.left;
        else if (hDown && h == 1)
            dirVec = Vector3.right;

        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);

        //Monile Var Init
        up_Down = false;
        down_Down = false;
        left_Down = false;
        right_Down = false;
        up_Up = false;
        down_Up = false;
        left_Up = false;
        right_Up = false;
    }


    void FixedUpdate() {

        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);

        rigid.velocity = moveVec * Speed;

        //����׼�
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;

    }

    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 1;
                up_Down = true;
                break;
            case "D":
                down_Value = -1;
                down_Down = true;
                break;
            case "L":
                left_Value = -1;
                left_Down = true;
                break;
            case "R":
                right_Value = 1;
                right_Down = true;
                break;
            case "A":
                if (scanObject != null)
                    manager.Action(scanObject);
                break;
        }
    }
    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 0;
                up_Up = true;
                break;
            case "D":
                down_Value = 0;
                down_Up = true;
                break;
            case "L":
                left_Value = 0;
                left_Up = true;
                break;
            case "R":
                right_Value = 0;
                right_Up = true;
                break;
        }


    }
}
