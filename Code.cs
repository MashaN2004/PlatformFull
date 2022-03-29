using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Code : MonoBehaviour
{
    Transform tr;
    float horizontalSpeed = 2.0f;
    CharacterController contr;
    float speed = 6f;
    float gravity = -9.81f;
    float jump = 2f;
    bool isGrounded = false;
    public static float kol = 0;
    [SerializeField] TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();//сохранили эл транв
        contr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horz = horizontalSpeed * Input.GetAxis("Mouse X");
        float vert = Input.GetAxis("Vertical");
        contr.Move(tr.forward * vert * speed * Time.deltaTime);
        contr.Move(tr.up * gravity * Time.deltaTime);
        tr.Rotate(0, horz, 0);
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            contr.Move(tr.up * jump);

        }
        isGrounded = false;

    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "gem")
        {
            kol = kol + 0.5f;
            Destroy(col.gameObject);
            score.text = kol + "";
        }
    }
}
