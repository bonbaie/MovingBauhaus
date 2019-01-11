using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCircleUp : MonoBehaviour
{

    private GameObject playerobj;
    private GameObject darcirobj;
    private GameObject targetobj;
    private GameObject darktarget;

    private CircleCollider2D colorcol;
    private CircleCollider2D darkcircol;

    private Vector2 savecolrcirpos;
    private int intodarkflag;
    private float darkcountdown = 3;
    private bool intodarkbool;

    private void Start()
    {
        playerobj = GameObject.Find("Player");
        darcirobj = GameObject.Find("DarkCircle");
        targetobj = GameObject.Find("ColorTargetUp");
        darktarget = GameObject.Find("DarkTargetUp");

        colorcol = this.gameObject.GetComponent<CircleCollider2D>();
        darkcircol = darcirobj.GetComponent<CircleCollider2D>();

        intodarkflag = 0;

    }
    private void Update()
    {
        if (intodarkflag == 1)
        {
            this.gameObject.transform.parent = null;
            this.gameObject.transform.position = Vector2.MoveTowards(transform.position, targetobj.transform.position, 1.2f * Time.deltaTime);
            savecolrcirpos = this.gameObject.transform.position;
            darkcountdown -= Time.deltaTime;
        }

        if (darkcountdown <= 0)
        {
            intodarkflag = 2;
            this.gameObject.transform.parent = darcirobj.transform;
            darcirobj.transform.position = Vector2.MoveTowards(darcirobj.transform.position, darktarget.transform.position, 0.8f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DarkCircle")
        {
            intodarkflag = 1;
        }

        else
        {
            //intodarkflag = 0;
        }

        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent = playerobj.transform;
        }
    }
}