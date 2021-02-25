using UnityEngine;

public class SkinRotation : MonoBehaviour
{
    public static GameObject PlayerObject;

    /// <summary>
    /// Rotate the player skin.
    /// 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    public static void skinRotation(string RotationType, Vector3 Rotation) => skinRotation2(PlayerObject, RotationType, Rotation, false, 0.175f);

    /// <summary>
    /// Rotate the player skin.
    /// 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    public static void skinRotation(string RotationType, Vector3 Rotation, bool SetRotation) => skinRotation2(PlayerObject, RotationType, Rotation, SetRotation, 0.175f);

    /// <summary>
    /// Rotate the player skin.
    /// 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    /// <param name="Time">
    /// Rotation time
    /// 이동 시간
    /// </param>
    public static void skinRotation(string RotationType, Vector3 Rotation, bool SetRotation, float Time) => skinRotation2(PlayerObject, RotationType, Rotation, SetRotation, Time);

    /// <summary>
    /// Rotate the skin.
    /// 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    public static void skinRotation(GameObject RotationObject, string RotationType, Vector3 Rotation) => skinRotation2(RotationObject, RotationType, Rotation, false, 0.175f);

    /// <summary>
    /// Rotate the skin.
    /// 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    public static void skinRotation(GameObject RotationObject, string RotationType, Vector3 Rotation, bool SetRotation) => skinRotation2(RotationObject, RotationType, Rotation, SetRotation, 0.175f);

    /// <summary>
    /// Rotate the skin.
    /// 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    /// <param name="Time">
    /// Rotation time
    /// 이동 시간
    /// </param>
    public static void skinRotation(GameObject RotationObject, string RotationType, Vector3 Rotation, bool SetRotation, float Time) => skinRotation2(RotationObject, RotationType, Rotation, SetRotation, Time);

    static void skinRotation2(GameObject RotationObject, string RotationType, Vector3 Rotation, bool SetRotation, float time)
    {
        if (RotationType == "All")
        {
            if (!SetRotation)
                RotationObject.transform.localRotation = Quaternion.Lerp(RotationObject.transform.localRotation, Quaternion.Euler(Rotation), time * (60 * Time.deltaTime));
            else
                RotationObject.transform.localEulerAngles = Rotation;

            return;
        }

        Transform[] allChildren = RotationObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
            if (allChildren[i].name == RotationType)
                if (!SetRotation)
                    allChildren[i].transform.localRotation = Quaternion.Lerp(allChildren[i].transform.localRotation, Quaternion.Euler(Rotation), time * (60 * Time.deltaTime));
                else
                    allChildren[i].transform.localEulerAngles = Rotation;
    }

    /// <summary>
    /// Rotate the player skin.
    /// 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    public static void skinRotation(string RotationType, Quaternion Rotation) => skinRotation3(PlayerObject, RotationType, Rotation, false, 0.175f);

    /// <summary>
    /// Rotate the player skin.
    /// 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    public static void skinRotation(string RotationType, Quaternion Rotation, bool SetRotation) => skinRotation3(PlayerObject, RotationType, Rotation, SetRotation, 0.175f);

    /// <summary>
    /// Rotate the player skin.
    /// 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    /// <param name="Time">
    /// Rotation time
    /// 이동 시간
    /// </param>
    public static void skinRotation(string RotationType, Quaternion Rotation, bool SetRotation, float Time) => skinRotation3(PlayerObject, RotationType, Rotation, SetRotation, Time);

    /// <summary>
    /// Rotate the skin.
    /// 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    public static void skinRotation(GameObject RotationObject, string RotationType, Quaternion Rotation) => skinRotation3(RotationObject, RotationType, Rotation, false, 0.175f);

    /// <summary>
    /// Rotate the skin.
    /// 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    public static void skinRotation(GameObject RotationObject, string RotationType, Quaternion Rotation, bool SetRotation) => skinRotation3(RotationObject, RotationType, Rotation, SetRotation, 0.175f);

    /// <summary>
    /// Rotate the skin.
    /// 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="Rotation">
    /// Rotation value
    /// 회전 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    /// <param name="Time">
    /// Rotation time
    /// 이동 시간
    /// </param>
    public static void skinRotation(GameObject RotationObject, string RotationType, Quaternion Rotation, bool SetRotation, float Time) => skinRotation3(RotationObject, RotationType, Rotation, SetRotation, Time);

