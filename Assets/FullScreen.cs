using UnityEngine;
public class FullScreen : MonoBehaviour
{
    public bool IfFullScreen; //전역 변수 만들기
    public void Start()
    {
        //초기 설정 값
        if (Screen.fullScreen)
            IfFullScreen = true;
        else
            IfFullScreen = false;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11)) //F11 키를 눌렀을때
        {
            if (IfFullScreen) //IfFullScreen 변수가 감지
            {
                //IfFullScreen 변수가 true 라면 전체화면을 풀고 해상도를 1280 x 720으로 조정하고 변수를 false 로 설정
                IfFullScreen = false;
                Screen.SetResolution(1280, 720, false);
            }

            else
            {
                //ifFullScreen 변수가 false 라면 전체화면을 하고 해상도를 1920 x 1080으로 조정하고 변수를 true로 설정
                IfFullScreen = true;
                Screen.SetResolution(1920, 1080, true);
            }
        }
    }
}
