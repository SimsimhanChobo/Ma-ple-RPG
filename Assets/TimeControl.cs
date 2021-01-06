using UnityEngine;

public class TimeControl : MonoBehaviour 
{
	public static float GameTime = 6000;
	public float _time = GameTime;
	public static float time2 = 0;
	public float _time2 = time2;
	public static float time3 = 0;
	public float _time3 = time3;

	public static bool Sky = true;
	public static int TimeSetting = 0;

	public Light Light;

    void Update()
	{
		transform.position = MainCamera.Camera.gameObject.transform.position;

		if (MainCamera.Game3D)
			Light.shadows = LightShadows.Soft;
		else
			Light.shadows = LightShadows.None;

		if (TimeSetting == 0)
		{
			if (GameManager.DayTimeMinute != -1 && GameManager.DayTimeMinute != 0)
				GameManager.GameTime += 1 * (20 * Time.deltaTime * (20 / GameManager.DayTimeMinute));
			else if (GameManager.DayTimeMinute != 0)
				GameManager.GameTime += 1 * (20 * Time.deltaTime);
		}
		else if (TimeSetting == 1)
			GameManager.GameTime = GameManager.RealTime * 0.2777777f - 6000;
		else if (TimeSetting == 2)
			GameManager.GameTime = 1000;
		else if (TimeSetting == 3)
			GameManager.GameTime = 7700;
		else if (TimeSetting == 4)
			GameManager.GameTime = 13000;
		else if (TimeSetting == 5)
			GameManager.GameTime = 18000;

		GameTime = GameManager.GameTime;

		time2 = GameTime - 10000;
		time3 = GameTime - 22500;

		_time = GameTime;
		_time2 = time2;
		_time3 = time3;

		transform.localEulerAngles = new Vector3(GameTime * 0.015f, 35, 0);

		if (GameManager.GameTime >= 24000)
			GameManager.GameTime -= 24000;

		if (GameManager.GameTime < 0)
			GameManager.GameTime += 24000;
	}
}
