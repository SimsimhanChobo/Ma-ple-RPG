using UnityEngine;

public class ADOFAIMainCamera : MonoBehaviour
{
    public GameObject ADOFAIGamePlayer;

    void Start() => transform.position = new Vector3(0, 0, -14);

    void Update() => transform.position = Vector3.Lerp(transform.position, new Vector3(ADOFAIGamePlayer.transform.position.x, ADOFAIGamePlayer.transform.position.y, -14), 60 / GameManager.BPM / 16 * GameManager.Pitch);
}
