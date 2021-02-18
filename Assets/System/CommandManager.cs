using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    static readonly List<string> InputCommand = new List<string>();
    static string InputCommandTemp = "";

    public static void Command(string Command)
    {
        InputCommand.Clear();
        InputCommandTemp = "";

        if (Command != "")
        {
            if (Command[0].ToString() == "/")
                Command = Command.Substring(1);

            for (int i = 0; i < Command.Length; i++)
            {
                if (Command[i].ToString() == " " && Command[Command.Length - 1].ToString() != " ")
                {
                    InputCommand.Add(InputCommandTemp);
                    InputCommandTemp = "";
                    i++;
                }

                InputCommandTemp += Command[i];
            }
            InputCommand.Add(InputCommandTemp);

            if (InputCommand[0] == "help")
            {
                ChattingManager.Message("/time Enum[set, query, add] {Int, Enum[day, midnight, night, noon]}");
                ChattingManager.Message("/tp Pos");
                ChattingManager.Message("/motion Pos2D");
                ChattingManager.Message("/setblock PosInt String");
                ChattingManager.Message("/kill");
                ChattingManager.Message("/damage Int Int");
            }
            else if (InputCommand[0] == "time" && InputCommand.Count > 1)
            {
                bool timeSuc;
                float time;

                if (InputCommand.Count == 3)
                {
                    if (InputCommand[2] == "day")
                    {
                        timeSuc = true;
                        time = 1000;
                    }
                    else if (InputCommand[2] == "midnight")
                    {
                        timeSuc = true;
                        time = 18000;
                    }
                    else if (InputCommand[2] == "night")
                    {
                        timeSuc = true;
                        time = 13000;
                    }
                    else if (InputCommand[2] == "noon")
                    {
                        timeSuc = true;
                        time = 7700;
                    }
                    else
                        timeSuc = Float(2, out time);

                    if (timeSuc && InputCommand[1] == "set")
                        Time(time, SetQueryAdd.Set);
                    else if (timeSuc && InputCommand[1] == "add")
                        Time(time, SetQueryAdd.Add);
                    else if (timeSuc)
                        ChattingManager.Message("알 수 없는 명령어 입니다");
                }
                else if (InputCommand[1] == "query" && InputCommand.Count == 2)
                    Time(0, SetQueryAdd.Query);
                else
                    ChattingManager.Message("알 수 없는 명령어 입니다");
            }
            else if (InputCommand[0] == "tp" && InputCommand.Count > 1)
            {
                bool pos = Pos(1, out Vector3 vector3);

                if (InputCommand.Count == 4 && pos)
                    Tp(vector3);
                else if (pos)
                    ChattingManager.Message("알 수 없는 명령어 입니다");
            }
            else if (InputCommand[0] == "motion" && InputCommand.Count > 1)
            {
                bool pos = Pos2D(1, out Vector2 vector2);

                if (InputCommand.Count == 3 && pos)
                    Motion(vector2);
                else if (pos)
                    ChattingManager.Message("알 수 없는 명령어 입니다");
            }
            else if (InputCommand[0] == "setblock" && InputCommand.Count > 1)
            {
                bool pos = PosInt(1, out Vector3 vector3);

                if (InputCommand.Count == 5 && pos)
                    SetBlock(vector3, InputCommand[4]);
                else if (pos)
                    ChattingManager.Message("알 수 없는 명령어 입니다");
            }
            else if (InputCommand[0] == "kill")
            {
                if (InputCommand.Count == 1)
                    Kill();
                else
                    ChattingManager.Message("알 수 없는 명령어 입니다");
            }
            else if (InputCommand[0] == "damage" && InputCommand.Count > 1)
            {
                float damage;
                int type;
                
                bool b = Float(1, out damage);
                bool bb = Int(2, out type);

                if (InputCommand.Count == 3 && b && bb)
                    Damage(damage, type);
                else if (b && bb)
                    ChattingManager.Message("알 수 없는 명령어 입니다");
            }
            else
                ChattingManager.Message("알 수 없는 명령어 입니다");
        }
    }

    static bool Int(int CommandIndex, out int Int)
    {
        if (InputCommand.Count - 1 < CommandIndex)
        {
            ChattingManager.Message("알 수 없는 명령어 입니다");
            Int = 0;
            return false;
        }
        else if (!int.TryParse(InputCommand[CommandIndex], out Int))
        {
            ChattingManager.Message("int가 필요합니다");
            Int = 0;
            return false;
        }

        return true;
    }

    static bool Float(int CommandIndex, out float Float)
    {
        if (InputCommand.Count - 1 < CommandIndex)
        {
            ChattingManager.Message("알 수 없는 명령어 입니다");
            Float = 0;
            return false;
        }
        else if (!float.TryParse(InputCommand[CommandIndex], out Float))
        {
            ChattingManager.Message("float가 필요합니다");
            Float = 0;
            return false;
        }

        return true;
    }

    static bool PosInt(int CommandIndex, out Vector3 Pos)
    {
        Pos = Vector3.zero;
        if (InputCommand.Count < CommandIndex + 3)
        {
            ChattingManager.Message("불완전합니다 (좌표 3개가 필요합니다)");
            Pos = Vector3.zero;
            return false;
        }
        else if ((!int.TryParse(InputCommand[CommandIndex], out int i) && InputCommand[CommandIndex].ToString()[0].ToString() != "~") || (!int.TryParse(InputCommand[CommandIndex + 1], out i) && InputCommand[CommandIndex + 1].ToString()[0].ToString() != "~") || (!int.TryParse(InputCommand[CommandIndex + 2], out i) && InputCommand[CommandIndex + 2].ToString()[0].ToString() != "~"))
        {
            ChattingManager.Message("int가 필요합니다");
            Pos = Vector3.zero;
            return false;
        }

        if (InputCommand[CommandIndex] == "~")
            Pos.x = (int)GameManager.PlayerX;
        else if (InputCommand[CommandIndex][0].ToString() == "~")
        {
            if (!int.TryParse(InputCommand[CommandIndex].Substring(1), out int temp))
            {
                ChattingManager.Message("int가 필요합니다");
                Pos = Vector3.zero;
                return false;
            }

            Pos.x = GameManager.PlayerX + temp;
        }
        else
            Pos.x = int.Parse(InputCommand[CommandIndex]);

        if (InputCommand[CommandIndex + 1] == "~")
            Pos.y = (int)GameManager.PlayerY;
        else if (InputCommand[CommandIndex + 1][0].ToString() == "~")
        {
            if (!int.TryParse(InputCommand[CommandIndex + 1].Substring(1), out int temp))
            {
                ChattingManager.Message("int가 필요합니다");
                Pos = Vector3.zero;
                return false;
            }

            Pos.y = GameManager.PlayerY + temp;
        }
        else
            Pos.y = int.Parse(InputCommand[CommandIndex + 1]);

        if (InputCommand[CommandIndex + 2] == "~")
            Pos.z = (int)GameManager.PlayerZ;
        else if (InputCommand[CommandIndex + 2][0].ToString() == "~")
        {
            if (!int.TryParse(InputCommand[CommandIndex + 2].Substring(1), out int temp))
            {
                ChattingManager.Message("int가 필요합니다");
                Pos = Vector3.zero;
                return false;
            }

            Pos.z = GameManager.PlayerZ + temp;
        }
        else
            Pos.z = int.Parse(InputCommand[CommandIndex + 2]);

        return true;
    }

    static bool Pos(int CommandIndex, out Vector3 Pos)
    {
        Pos = Vector3.zero;
        if (InputCommand.Count < CommandIndex + 3)
        {
            ChattingManager.Message("불완전합니다 (좌표 3개가 필요합니다)");
            Pos = Vector3.zero;
            return false;
        }
        else if ((!float.TryParse(InputCommand[CommandIndex], out float i) && InputCommand[CommandIndex].ToString()[0].ToString() != "~") || (!float.TryParse(InputCommand[CommandIndex + 1], out i) && InputCommand[CommandIndex + 1].ToString()[0].ToString() != "~") || (!float.TryParse(InputCommand[CommandIndex + 2], out i) && InputCommand[CommandIndex + 2].ToString()[0].ToString() != "~"))
        {
            ChattingManager.Message("float가 필요합니다");
            Pos = Vector3.zero;
            return false;
        }

        if (InputCommand[CommandIndex] == "~")
            Pos.x = Player.player.transform.position.x;
        else if (InputCommand[CommandIndex][0].ToString() == "~")
        {
            if (!float.TryParse(InputCommand[CommandIndex].Substring(1), out float temp))
            {
                ChattingManager.Message("float가 필요합니다");
                Pos = Vector3.zero;
                return false;
            }

            Pos.x = Player.player.transform.position.x + temp;
        }
        else
            Pos.x = float.Parse(InputCommand[CommandIndex]);

        if (InputCommand[CommandIndex + 1] == "~")
            Pos.y = Player.player.transform.position.y;
        else if (InputCommand[CommandIndex + 1][0].ToString() == "~")
        {
            if (!float.TryParse(InputCommand[CommandIndex + 1].Substring(1), out float temp))
            {
                ChattingManager.Message("float가 필요합니다");
                Pos = Vector3.zero;
                return false;
            }

            Pos.y = Player.player.transform.position.y + temp;
        }
        else
            Pos.y = float.Parse(InputCommand[CommandIndex + 1]);

        if (InputCommand[CommandIndex + 2] == "~")
            Pos.z = Player.player.transform.position.z;
        else if (InputCommand[CommandIndex + 2][0].ToString() == "~")
        {
            if (!float.TryParse(InputCommand[CommandIndex + 2].Substring(1), out float temp))
            {
                ChattingManager.Message("float가 필요합니다");
                Pos = Vector3.zero;
                return false;
            }

            Pos.z = Player.player.transform.position.z + temp;
        }
        else
            Pos.z = float.Parse(InputCommand[CommandIndex + 2]);

        return true;
    }

    static bool PosInt2D(int CommandIndex, out Vector2 Pos)
    {
        Pos = Vector2.zero;
        if (InputCommand.Count < CommandIndex + 2)
        {
            ChattingManager.Message("불완전합니다 (좌표 2개가 필요합니다)");
            Pos = Vector2.zero;
            return false;
        }
        else if ((!int.TryParse(InputCommand[CommandIndex], out int i) && InputCommand[CommandIndex].ToString()[0].ToString() != "~") || (!int.TryParse(InputCommand[CommandIndex + 1], out i) && InputCommand[CommandIndex + 1].ToString()[0].ToString() != "~"))
        {
            ChattingManager.Message("int가 필요합니다");
            Pos = Vector2.zero;
            return false;
        }

        if (InputCommand[CommandIndex] == "~")
            Pos.x = (int)GameManager.PlayerX;
        else if (InputCommand[CommandIndex][0].ToString() == "~")
        {
            if (!int.TryParse(InputCommand[CommandIndex].Substring(1), out int temp))
            {
                ChattingManager.Message("int가 필요합니다");
                Pos = Vector2.zero;
                return false;
            }

            Pos.x = GameManager.PlayerX + temp;
        }
        else
            Pos.x = int.Parse(InputCommand[CommandIndex]);

        if (InputCommand[CommandIndex + 1] == "~")
            Pos.y = (int)GameManager.PlayerY;
        else if (InputCommand[CommandIndex + 1][0].ToString() == "~")
        {
            if (!int.TryParse(InputCommand[CommandIndex + 1].Substring(1), out int temp))
            {
                ChattingManager.Message("int가 필요합니다");
                Pos = Vector2.zero;
                return false;
            }

            Pos.y = GameManager.PlayerY + temp;
        }
        else
            Pos.y = int.Parse(InputCommand[CommandIndex + 1]);

        return true;
    }

    static bool Pos2D(int CommandIndex, out Vector2 Pos)
    {
        Pos = Vector2.zero;
        if (InputCommand.Count < CommandIndex + 2)
        {
            ChattingManager.Message("불완전합니다 (좌표 2개가 필요합니다)");
            Pos = Vector2.zero;
            return false;
        }
        else if ((!float.TryParse(InputCommand[CommandIndex], out float i) && InputCommand[CommandIndex].ToString()[0].ToString() != "~") || (!float.TryParse(InputCommand[CommandIndex + 1], out i) && InputCommand[CommandIndex + 1].ToString()[0].ToString() != "~"))
        {
            ChattingManager.Message("float가 필요합니다");
            Pos = Vector2.zero;
            return false;
        }

        if (InputCommand[CommandIndex] == "~")
            Pos.x = Player.player.transform.position.x;
        else if (InputCommand[CommandIndex][0].ToString() == "~")
        {
            if (!float.TryParse(InputCommand[CommandIndex].Substring(1), out float temp))
            {
                ChattingManager.Message("float가 필요합니다");
                Pos = Vector3.zero;
                return false;
            }

            Pos.x = Player.player.transform.position.x + temp;
        }
        else
            Pos.x = float.Parse(InputCommand[CommandIndex]);

        if (InputCommand[CommandIndex + 1] == "~")
            Pos.y = Player.player.transform.position.y;
        else if (InputCommand[CommandIndex + 1][0].ToString() == "~")
        {
            if (!float.TryParse(InputCommand[CommandIndex + 1].Substring(1), out float temp))
            {
                ChattingManager.Message("float가 필요합니다");
                Pos = Vector3.zero;
                return false;
            }

            Pos.y = Player.player.transform.position.y + temp;
        }
        else
            Pos.y = float.Parse(InputCommand[CommandIndex + 1]);

        return true;
    }

    public enum SetQueryAdd
    {
        Set,
        Query,
        Add
    }

    //Command

    public static void Time(float time, SetQueryAdd setAdd)
    {
        if (setAdd == SetQueryAdd.Set)
            GameManager.GameTime = time;
        else if (setAdd == SetQueryAdd.Query)
        {
            ChattingManager.Message("현재 시간은 " + GameManager.GameTime + "입니다");
            return;
        }
        else if (setAdd == SetQueryAdd.Add)
            GameManager.GameTime += time;

        ChattingManager.Message("시간을 " + GameManager.GameTime + "(으)로 설정했습니다");
    }

    public enum TimeEnum
    {
        day,
        midnignt,
        night,
        noon
    }

    public static void Tp(Vector3 vector3)
    {
        Player.player.transform.position = vector3;
        Rigidbody2D rigidbody2D = Player.player.GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = Vector2.zero;
        ChattingManager.Message("MinedApple을(를) " + vector3.x + ", " + vector3.y + ", " + vector3.z + "(으)로 순간이동 시켰습니다.");
    }

    public static void Motion(Vector2 vector2)
    {
        Rigidbody2D rigidbody2D = Player.player.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = vector2;

        ChattingManager.Message("MinedApple의 개체 데이터 Motion을(를) [" + vector2.x + "f, " + vector2.y + "f]로 변경했습니다");
    }

    public static void SetBlock(Vector3 vector3, string Block)
    {
        vector3.x = (int)vector3.x;
        vector3.y = (int)vector3.y;
        vector3.z = (int)vector3.z;

        if (vector3.x < 0)
            vector3.x -= 0.5f;
        else
            vector3.x += 0.5f;

        vector3.y += 0.5f;

        RaycastHit2D raycastHit2D;

        raycastHit2D = Physics2D.Raycast(vector3, new Vector2(0, 0.01f), 0.01f, LayerMask.GetMask("Map", "Water", "Fire", "Glass", "Stairs"));

        if (raycastHit2D.collider != null)
        {
            Destroy(raycastHit2D.collider.transform.gameObject);
            BlockBrightness.Reload(vector3);
        }

        if (Block == "air")
        {
            vector3.x = (int)vector3.x + 1;
            if (vector3.y < 0)
                vector3.y = (int)vector3.y - 1;
            else
                vector3.y = (int)vector3.y;
            ChattingManager.Message(vector3.x + " " + vector3.y + " " + vector3.z + "에 있는 블록을 바꿨습니다");
        }

        if (Block != "air")
        {
            Texture2D BlockTexture = Resources.Load<Texture2D>("Minecraft Block Texture/" + Block);
            GameObject prefab = Resources.Load<GameObject>("Sand Box/block." + Block);

            if (prefab != null)
            {
                GameObject block = Instantiate(prefab);
                BlockSetting blockSetting = block.GetComponent<BlockSetting>();

                block.transform.position = vector3;
            }
            else if (BlockTexture == null)
            {
                ChattingManager.Message("알 수 없는 블록 유형 입니다");
                return;
            }
            else
            {
                GameObject block = Instantiate(Resources.Load<GameObject>("Sand Box/Minecraft Block"));
                BlockSetting blockSetting = block.GetComponent<BlockSetting>();

                block.transform.position = vector3;
                blockSetting.Texture = BlockTexture;

                vector3.x = (int)vector3.x + 1;
                if (vector3.y < 0)
                    vector3.y = (int)vector3.y - 1;
                else
                    vector3.y = (int)vector3.y;
                ChattingManager.Message(vector3.x + " " + vector3.y + " " + vector3.z + "에 있는 블록을 바꿨습니다");
            }
        }
    }

    public static void Kill()
    {
        GameManager.gameManager.GetComponent<GameManager>().PlayerDamage(ulong.MaxValue, false, 0);
        if (GameManager.PlayerHP < 0 && !GameManager.DeltaruneBattle)
            GameManager.gameManager.GetComponent<GameManager>().GameOver("세계 밖으로 떨어졌습니다");
        ChattingManager.Message("MinedApple을(를) 죽였습니다");
    }

    public static void Damage(float Damage, int Type)
    {
        GameManager.gameManager.GetComponent<GameManager>().PlayerDamage(Damage, false, Type);
        if (GameManager.PlayerHP < 0 && !GameManager.DeltaruneBattle)
            GameManager.gameManager.GetComponent<GameManager>().GameOver("너무 많은 데미지 명령어를 받았습니다");
        ChattingManager.Message("MinedApple의 개체 데이터를 변경했습니다");
    }
}
