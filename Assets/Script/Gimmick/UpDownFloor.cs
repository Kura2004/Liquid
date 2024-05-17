using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownFloor : MonoBehaviour
{
    const float max_y = 10.0f;
    bool down = false;
    [SerializeField] float change_speed;
    // Start is called before the first frame update
    void Start()
    {
        down = false;
        Vector3 a = transform.localPosition;
        Vector3 random = VectorAlpha.RandomVector3() * 100.0f;
        random.y = Mathf.Clamp(random.y, 0, max_y);
        a.y = random.y;
        transform.localPosition = a;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.localPosition;
        if (a.y <= max_y && !down) 
        {
            a.y += change_speed * Time.deltaTime;
        }

        if (a.y >= max_y)
        {
            down = true;
        }

        if (down)
        {
            a.y -= change_speed * Time.deltaTime;
        }

        if (a.y <= 0)
        {
            down = false;
        }
        transform.localPosition = a;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.transform.Translate()
        }
    }
}
