using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCircle : MonoBehaviour {

    private bool intoacolorcir;
    private int mousedowncont;
    private float startTime;
    private float playerspeed;
    private float translatespeed;
    private float escapecolorcirtime = 5;
    private float Colorsetposx;
    private float Colorsetposy;

    private GameObject playerobj;
    private GameObject darlcircleobj;
    private GameObject Ccobj;
    private GameObject CcTarget;
    private GameObject DarkupTarget1;
    private Vector2 Savenowspeed;
    private Rigidbody2D playerrb;
    private CircleCollider2D colorcir;

    private PlayerJamped playercont;

    [SerializeField, Range(0, 10)]
    float time = 1;

    [SerializeField]
    Vector2 endPosition;

    private void OnEnable()
    {
        startTime = Time.timeSinceLevelLoad;
    }

    private void Start()
    {
        intoacolorcir = false;
        playerobj = GameObject.Find("Player");
        darlcircleobj = GameObject.Find("DarkCircle");
        Ccobj = GameObject.Find("CCobj");
        CcTarget = GameObject.Find("ColorTarget");
        DarkupTarget1 = GameObject.Find("Darkup1");
        playerrb = playerobj.GetComponent<Rigidbody2D>();
        colorcir = this.gameObject.GetComponent<CircleCollider2D>();
        Colorsetposx = this.gameObject.transform.position.x;
        Colorsetposy = this.gameObject.transform.position.y;

    }
    private void Update()
    {
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Savenowspeed = playerrb.velocity;
            this.gameObject.transform.parent = playerobj.transform;
            Savenowspeed = playerrb.velocity;
            escapecolorcirtime -= 0.5f;
            intoacolorcir = true;
        }

        else
        {
            intoacolorcir = false;
        }

        if(collision.gameObject.tag == "DarkCircle")
        {
            intoacolorcir = true;
            this.gameObject.transform.parent = null;
            this.gameObject.transform.position = Vector2.Lerp(transform.position, CcTarget.transform.position, 100.0f);
            darlcircleobj.transform.parent = this.gameObject.transform;
            darlcircleobj.transform.position = Vector2.Lerp(darlcircleobj.transform.position, DarkupTarget1.transform.position, 100.0f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            colorcir.enabled = true;
        }


    }
}