    static void skinRotation3(GameObject RotationObject, string RotationType, Quaternion Rotation, bool SetRotation, float time)
    {
        if (RotationType == "All")
        {
            if (!SetRotation)
                RotationObject.transform.localRotation = Quaternion.Lerp(RotationObject.transform.localRotation, Rotation, time * (60 * Time.deltaTime));
            else
                RotationObject.transform.localRotation = Rotation;

            return;
        }

        Transform[] allChildren = RotationObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
            if (allChildren[i].name == RotationType)
                if (!SetRotation)
                    allChildren[i].transform.localRotation = Quaternion.Lerp(allChildren[i].transform.localRotation, Rotation, time * (60 * Time.deltaTime));
                else
                    allChildren[i].transform.localRotation = Rotation;
    }

    /// <summary>
    /// Rotate the player skin based on the object to look.
    /// 스킨을 바라볼 오브젝트를 기준으로 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="LookAtObject">
    /// Object to look at
    /// 바라볼 오브젝트
    /// </param>
    public static void skinLookAt(GameObject LookAtObject, string RotationType) => skinLookAt2(PlayerObject, LookAtObject, RotationType, false, 0.175f);

    /// <summary>
    /// Rotate the player skin based on the object to look.
    /// 스킨을 바라볼 오브젝트를 기준으로 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="LookAtObject">
    /// Object to look at
    /// 바라볼 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    public static void skinLookAt(GameObject LookAtObject, string RotationType, bool SetRotation) => skinLookAt2(PlayerObject, LookAtObject, RotationType, SetRotation, 0.175f);

    /// <summary>
    /// Rotate the player skin based on the object to look.
    /// 스킨을 바라볼 오브젝트를 기준으로 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="LookAtObject">
    /// Object to look at
    /// 바라볼 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    /// <param name="Time">
    /// Rotation time
    /// 이동 시간
    /// </param>
    public static void skinLookAt(GameObject LookAtObject, string RotationType, bool SetRotation, float Time) => skinLookAt2(PlayerObject, LookAtObject, RotationType, SetRotation, Time);

    /// <summary>
    /// Rotate the skin based on the object to look.
    /// 바라볼 오브젝트를 기준으로 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="LookAtObject">
    /// Object to look at
    /// 바라볼 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    public static void skinLookAt(GameObject RotationObject, string RotationType, GameObject LookAtObject) => skinLookAt2(RotationObject, LookAtObject, RotationType, false, 0.175f);

    /// <summary>
    /// Rotate the skin based on the object to look.
    /// 바라볼 오브젝트를 기준으로 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="LookAtObject">
    /// Object to look at
    /// 바라볼 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    public static void skinLookAt(GameObject RotationObject, GameObject LookAtObject, string RotationType, bool SetRotation) => skinLookAt2(RotationObject, LookAtObject, RotationType, SetRotation, 0.175f);

    /// <summary>
    /// Rotate the skin based on the object to look.
    /// 바라볼 오브젝트를 기준으로 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="LookAtObject">
    /// Object to look at
    /// 바라볼 오브젝트
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    /// <param name="Time">
    /// Rotation time
    /// 이동 시간
    /// </param>
    public static void skinLookAt(GameObject RotationObject, GameObject LookAtObject, string RotationType, bool SetRotation, float Time) => skinLookAt2(RotationObject, LookAtObject, RotationType, SetRotation, Time);

    static void skinLookAt2(GameObject RotationObject, GameObject LookAtObject, string RotationType, bool SetRotation, float time)
    {
        if (RotationType == "All")
        {
            Transform[] allChildren2 = LookAtObject.GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren2.Length; i++)
                if (allChildren2[i].name == "Minecraft Player Skin" || allChildren2[i].name == "Minecraft Sign Texture")
                {
                    Vector3 vector3 = allChildren2[i].transform.position;
                    vector3.y = -vector3.y;

                    if (!SetRotation)
                    {
                        RotationObject.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(RotationObject.transform.localEulerAngles.x, RotationObject.transform.localEulerAngles.y - 180, RotationObject.transform.localEulerAngles.z), Quaternion.LookRotation(vector3 - RotationObject.transform.position), time);
                        RotationObject.transform.localEulerAngles = new Vector3(RotationObject.transform.localEulerAngles.x, RotationObject.transform.localEulerAngles.y - 180, RotationObject.transform.localEulerAngles.z);
                    }
                    else
                    {
                        RotationObject.transform.localRotation = Quaternion.LookRotation(vector3 - RotationObject.transform.position);
                        RotationObject.transform.localEulerAngles = new Vector3(RotationObject.transform.localEulerAngles.x, RotationObject.transform.localEulerAngles.y - 180, RotationObject.transform.localEulerAngles.z);
                    }
                }

