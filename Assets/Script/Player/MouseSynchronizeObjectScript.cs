using UnityEngine;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;

public class MouseSynchronizeObjectScript : MonoBehaviour
{
    // �ʒu���W
    private Vector3 position;
    // �X�N���[�����W�����[���h���W�ɕϊ������ʒu���W
    private Vector3 screenToWorldPointPosition;
    // Use this for initialization
    [SerializeField] RectTransform lock_on_image;
    [SerializeField] float pos_z;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //// Vector3�Ń}�E�X�ʒu���W���擾����
        //position = Input.mousePosition;
        //// Z���C��
        //position.z = 20f;
        //// �}�E�X�ʒu���W���X�N���[�����W���烏�[���h���W�ɕϊ�����
        //screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);

        //// ���[���h���W�ɕϊ����ꂽ�}�E�X���W����
        

        position = lock_on_image.position;
        // Z���C��
        position.z = pos_z;
        // ������
        position.y -= 20.0f;

        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);

        gameObject.transform.position = screenToWorldPointPosition;
    }
}