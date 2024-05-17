using UnityChan;
using UnityEngine;

public class SlipperyFloor : MonoBehaviour
{
    [SerializeField] float slideFriction; // ÉXÉâÉCÉhñÄéCåWêî
    float elapsed_time = 0;
    Vector3 v;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            elapsed_time = 0;
            v =
                PlayerControlScriptWithRgidBody
                .velocity;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.W)||
            Input.GetKey(KeyCode.A)||
            Input.GetKey(KeyCode.S)||
            Input.GetKey(KeyCode.D))
        {
            elapsed_time = 0;
            v =
    PlayerControlScriptWithRgidBody
    .velocity;
        }
        if (other.CompareTag("Player"))
        {

            elapsed_time += Time.deltaTime;
            other.transform.localPosition += v * slideFriction * Mathf.Pow((1.0f - elapsed_time), 3.0f);
            Debug.Log("Slippery");
        }
    }
}

