using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [SerializeField] private int cameraIndex; // 이 오브젝트에 할당된 카메라 인덱스

    private CameraSwitcher cameraSwitcher;

    private void Start()
    {
        // CameraSwitcher 스크립트를 찾기
        cameraSwitcher = FindObjectOfType<CameraSwitcher>();
    }

    private void OnMouseDown() // 마우스 클릭 시 호출되는 메서드
    {
        cameraSwitcher.SwitchToCamera(cameraIndex);
    }
}
