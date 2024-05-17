using UnityEngine;

public class WaterWheel : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float rotation_time;
    float now_speed;
    float elapsed_time = 0;
    [SerializeField] Transform arm;
    float save_angle = 0;
    float direction = 1;
    [SerializeField] float limit_arm;
    [SerializeField] float limit_arm_1;
    bool arm_1 = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Beam")
        {
            elapsed_time = rotation_time;
            RotateWheel();
        }
    }

    private void FixedUpdate()
    {
        RotateWheel();
    }

    private void RotateWheel()
    {
        // …ŽÔ‚ð‰ñ“]‚³‚¹‚é
        elapsed_time -= Time.fixedDeltaTime;

        if (elapsed_time > 0)
            now_speed = Mathf.Pow(elapsed_time , 3.0f);

        else
        {
            now_speed = 0;
        }
        transform.Rotate(Vector3.up * now_speed * rotationSpeed);

        save_angle += now_speed * rotationSpeed * 0.1f;
        if (save_angle > limit_arm)
        {
            save_angle = 0;
            direction *= -1;
            arm_1 = !arm_1;
        }
        if(save_angle > limit_arm_1 && arm_1)
        {
            save_angle = 0;
            direction *= -1;
        }

        arm.Rotate(Vector3.down * now_speed * rotationSpeed * 0.1f * direction);

        Debug.Log("hitWaterWheel");
    }
}

