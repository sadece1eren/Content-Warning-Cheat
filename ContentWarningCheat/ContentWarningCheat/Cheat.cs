using System.Reflection;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Realtime;
using static HasSpaceTest;
using TMPro;
using static ContentWarningCheat.Esp;
using UnityEngine.Rendering;
using static Unity.Burst.Intrinsics.Arm;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using System.Threading;
using Zorro.Core;
using Zorro.Core.CLI;

namespace ContentWarningCheat
{
    class Cheat : MonoBehaviour
    {
        private bool menushow = true;
        private bool infstamina;
        private bool infoxygen;
        private bool godmode;
        private bool infcamera;
        private bool infbattery;
        private bool thewalkingdead;
        private bool infjump;
        private bool sillymod;
        private bool fastbeep;
        private bool nogravity;
        private bool superjump;
        private bool PlayerBoxEspToggle;
        private bool superspeed;
        private bool lockdivingbelldoor;
        private bool reqsleep;
        private bool killallmonstersloop;
        private bool PlayerLineEspToogle;
        private bool PlayerStringEspToogle;
        private bool PlayerEspColor;
        private bool MonsterEspColor;
        private bool MonsterBoxEspToogle;
        private bool MonsterLineEspToogle;
        private bool MonsterStringEspToogle;
        private bool brokedrone;
        private bool alwaysopendoor;
        private float speedslider = 2f;
        private float gravityslider = 20.0f;
        public static ItemInstance[] Itemss;
        private Rect windowRect = new Rect(Screen.width / 2 - 300f, Screen.height / 2 - 175f, 600f, 350f);
        private int mainWID = 1024;
        private bool isDragging1 = true;
        private Vector2 offset1 = Vector2.zero;
        public static Player[] players;
        private Color selectedColor = Color.white;
        private int selectedTab = 0;
        private string[] enemyNames = new string[] { "AnglerMimic", "BarnacleBall", "BigSlap", "Bombs", "Dog", "Ear", "EyeGuy", "Flicker", "Ghost", "Jelly", "Knifo", "Larva", "MimicInfiltrator", "Mouthe", "Slurper", "Snatcho", "Spider", "Snail", "Toolkit_Fan", "Toolkit_Hammer", "Toolkit_Iron", "Toolkit_Vaccum", "Toolkit_Wisk", "Weeping", "Zombe" };
        private int selectedEnemyIndex = -1;
        private bool isEnemyDropdownVisible = false;
        private string enemyButtonText = "Select Enemy";
        private Vector2 enemyScrollPos;
        private Texture2D CreateTextureFromColor(Color color)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, color);
            texture.Apply();
            return texture;
        }

        void KeyBoardStuff()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                menushow = !menushow;
            }
        }

        void Update()
        {
            var door = GameObject.FindObjectsOfType<SlidingDoor>();
            var divingBell = GameObject.FindObjectsOfType<DivingBell>();
            var players = GameObject.FindObjectsOfType<Player>();
            var playerControllers = GameObject.FindObjectsOfType<PlayerController>();
            var videoCameras = GameObject.FindObjectsOfType<VideoCamera>();
            var drone = GameObject.FindObjectsOfType<Drone>();
            KeyBoardStuff();
            if (godmode)
            {
                foreach (Player player in players)
                {
                    player.data.dead = false;
                }
                Player.localPlayer.data.health = 100f;
            }

            if (infoxygen)
            {
                Player.localPlayer.data.usingOxygen = false;
                Player.localPlayer.data.remainingOxygen = 500f;
            }

            if (infstamina)
            {
                Player.localPlayer.data.currentStamina = 100f;
            }

            if (infcamera)
            {
                foreach (Player player in players)
                {
                    PlayerInventory playerInventory;
                    player.TryGetInventory(out playerInventory);
                    if (playerInventory != null)
                    {
                        foreach (InventorySlot inventorySlot in playerInventory.slots)
                        {
                            VideoInfoEntry Cam;
                            if (inventorySlot.ItemInSlot.item != null && inventorySlot.ItemInSlot.data.TryGetEntry<VideoInfoEntry>(out Cam) && Cam.maxTime > Cam.timeLeft)
                            {
                                Cam.timeLeft = 100f;
                            }
                        }
                    }
                }
            }

            if (infbattery)
            {
                foreach (Player player in players)
                {
                    PlayerInventory playerInventory;
                    player.TryGetInventory(out playerInventory);
                    if (playerInventory != null)
                    {
                        foreach (InventorySlot inventorySlot in playerInventory.slots)
                        {
                            BatteryEntry battery;
                            if (inventorySlot.ItemInSlot.item != null && inventorySlot.ItemInSlot.data.TryGetEntry<BatteryEntry>(out battery) && battery.m_maxCharge > battery.m_charge)
                            {
                                battery.AddCharge(100f);
                            }
                        }
                    }
                }
            }

            if (thewalkingdead)
            {
                foreach (Player player in players)
                {
                    player.data.dead = false;
                }
            }

            if (infjump)
            {
                foreach (Player player in players)
                {
                    player.data.sinceJump = 0.7f;
                    player.data.sinceGrounded = 0.4f;
                }
            }

            if (sillymod)
            {
                foreach (Player player in players)
                {
                    player.data.sinceJump = 10f;
                    player.data.sinceGrounded = 2f;
                }
            }

            if (fastbeep)
            {
                foreach (VideoCamera camera in videoCameras)
                {
                    camera.bleepInterval = 0.1f;
                    camera.dontBeepUntil = 0.1f;
                }
            }
            if (nogravity == true || nogravity == false)
            {
                if(nogravity == true)
                {
                    foreach (PlayerController playerController in playerControllers)
                    {
                        playerController.gravity = 0.0f;
                        playerController.constantGravity = 0.0f;
                    }
                    gravityslider = 0.0f;
                }
                else
                {
                    foreach (PlayerController playerController in playerControllers)
                    {
                        playerController.gravity = gravityslider;
                        playerController.constantGravity = gravityslider;
                    }
                }
            }
            if (superjump)
            {
                foreach (PlayerController playerController in playerControllers)
                {
                    playerController.jumpImpulse = 3f;
                    playerController.jumpForceDuration = 3f;
                    playerController.jumpForceOverTime = 3f;
                }
            }
            else if (!superjump)
            {
                foreach (PlayerController playerController in playerControllers)
                {
                    playerController.jumpForceDuration = 0.5f;
                    playerController.jumpForceDuration = 0.8f;
                    playerController.jumpForceOverTime = 0.8f;
                }
            }
            if (superspeed == true || superspeed == false)
            {
                if (superspeed == true)
                {
                    foreach (PlayerController playerController in playerControllers)
                    {
                        playerController.sprintMultiplier = 20f;
                    }
                    speedslider = 20f;
                }
                else
                {
                    foreach (PlayerController playerController in playerControllers)
                    {
                        playerController.sprintMultiplier = speedslider;
                    }
                }
            }
            if (lockdivingbelldoor)
            {
                foreach (DivingBell diving in divingBell)
                {
                    diving.locked = true;
                    diving.LockDoors();
                    diving.opened = false;
                    diving.AttemptSetOpen(diving.locked);
                    diving.OnDisable();
                    diving.LockDoors();
                }
            }
            
            if (reqsleep)
            {
                Bed[] beds = FindObjectsOfType<Bed>();
                Player[] player = Cheat.players;
                for (int i = 0; i < beds.Length; i++)
                {
                    beds[i].RequestSleep(player[i]);
                }
            }
            if (killallmonstersloop)
            {
                Monster.KillAll();
                BotHandler.instance.DestroyAll();
            }
            if (brokedrone)
            {
                foreach (Drone dronee in drone)
                {
                    dronee.grav = 0.1f;
                    dronee.spring = 0.1f;
                    dronee.drag = 0.1f;
                    dronee.angularDrag = 0f;
                }
            }
            if (alwaysopendoor)
            {
                foreach (SlidingDoor doorsliding in door)
                {
                    doorsliding.alwaysOpen = true;
                    doorsliding.RPCA_Open();
                }
            }
        }

        void OnGUI()
        {
            if (menushow)
            {
                switch (selectedTab)
                {
                    case 0:
                        windowRect = GUI.Window(0, windowRect, menu, "Content Warning Menu");
                        break;
                    case 1:
                        windowRect = GUI.Window(0, windowRect, menu2, "Content Warning Menu");
                        break;
                    case 2:
                        windowRect = GUI.Window(0, windowRect, menu3, "Content Warning Menu");
                        break;
                    case 3:
                        windowRect = GUI.Window(0, windowRect, menu4, "Content Warning Menu");
                        break;
                    default:
                        Debug.LogError("Invalid tab index!");
                        break;

                }
                HandleDragging(ref windowRect, ref isDragging1, ref offset1);
            }

            foreach (Player player in UnityEngine.Object.FindObjectsOfType(typeof(Player)) as Player[])
            {
                Vector3 w2s_head = Camera.main.WorldToScreenPoint(player.HeadPosition());
                Vector3 w2s_foot = Camera.main.WorldToScreenPoint(player.data.groundPos);
                if (PlayerBoxEspToggle)
                {
                    if (w2s_foot.z > 0f && player != null && player != Player.localPlayer && !player.ai && player.data.dead == false)
                    {
                        if (PlayerEspColor)
                        {
                            Esp.DrawBoxPlayers(w2s_foot, w2s_head, selectedColor);
                        }
                        else
                        {
                            Esp.DrawBoxPlayers(w2s_foot, w2s_head, Color.blue);
                        }
                    }
                }
                if (MonsterBoxEspToogle)
                {
                    if (w2s_foot.z > 0f && player != null && player != Player.localPlayer && player.ai && player.data.dead == false)
                    {
                        if (MonsterEspColor)
                        {
                            Esp.DrawBoxPlayers(w2s_foot, w2s_head, selectedColor);
                        }
                        else
                        {
                            Esp.DrawBoxPlayers(w2s_foot, w2s_head, Color.red);
                        }
                    }
                }
            }
            foreach (Player player in UnityEngine.Object.FindObjectsOfType(typeof(Player)) as Player[])
            {
                Vector3 w2s_head = Camera.main.WorldToScreenPoint(player.HeadPosition());
                Vector3 w2s_foot = Camera.main.WorldToScreenPoint(player.data.groundPos);
                if (PlayerLineEspToogle)
                {
                    if (w2s_foot.z > 0f && player != null && player != Player.localPlayer && !player.ai && player.data.dead == false)
                    {
                        if (PlayerEspColor)
                        {
                            Esp.DrawLinePlayers(w2s_foot, w2s_head, selectedColor);
                        }
                        else
                        {
                            Esp.DrawLinePlayers(w2s_foot, w2s_head, Color.blue);
                        }
                    }
                }
                if (MonsterLineEspToogle)
                {
                    if (w2s_foot.z > 0f && player != null && player != Player.localPlayer && player.ai && player.data.dead == false)
                    {
                        if (MonsterEspColor)
                        {
                            Esp.DrawLinePlayers(w2s_foot, w2s_head, selectedColor);
                        }
                        else
                        {
                            Esp.DrawLinePlayers(w2s_foot, w2s_head, Color.red);
                        }
                    }
                }
            }

            foreach (Player player in UnityEngine.Object.FindObjectsOfType(typeof(Player)) as Player[])
            {
                float health = player.data.health;
                float stamina = player.data.currentStamina;
                float oxygen = player.data.remainingOxygen;
                bool dead = player.data.dead;
                Vector3 w2s_head = Camera.main.WorldToScreenPoint(player.HeadPosition());
                Vector3 w2s_foot = Camera.main.WorldToScreenPoint(player.data.groundPos);
                Vector3 position = w2s_head;
                if (PlayerStringEspToogle)
                {
                    if (w2s_foot.z > 0f && player != null && player != Player.localPlayer && !player.ai && player.data.dead == false)
                    {
                        if (PlayerEspColor)
                        {
                            position += new Vector3(0, 0, 0);
                            Esp.DrawStringPlayers("Stamina: " + stamina, position, w2s_head, selectedColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Health: " + health, position, w2s_head, selectedColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Oxygen: " + oxygen, position, w2s_head, selectedColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Is Dead: " + dead, position, w2s_head, selectedColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Name: " + player.refs.view.Owner.NickName, position, w2s_head, selectedColor);
                        }
                        else
                        {
                            Color customColor = new Color(64f / 255f, 224f / 255f, 208f / 255f);
                            position += new Vector3(0, 0, 0);
                            Esp.DrawStringPlayers("Stamina: " + stamina, position, w2s_head, customColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Health: " + health, position, w2s_head, customColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Oxygen: " + oxygen, position, w2s_head, customColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Is Dead: " + dead, position, w2s_head, customColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Name: " + player.refs.view.Owner.NickName, position, w2s_head, customColor);
                        }
                    }
                }
                if (MonsterStringEspToogle)
                {
                    if (w2s_foot.z > 0f && player != null && player != Player.localPlayer && player.ai && player.data.dead == false)
                    {
                        if (MonsterEspColor)
                        {
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Stamina: " + stamina, position, w2s_head, selectedColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Is Dead: " + dead, position, w2s_head, selectedColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Health: " + health, position, w2s_head, selectedColor);
                        }
                        else
                        {
                            Color customColor = new Color(123f / 255f, 3f / 255f, 35f / 255f);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Stamina: " + stamina, position, w2s_head, customColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Is Dead: " + dead, position, w2s_head, customColor);
                            position += new Vector3(-100, 0, 0);
                            Esp.DrawStringPlayers("Health: " + health, position, w2s_head, customColor);
                        }
                    }
                }
            }

            void HandleDragging(ref Rect window, ref bool isDragging, ref Vector2 offset)
            {
                if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && window.Contains(Event.current.mousePosition))
                {
                    isDragging = true;
                    offset = Event.current.mousePosition - new Vector2(window.x, window.y);
                }
                if (isDragging && Event.current.type == EventType.MouseDrag)
                {
                    window.position = Event.current.mousePosition - offset;
                }
                if (Event.current.type == EventType.MouseUp)
                {
                    isDragging = false;
                }
            }

            void menu4(int id)
            {
                GUIStyle windowStyle = new GUIStyle(GUI.skin.window);
                Color hoverColor = new Color(0f, 51f / 255f, 102f / 255f);
                Texture2D hoverTexture = new Texture2D(1, 1);
                hoverTexture.SetPixel(0, 0, hoverColor);
                hoverTexture.Apply();
                windowStyle.normal.background = hoverTexture;
                windowStyle.onNormal.background = hoverTexture;
                windowStyle.onHover.background = hoverTexture;
                GUI.skin.window = windowStyle;

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Self - Server", GUILayout.Width(100f)))
                {
                    selectedTab = 0;
                }
                GUILayout.Space(56);
                if (GUILayout.Button("Troll", GUILayout.Width(100f)))
                {
                    selectedTab = 1;
                }
                GUILayout.Space(56);
                if (GUILayout.Button("Spawn", GUILayout.Width(100f)))
                {
                    selectedTab = 2;
                }
                GUILayout.Space(56);
                if (GUILayout.Button("ESP", GUILayout.Width(100f)))
                {
                    selectedTab = 3;
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginVertical("Player", GUI.skin.box);
                GUILayout.Space(40f);
                GUILayout.BeginHorizontal();
                PlayerBoxEspToggle = GUILayout.Toggle(PlayerBoxEspToggle, "Player Box", GUILayout.Width(125));
                GUILayout.Space(10f);
                PlayerLineEspToogle = GUILayout.Toggle(PlayerLineEspToogle, "Player Line", GUILayout.Width(125));
                GUILayout.Space(10f);
                PlayerStringEspToogle = GUILayout.Toggle(PlayerStringEspToogle, "Player String", GUILayout.Width(125));
                GUILayout.Space(2f);
                PlayerEspColor = GUILayout.Toggle(PlayerEspColor, "Player Esp Custom Color", GUILayout.Width(175));
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
                GUILayout.BeginVertical("Enemy", GUI.skin.box);
                GUILayout.Space(40f);
                GUILayout.BeginHorizontal();
                MonsterBoxEspToogle = GUILayout.Toggle(MonsterBoxEspToogle, "Enemy Box", GUILayout.Width(125));
                GUILayout.Space(10f);
                MonsterLineEspToogle = GUILayout.Toggle(MonsterLineEspToogle, "Enemy Line", GUILayout.Width(125));
                GUILayout.Space(10f);
                MonsterStringEspToogle = GUILayout.Toggle(MonsterStringEspToogle, "Enemy String", GUILayout.Width(125));
                GUILayout.Space(2f);
                MonsterEspColor = GUILayout.Toggle(MonsterEspColor, "Enemy Esp Custom Color", GUILayout.Width(175));
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
                GUILayout.BeginVertical("Color Picker", GUI.skin.box);
                GUIStyle colorBoxStyle = new GUIStyle(GUI.skin.box);
                colorBoxStyle.normal.background = CreateTextureFromColor(selectedColor);
                GUILayout.Label("Red :");
                selectedColor.r = GUILayout.HorizontalSlider(selectedColor.r, 0f, 1f);
                GUILayout.Label("Green: ");
                selectedColor.g = GUILayout.HorizontalSlider(selectedColor.g, 0f, 1f);
                GUILayout.Label("Blue: ");
                selectedColor.b = GUILayout.HorizontalSlider(selectedColor.b, 0f, 1f);
                GUILayout.BeginHorizontal();
                GUILayout.Space(238);
                GUILayout.Box("", colorBoxStyle, GUILayout.Width(100), GUILayout.Height(30));
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }

            void menu3(int id)
            {
                GUIStyle windowStyle = new GUIStyle(GUI.skin.window);
                Color hoverColor = new Color(0f, 51f / 255f, 102f / 255f);
                Texture2D hoverTexture = new Texture2D(1, 1);
                hoverTexture.SetPixel(0, 0, hoverColor);
                hoverTexture.Apply();
                windowStyle.normal.background = hoverTexture;
                windowStyle.onNormal.background = hoverTexture;
                windowStyle.onHover.background = hoverTexture;
                GUI.skin.window = windowStyle;

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Self - Server", GUILayout.Width(100f)))
                {
                    selectedTab = 0;
                }
                GUILayout.Space(56);
                if (GUILayout.Button("Troll", GUILayout.Width(100f)))
                {
                    selectedTab = 1;
                }
                GUILayout.Space(56);
                if (GUILayout.Button("Spawn", GUILayout.Width(100f)))
                {
                    selectedTab = 2;
                }
                GUILayout.Space(56);
                if (GUILayout.Button("ESP", GUILayout.Width(100f)))
                {
                    selectedTab = 3;
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginVertical("Enemy Spawner", GUI.skin.box);
                {
                    GUILayout.Space(20f);
                    if (GUILayout.Button(enemyButtonText, GUILayout.Width(570), GUILayout.Height(55)))
                    {
                        isEnemyDropdownVisible = !isEnemyDropdownVisible;
                    }
                    if (isEnemyDropdownVisible)
                    {
                        float dropdownHeight = Mathf.Min(enemyNames.Length * 30, 200);
                        GUILayout.BeginVertical(GUI.skin.box, GUILayout.Height(dropdownHeight));
                        GUILayout.BeginHorizontal();
                        GUILayout.Space(180);
                        enemyScrollPos = GUILayout.BeginScrollView(enemyScrollPos);
                        foreach (var enemyName in enemyNames)
                        {
                            if (GUILayout.Button(enemyName, GUILayout.Width(190), GUILayout.Height(30)))
                            {
                                selectedEnemyIndex = Array.IndexOf(enemyNames, enemyName);
                                enemyButtonText = enemyName;
                                isEnemyDropdownVisible = false;
                            }
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.EndScrollView();
                        GUILayout.EndVertical();
                    }
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(180);
                    if (selectedEnemyIndex != -1 && GUILayout.Button("Spawn Enemy", GUILayout.Width(200), GUILayout.Height(40)))
                    {
                        Monster.SpawnMonster(enemyNames[selectedEnemyIndex]);
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();
            }
            void menu2(int id)
            {
                var divingBell = GameObject.FindObjectsOfType<DivingBell>();
                GUIStyle windowStyle = new GUIStyle(GUI.skin.window);
                Color hoverColor = new Color(0f, 51f / 255f, 102f / 255f);
                Texture2D hoverTexture = new Texture2D(1, 1);
                hoverTexture.SetPixel(0, 0, hoverColor);
                hoverTexture.Apply();
                windowStyle.normal.background = hoverTexture;
                windowStyle.onNormal.background = hoverTexture;
                windowStyle.onHover.background = hoverTexture;
                GUI.skin.window = windowStyle;

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Self - Server", GUILayout.Width(100f)))
                {
                    selectedTab = 0;
                }
                GUILayout.Space(56);
                if (GUILayout.Button("Troll", GUILayout.Width(100f)))
                {
                    selectedTab = 1;
                }
                GUILayout.Space(56);
                if (GUILayout.Button("Spawn", GUILayout.Width(100f)))
                {
                    selectedTab = 2;
                }
                GUILayout.Space(56);
                if (GUILayout.Button("ESP", GUILayout.Width(100f)))
                {
                    selectedTab = 3;
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginVertical("Troll Stuff", GUI.skin.box);
                GUILayout.Space(40f);
                GUILayout.BeginHorizontal();

                if (GUILayout.Button("Force Players To Sleep", GUILayout.Width(186), GUILayout.Height(52)))
                {
                    Bed[] beds = FindObjectsOfType<Bed>();
                    Player[] players = Cheat.players;

                    for (int i = 0; i < Mathf.Min(beds.Length, players.Length); i++)
                    {
                        beds[i].RequestSleep(players[i]);
                    }
                }

                if (GUILayout.Button("Open Divingbell", GUILayout.Width(125), GUILayout.Height(52)))
                {
                    foreach (DivingBell diving in divingBell)
                    {
                        diving.locked = false;
                        diving.AttemptSetOpen(true);
                        diving.enabled = true;
                        diving.opened = true;
                        diving.OnEnable();
                        diving.SetDoorStateInstant(true);
                    }
                }

                if (GUILayout.Button("Kill All Monsters", GUILayout.Width(125), GUILayout.Height(52)))
                {
                    Monster.KillAll();
                    BotHandler.instance.DestroyAll();
                }

                if (GUILayout.Button("Duplicate Player", GUILayout.Width(125), GUILayout.Height(52)))
                {
                    Monster.SpawnMonster("Player");
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                fastbeep = GUILayout.Toggle(fastbeep, "Fast Camera Beep", GUILayout.Width(125));
                GUILayout.Space(20f);
                lockdivingbelldoor = GUILayout.Toggle(lockdivingbelldoor, "Divingbell Lock", GUILayout.Width(125));
                GUILayout.Space(5f);
                reqsleep = GUILayout.Toggle(reqsleep, "Players To Sleep Loop", GUILayout.Width(150));
                GUILayout.Space(5f);
                killallmonstersloop = GUILayout.Toggle(killallmonstersloop, "Kill Monsters Loop", GUILayout.Width(150));
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                brokedrone = GUILayout.Toggle(brokedrone, "Broke The Drone", GUILayout.Width(125));
                GUILayout.Space(20f);
                alwaysopendoor = GUILayout.Toggle(alwaysopendoor, "Open Sliding Doors", GUILayout.Width(130));
                GUILayout.EndHorizontal();
                GUILayout.BeginVertical();
                GUILayout.Space(10f);
                GUILayout.EndVertical();
                GUILayout.BeginHorizontal();
                GUILayout.Space(230);
                GUILayout.Label("Only Works On Host", GUILayout.Width(200));
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Divingbell To Surface", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
                {
                    foreach (DivingBell diving in divingBell)
                    {
                        diving.GoToSurface();
                        diving.locked = true;
                        diving.LockDoors();
                        diving.opened = false;
                        diving.AttemptSetOpen(diving.locked);
                        diving.OnDisable();
                        diving.LockDoors();
                    }
                }
                if (GUILayout.Button("Divingbell To UnderWorld", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
                {
                    foreach (DivingBell diving in divingBell)
                    {
                        diving.GoUnderground();
                        diving.locked = true;
                        diving.LockDoors();
                        diving.opened = false;
                        diving.AttemptSetOpen(diving.locked);
                        diving.OnDisable();
                        diving.LockDoors();
                    }

                }

                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }
        }

        private void menu(int id)
        {
            players = FindObjectsOfType<Player>();
            GUIStyle windowStyle = new GUIStyle(GUI.skin.window);
            Color hoverColor = new Color(0f, 51f / 255f, 102f / 255f);
            Texture2D hoverTexture = new Texture2D(1, 1);
            hoverTexture.SetPixel(0, 0, hoverColor);
            hoverTexture.Apply();
            windowStyle.normal.background = hoverTexture;
            windowStyle.onNormal.background = hoverTexture;
            windowStyle.onHover.background = hoverTexture;
            GUI.skin.window = windowStyle;
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("Self - Server", GUILayout.Width(100f)))
            {
                selectedTab = 0;
            }
            GUILayout.Space(56);
            if (GUILayout.Button("Troll", GUILayout.Width(100f)))
            {
                selectedTab = 1;
            }
            GUILayout.Space(56);
            if (GUILayout.Button("Spawn", GUILayout.Width(100f)))
            {
                selectedTab = 2;
            }
            GUILayout.Space(56);
            if (GUILayout.Button("ESP", GUILayout.Width(100f)))
            {
                selectedTab = 3;
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginVertical("Self Stuff", GUI.skin.box);
            GUILayout.Space(40f);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Kill Yourself", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                thewalkingdead = false;
                Player.localPlayer.Die();
            }
            if (GUILayout.Button("Revive Yourself", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                thewalkingdead = false;
                Player.localPlayer.CallRevive();
            }
            if (GUILayout.Button("The Walking Dead", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                thewalkingdead = true;
                Player.localPlayer.Die();
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            infstamina = GUILayout.Toggle(infstamina, "Inf Stamina", GUILayout.Width(87));
            GUILayout.Space(10f);
            godmode = GUILayout.Toggle(godmode, "Godmode", GUILayout.Width(87));
            GUILayout.Space(10f);
            infoxygen = GUILayout.Toggle(infoxygen, "Inf Oxygen", GUILayout.Width(87));
            GUILayout.Space(10f);
            infcamera = GUILayout.Toggle(infcamera, "Inf Camera", GUILayout.Width(87));
            GUILayout.Space(10f);
            infbattery = GUILayout.Toggle(infbattery, "Inf Battery", GUILayout.Width(87));
            GUILayout.Space(10f);
            infjump = GUILayout.Toggle(infjump, "Inf Jump", GUILayout.Width(115));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            sillymod = GUILayout.Toggle(sillymod, "Silly Mode", GUILayout.Width(87));
            GUILayout.Space(10f);
            nogravity = GUILayout.Toggle(nogravity, "No Gravity", GUILayout.Width(87));
            GUILayout.Space(10f);
            superjump = GUILayout.Toggle(superjump, "Super Jump", GUILayout.Width(87));
            GUILayout.Space(10f);
            superspeed = GUILayout.Toggle(superspeed, "Super Speed", GUILayout.Width(92));
            GUILayout.EndHorizontal();
            GUILayout.Space(10f);
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Label("Set Custom Speed" + " - " + "Current Speed" + " " + speedslider.ToString());
            speedslider = GUILayout.HorizontalSlider(speedslider, 0f, 25.0f, GUILayout.Width(280));
            GUILayout.EndVertical();
            GUILayout.Space(10f);
            GUILayout.BeginVertical();
            GUILayout.Label("Set Custom Gravity" + " - " + "Current Gravity" + " " + gravityslider.ToString());
            gravityslider = GUILayout.HorizontalSlider(gravityslider, -10f, 200.0f, GUILayout.Width(275));
            GUILayout.EndVertical();
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUILayout.BeginVertical("Server Stuff", GUI.skin.box);
            GUILayout.Space(40f);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Set Next Day (Host Only)", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                SurfaceNetworkHandler.RoomStats.NextDay();
            }
            if (GUILayout.Button("Add 50K Money (Host Only)", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                SurfaceNetworkHandler.RoomStats.AddMoney(50000);
            }
            if (GUILayout.Button("Revive  All", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                if (Cheat.players.Length > 0)
                {
                    foreach (Player player in Cheat.players)
                    {
                        if (player != null)
                        {
                            player.CallRevive();
                        }
                    }
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
    }
}