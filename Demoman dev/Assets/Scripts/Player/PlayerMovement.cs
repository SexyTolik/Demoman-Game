using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject PlGraph;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Move(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0));
            PlGraph.transform.rotation = new Quaternion(0, 0, Input.GetAxis("Horizontal") > 0 ? (0) : (180), 0);
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            Move(new Vector3(0, Input.GetAxis("Vertical") * Time.deltaTime));
            PlGraph.transform.rotation = new Quaternion(0, 0, Input.GetAxis("Vertical") > 0 ? (90) : (-90), 90); // вообще можно было бы просто умножить ось на 90, но с тернарным оператором код выглядит покрасивше
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    private void Move(Vector2 dir)
    {
        transform.position += new Vector3(dir.x,dir.y);
        anim.SetBool("Walk", true);
    }

}
