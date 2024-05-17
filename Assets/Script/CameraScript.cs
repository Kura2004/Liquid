using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;
    public float distance; // �J�����ƃv���C���[�Ԃ̋���
    public float height; // �J�����̍���
    [Header("�J������Z���W�̕␳")]
    [SerializeField] float camera_z;
    public float smoothSpeed; // �J�����̉�]���x
    Vector3 eulerAngles;
    void Update()
    {
        float my = Input.GetAxis("Mouse Y");
        
        // Y�����Ɉ��ʈړ����Ă���Ώc��]
        if (Mathf.Abs(my) > 0.0000001f)
        {
            //�����̐���
            if ((height - my) < -2 || (height - my) > 4)
            {
                //my = 0;
            }
            height -= my / 10;
            move_angle(my);
        }
        
    }

    float save_angle;
    void LateUpdate()
    {

        // �v���C���[�̒��S�ʒu���v�Z
        Vector3 playerCenter = player.transform.position + Vector3.up * height;

        // �v���C���[�̌��Ɉʒu����^�[�Q�b�g�ʒu���v�Z
        Vector3 targetPosition = playerCenter - player.transform.forward * distance;


        // �J�����̈ʒu�����炩�ɍX�V
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        limit_pos();

        // �J�����͏�Ƀv���C���[������
        if (transform.localPosition.y > 0)
        {
            save_angle = 0;
            transform.LookAt(player.transform.position + Vector3.up * camera_z);
        }

        else
        {
            save_angle += Input.GetAxis("Mouse Y");
            transform.LookAt(player.transform.position + Vector3.up * (camera_z + save_angle * 0.1f));
        }

        limit_angle();
    }

    [Header("�J�����̉�]�X�s�[�h(��������)")]
    [SerializeField] float y_speed;
    void move_angle(float my)
    {
        eulerAngles = transform.eulerAngles;
        eulerAngles.x += my * y_speed * Time.deltaTime;

        if (eulerAngles.x > 180f)
        {
            eulerAngles.x -= 360f;
        }

        if (eulerAngles.x < minAngle)
        {
            eulerAngles.x = minAngle;
        }

        if (eulerAngles.x > maxAngle)
        {
            eulerAngles.x = maxAngle;
        }
        transform.eulerAngles = eulerAngles;
        
    }

    void limit_pos()
    {
        Vector3 pos = transform.localPosition;
        pos.y = Mathf.Clamp(pos.y, 0, 0.4f);
        transform.localPosition = pos;
    }

    void limit_angle()
    {
        Vector3 angle = transform.localEulerAngles;

        if (angle.x > 180f)
        {
            angle.x -= 360f;
        }
        // x�������͈̔͐���
        angle.x = Mathf.Clamp(angle.x, minAngle, maxAngle);

        transform.localEulerAngles = angle;
    }
}
