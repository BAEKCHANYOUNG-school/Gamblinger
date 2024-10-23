using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [SerializeField] private int cameraIndex; // �� ������Ʈ�� �Ҵ�� ī�޶� �ε���

    private CameraSwitcher cameraSwitcher;

    private void Start()
    {
        // CameraSwitcher ��ũ��Ʈ�� ã��
        cameraSwitcher = FindObjectOfType<CameraSwitcher>();
    }

    private void OnMouseDown() // ���콺 Ŭ�� �� ȣ��Ǵ� �޼���
    {
        cameraSwitcher.SwitchToCamera(cameraIndex);
    }
}