            return;
        }

        Transform[] allChildren = RotationObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
            if (RotationType == allChildren[i].name)
            {
                Transform[] allChildren2 = LookAtObject.GetComponentsInChildren<Transform>();
                for (i = 0; i < allChildren2.Length; i++)
                    if (allChildren2[i].name == "Minecraft Player Skin" || allChildren2[i].name == "Minecraft Sign Texture")
                    {
                        Vector3 vector3 = allChildren2[i].transform.localPosition;
                        vector3.y = -vector3.y;

                        if (!SetRotation)
                        {
                            allChildren[i].localRotation = Quaternion.Lerp(Quaternion.Euler(allChildren[i].localEulerAngles.x, allChildren[i].localEulerAngles.y - 180, RotationObject.transform.localEulerAngles.z), Quaternion.LookRotation(vector3 - allChildren[i].position), time);
                            allChildren[i].localEulerAngles = new Vector3(allChildren[i].localEulerAngles.x, allChildren[i].localEulerAngles.y - 180, allChildren[i].localEulerAngles.z);
                        }
                        else
                        {
                            allChildren[i].localRotation = Quaternion.LookRotation(vector3 - allChildren[i].position);
                            allChildren[i].localEulerAngles = new Vector3(allChildren[i].localEulerAngles.x, allChildren[i].localEulerAngles.y - 180, allChildren[i].localEulerAngles.z);
                        }
                    }
            }
    }

    /// <summary>
    /// Rotate the player skin based on the position to look.
    /// 스킨을 바라볼 오브젝트를 기준으로 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="LookAtPosition">
    /// Position to look at
    /// 바라볼 좌표
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    public static void skinLookAt(Vector3 LookAtPosition, string RotationType) => skinLookAt3(PlayerObject, LookAtPosition, RotationType, false, 0.175f);

    /// <summary>
    /// Rotate the player skin based on the position to look.
    /// 스킨을 바라볼 오브젝트를 기준으로 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="LookAtPosition">
    /// Position to look at
    /// 바라볼 좌표
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    public static void skinLookAt(Vector3 LookAtPosition, string RotationType, bool SetRotation) => skinLookAt3(PlayerObject, LookAtPosition, RotationType, SetRotation, 0.175f);

    /// <summary>
    /// Rotate the player skin based on the position to look.
    /// 스킨을 바라볼 오브젝트를 기준으로 플레이어 스킨을 회전 합니다.
    /// </summary>
    /// <param name="LookAtPosition">
    /// Position to look at
    /// 바라볼 좌표
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    /// <param name="Time">
    /// Rotation time
    /// 이동 시간
    /// </param>
    public static void skinLookAt(Vector3 LookAtPosition, string RotationType, bool SetRotation, float Time) => skinLookAt3(PlayerObject, LookAtPosition, RotationType, SetRotation, Time);

    /// <summary>
    /// Rotate the skin based on the object to look.
    /// 바라볼 좌표를 기준으로 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="LookAtPosition">
    /// Position to look at
    /// 바라볼 좌표
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    public static void skinLookAt(GameObject RotationObject, Vector3 LookAtPosition, string RotationType) => skinLookAt3(RotationObject, LookAtPosition, RotationType, false, 0.175f);

    /// <summary>
    /// Rotate the skin based on the object to look.
    /// 바라볼 좌표를 기준으로 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="LookAtPosition">
    /// Position to look at
    /// 바라볼 좌표
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    public static void skinLookAt(GameObject RotationObject, Vector3 LookAtPosition, string RotationType, bool SetRotation) => skinLookAt3(RotationObject, LookAtPosition, RotationType, SetRotation, 0.175f);

    /// <summary>
    /// Rotate the skin based on the object to look.
    /// 바라볼 좌표를 기준으로 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 회전 할 오브젝트
    /// </param>
    /// <param name="LookAtPosition">
    /// Position to look at
    /// 바라볼 좌표
    /// </param>
    /// <param name="RotationType">
    /// Part to be rotated
    /// 회전 할 부분
    /// (All, Head, Body, Left Arm, Right Arm, Left Leg, Right Leg)
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to rotate smoothly or right away
    /// 부드럽게 또는 즉시 회전할지 결정
    /// </param>
    /// <param name="Time">
    /// Rotation time
    /// 이동 시간
    /// </param>
    public static void skinLookAt(GameObject RotationObject, Vector3 LookAtPosition, string RotationType, bool SetRotation, float Time) => skinLookAt3(RotationObject, LookAtPosition, RotationType, SetRotation, Time);

    static void skinLookAt3(GameObject RotationObject, Vector3 LookAtPosition, string RotationType, bool SetRotation, float time)
    {
        LookAtPosition.y = -LookAtPosition.y;

        if (RotationType == "All")
        {
            if (!SetRotation)
            {
                RotationObject.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(RotationObject.transform.localEulerAngles.x, RotationObject.transform.localEulerAngles.y - 180, RotationObject.transform.localEulerAngles.z), Quaternion.LookRotation(LookAtPosition - RotationObject.transform.position), time);
                RotationObject.transform.localEulerAngles = new Vector3(RotationObject.transform.localEulerAngles.x, RotationObject.transform.localEulerAngles.y - 180, RotationObject.transform.localEulerAngles.z);
            }
            else
            {
                RotationObject.transform.localRotation = Quaternion.LookRotation(LookAtPosition - RotationObject.transform.position);
                RotationObject.transform.localEulerAngles = new Vector3(RotationObject.transform.localEulerAngles.x, RotationObject.transform.localEulerAngles.y - 180, RotationObject.transform.localEulerAngles.z);
            }

            return;
        }

        Transform[] allChildren = RotationObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
            if (allChildren[i].name == RotationType)
            {
                if (!SetRotation)
                {
                    allChildren[i].localRotation = Quaternion.Lerp(Quaternion.Euler(allChildren[i].localEulerAngles.x - 180, allChildren[i].localEulerAngles.y - 180, allChildren[i].localEulerAngles.z), Quaternion.LookRotation(LookAtPosition - allChildren[i].position), time);
                    RotationObject.transform.localEulerAngles = new Vector3(allChildren[i].localEulerAngles.x, allChildren[i].localEulerAngles.y - 180, allChildren[i].localEulerAngles.z);
                }
                else
                {
                    allChildren[i].localRotation = Quaternion.LookRotation(LookAtPosition - allChildren[i].position);
                    allChildren[i].localEulerAngles = new Vector3(allChildren[i].localEulerAngles.x, allChildren[i].localEulerAngles.y - 180, allChildren[i].localEulerAngles.z);
                }
            }
    }

    /// <summary>
    /// Rotate the player skin.
    /// 플레이어 스킨을 이동 합니다.
    /// </summary> 
    /// <param name="Rotation">
    /// Position value
    /// 좌표 값
    /// </param>
    public static void skinPos(Vector3 Pos) => skinPos2(PlayerObject, Pos, false, 0.175f);

    /// <summary>
    /// Move the player skin.
    /// 플레이어 스킨을 이동 합니다.
    /// </summary>
    /// <param name="Rotation">
    /// Position value
    /// 좌표 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to move smoothly or instantly
    /// 부드럽게 또는 즉시 이동할지 결정
    /// </param>
    public static void skinPos(Vector3 Pos, bool SetRotation) => skinPos2(PlayerObject, Pos, SetRotation, 0.175f);

    /// <summary>
    /// Move the player skin.
    /// 플레이어 스킨을 이동 합니다.
    /// </summary>
    /// <param name="Rotation">
    /// Position value
    /// 좌표 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to move smoothly or instantly
    /// 부드럽게 또는 즉시 이동할지 결정
    /// </param>
    /// <param name="Time">
    /// Move time
    /// 이동 시간
    /// </param>
    public static void skinPos(Vector3 Pos, bool SetRotation, float Time) => skinPos2(PlayerObject, Pos, SetRotation, Time);

    /// <summary>
    /// Move the skin.
    /// 스킨을 이동 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 이동 할 오브젝트
    /// </param>
    /// <param name="Pos">
    /// Position value
    /// 좌표 값
    /// </param>
    public static void skinPos(GameObject RotationObject, Vector3 Pos) => skinPos2(RotationObject, Pos, false, 0.175f);

    /// <summary>
    /// Move the skin.
    /// 스킨을 이동 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 이동 할 오브젝트
    /// </param>
    /// <param name="Pos">
    /// Position value
    /// 좌표 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to move smoothly or instantly
    /// 부드럽게 또는 즉시 이동할지 결정
    /// </param>
    public static void skinPos(GameObject RotationObject, Vector3 Pos, bool SetRotation) => skinPos2(RotationObject, Pos, SetRotation, 0.175f);

    /// <summary>
    /// Move the skin.
    /// 스킨을 회전 합니다.
    /// </summary>
    /// <param name="RotationObject">
    /// Object to be rotated
    /// 이동 할 오브젝트
    /// </param>
    /// <param name="Pos">
    /// Position value
    /// 좌표 값
    /// </param>
    /// <param name="SetRotation">
    /// Decide whether to move smoothly or instantly
    /// 부드럽게 또는 즉시 이동할지 결정
    /// </param>
    /// <param name="Time">
    /// Move time
    /// 이동 시간
    /// </param>
    public static void skinPos(GameObject RotationObject, Vector3 Pos, bool SetRotation, float Time) => skinPos2(RotationObject, Pos, SetRotation, Time);

    static void skinPos2(GameObject RotationObject, Vector3 Rotation, bool SetRotation, float time)
    {
        if (!SetRotation)
            RotationObject.transform.localPosition = Vector3.Lerp(RotationObject.transform.localPosition, Rotation, time);
        else
            RotationObject.transform.localPosition = Rotation;
    }
}