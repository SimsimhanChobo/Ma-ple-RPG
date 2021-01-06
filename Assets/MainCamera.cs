using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject 마플캐릭터;
    public static float x = 0f;
    public static float y = 0f;
    public static float z = 0f;
    public static Vector3 target = new Vector3(0, 0, -14 + GameManager.PlayerZ);

    public static bool Game3D = true;
    public bool _Game3D = true;

    public GameObject 벽Camera;

    bool Game3DTemp = false;
    bool Game3DTemp2 = false;

    public static Camera Camera;

    public GameObject MainCameraCanvas;

    public static Vector3 MainCameraPos;

    void Awake() => Camera = GetComponent<Camera>();

    void Start()
    {
        target = MainCameraPos;
        transform.localPosition = target;
        벽Camera.transform.localPosition = target;
    }

    void FixedUpdate() => Move();

    public void Game3DToggle()
    {
        if (Game3D)
            Game3D = false;
        else
            Game3D = true;
    }

    void Update()
    {
        MainCameraPos = transform.position;;

        if (Game3D)
        {
            if (Game3DTemp)
            {
                Camera.farClipPlane = 13.53f;
                Camera.fieldOfView = 61.25f;
            }

            if (!Game3DTemp2)
            {
                Camera.farClipPlane = Mathf.Lerp(Camera.farClipPlane, 14.5f, 0.15f * (60 * Time.unscaledDeltaTime));
                Camera.fieldOfView = Mathf.Lerp(Camera.fieldOfView, 59.5f, 0.15f * (60 * Time.unscaledDeltaTime));
                Camera.main.orthographic = false;
                Game3DTemp = false;
            }

            if (Camera.farClipPlane >= 14.49f)
            {
                Camera.farClipPlane = 100;
                Camera.fieldOfView = 59.5f;
                Game3DTemp2 = true;
            }
        }
        else
        {
            if (Camera.farClipPlane >= 15.99f && !Game3DTemp)
            {
                Camera.farClipPlane = 14.5f;
                Camera.fieldOfView = 59.5f;
            }

            if (!Game3DTemp)
            {
                Camera.farClipPlane = Mathf.Lerp(Camera.farClipPlane, 13.53f, 0.15f * (60 * Time.unscaledDeltaTime));
                Camera.fieldOfView = Mathf.Lerp(Camera.fieldOfView, 61.25f, 0.15f * (60 * Time.unscaledDeltaTime));
                Game3DTemp2 = false;
            }

            if (Camera.farClipPlane <= 13.55f)
            {
                Camera.main.orthographic = true;
                Camera.farClipPlane = 100;
                Camera.fieldOfView = 59.5f;
                Game3DTemp = true;
            }

            Game3DTemp2 = false;
        }
        //Camera.farClipPlane = Mathf.Lerp(Camera.farClipPlane, 13.79887f, 0.05f);

        _Game3D = Game3D;

        Camera.orthographicSize = Mathf.Abs(transform.localPosition.z / 14 * -8);
    }

    void Move()
    {
        if (GameManager.CameraX고정)
            MainCameraCanvas.SetActive(true);
        else
            MainCameraCanvas.SetActive(false);

        if ((GameManager.Graphic == 0 && GameManager.CameraAni == 0) || GameManager.CameraAni == 1)
        {
            // 카메라 이동과 고정
            x = transform.localPosition.x;
            y = transform.localPosition.y;
            z = transform.localPosition.z;

            Vector3 velo = Vector3.zero;
            if (GameManager.CameraX고정)
            {
                if (!GameManager.CameraY고정)
                {
                    target = new Vector3(transform.localPosition.x, 마플캐릭터.transform.position.y, -14 + GameManager.PlayerZ);
                    카메라고정();
                    transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.075f * (35 * Time.deltaTime));
                    target = new Vector3(transform.localPosition.x, GameManager.PlayerY, -14 + GameManager.PlayerZ);
                    카메라고정();
                    벽Camera.transform.localPosition = target;
                }
            }

            if (GameManager.CameraY고정)
            {
                if (!GameManager.CameraX고정)
                {
                    target = new Vector3(마플캐릭터.transform.position.x, transform.localPosition.y, -14 + GameManager.PlayerZ);
                    카메라고정();
                    transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.075f * (35 * Time.deltaTime));
                    target = new Vector3(GameManager.PlayerX, transform.localPosition.y, -14 + GameManager.PlayerZ);
                    카메라고정();
                    벽Camera.transform.localPosition = target;
                }
            }

            if (GameManager.CameraX고정)
            {
                if (GameManager.CameraY고정)
                {
                    target = new Vector3(transform.localPosition.x, transform.localPosition.y, -14 + GameManager.PlayerZ);
                    카메라고정();
                    transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.075f * (35 * Time.deltaTime));
                    벽Camera.transform.localPosition = target;
                }
            }

            if (!GameManager.CameraX고정)
            {
                if (!GameManager.CameraY고정)
                {
                    target = new Vector3(마플캐릭터.transform.position.x, 마플캐릭터.transform.position.y, -14 + GameManager.PlayerZ);
                    카메라고정();
                    transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.075f * (35 * Time.deltaTime));
                    target = new Vector3(GameManager.PlayerX, GameManager.PlayerY, -14 + GameManager.PlayerZ);
                    카메라고정();
                    벽Camera.transform.localPosition = target;
                }
            }

            if (GameManager.MainMenu)
            {
                target = new Vector3(0, -0.5f, -14 + GameManager.PlayerZ);
                transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.075f * (35 * Time.deltaTime));
                벽Camera.transform.localPosition = target;
            }

            Quaternion target2 = Quaternion.Euler(0, 0, 0);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, target2, 0.075f * (80 * Time.deltaTime));
        }
        else
        {
            target = new Vector3(마플캐릭터.transform.position.x, 마플캐릭터.transform.position.y, -14 + GameManager.PlayerZ);
            카메라고정();

            if (GameManager.MainMenu)
                target = new Vector3(0, -0.5f, -14 + GameManager.PlayerZ);

            transform.localPosition = target;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            벽Camera.transform.localPosition = target;
        }
    }

    public void 카메라고정()
    {
        //카메라 고정
        if (GameManager.MainMenu == false)
        {
            if (GameManager.Map == 0)
            {
                if (GameManager.CameraX고정 == false)
                {
                    if (마플캐릭터.transform.position.x <= -0.69)
                    {
                        MainCameraCanvas.SetActive(true);

                        if (GameManager.CameraY고정)
                            target = new Vector3(-0.69f, transform.localPosition.y, -14 + GameManager.PlayerZ);
                        else
                            target = new Vector3(-0.69f, 마플캐릭터.transform.position.y, -14 + GameManager.PlayerZ);
                    }
                }

                if (마플캐릭터.transform.position.y < -8 && 마플캐릭터.transform.position.y < -22)
                    target = new Vector3(target.x, -25, -14 + GameManager.PlayerZ);
                else if (마플캐릭터.transform.position.y > -22 && 마플캐릭터.transform.position.y < -8)
                    target = new Vector3(target.x, -15, -14 + GameManager.PlayerZ);
                else
                    target = new Vector3(target.x, -0.5f, -14 + GameManager.PlayerZ);
            }
        }
    }
}
