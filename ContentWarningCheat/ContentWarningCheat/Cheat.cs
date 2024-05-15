using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;
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
using System.Globalization;
using static BedBoss;
using static UnityEngine.Rendering.DebugUI;
using Zorro.UI;
using UnityEngine.UI;
using Zorro.Core.Serizalization;
using System.Runtime.InteropServices;

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
        private bool makegameharder;
        private bool closelasers;
        private bool crazymonsters;
        private bool crazytrampoline;
        private bool crazypool;
        private bool setevening;
        private bool shockyourself;
        private bool makesoundloop;
        private bool superspeedothers;
        private bool slowothers;
        private bool superspeedmonsters;
        private bool slowmonsters;
        private bool reversecontrols;
        private bool shockplayers;
        private bool godmodeplayers;
        private bool playersjumploop;
        private bool playersfall;
        private bool clearallinventory;
        private bool bigsquareall;
        private bool giveallmcloop;
        private bool setallplayersname;
        private int lastClearedSlot;
        private string playerName = "";
        private float speedslider = 2f;
        private float gravityslider = 20.0f;
        public float facesize = 0.06f;
        public static ItemInstance[] Itemss;
        private Rect windowRect = new Rect(Screen.width / 2 - 300f, Screen.height / 2 - 175f, 600f, 350f);
        private int mainWID = 1024;
        private bool isDragging1 = true;
        private Vector2 offset1 = Vector2.zero;
        public static Player[] players;
        private Color selectedColor = Color.white;
        private int selectedTab = 0;
        private string[] hatNames = new string[] { "Balaclava", "Beanie", "Bucket hat", "Cat ears", "Chefs hat", "Floppy hat", "Homburg", "Curly hair", "Bowler hat", "Cap", "Propeller hat", "Clown hair", "Cowboy hat", "Crown", "Halo", "Horns", "Hotdog hat", "Jesters hat", "Ghost hat", "Milk hat", "News cap", "Pirate hat", "Sports helmet", "Savannah hair", "Tooop hat", "Top hat", "Party hat", "Shroom hat", "Ushanka", "Witch hat", "Hard hat" };
        private string[] enemyNames = new string[] { "AnglerMimic", "BarnacleBall", "BigSlap", "Bombs", "Dog", "Ear", "EyeGuy", "Flicker", "Ghost", "Jelly", "Knifo", "Larva", "MimicInfiltrator", "Mouthe", "Slurper", "Snatcho", "Spider", "Snail", "Toolkit_Fan", "Toolkit_Hammer", "Toolkit_Iron", "Toolkit_Vaccum", "Toolkit_Wisk", "Weeping", "Zombe" };
        private int selectedEnemyIndex = -1;
        private int selectedHatIndex = -1;
        private bool isEnemyDropdownVisible = false;
        private bool isHatDropdownVisible = false;
        private string enemyButtonText = "Select Enemy";
        private string hatButtonText = "Select Hat";
        private Vector2 enemyScrollPos;
        private Vector2 hatScrollPos;

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
            if (Input.GetKeyDown(KeyCode.End))
            {
                Loader.UnLoad();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
                {
                    item.Hide();
                }
            }
        }

        void closedebug()
        {
            foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
            {
                item.Hide();
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
            var lasers = GameObject.FindObjectsOfType<Laser>();
            var monsters = GameObject.FindObjectsOfType<Bot>();
            var trampoline = GameObject.FindObjectsOfType<Trampoline>();
            var water = GameObject.FindObjectsOfType<Water>();
            var room = GameObject.FindObjectsOfType<EveningToggler>();
            var playerinventory = GameObject.FindObjectsOfType<PlayerInventory>();
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
                if (nogravity == true)
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
            if (makegameharder)
            {
                foreach (DivingBell diving in divingBell)
                {
                    diving.spawnDifficulty = 200f;
                }
            }
            if (closelasers)
            {
                foreach (Laser laser in lasers)
                {
                    laser.enabled = false;
                    laser.liveLaser = false;
                }
            }
            if (crazymonsters)
            {
                foreach (Bot crazymonsters in monsters)
                {
                    crazymonsters.attacking = true;
                    crazymonsters.jumpScareLevel = 100;
                    crazymonsters.moveSpeedMultiplier = 22f;
                    crazymonsters.navigationSpeedAdjustment = 22f;
                    crazymonsters.animMoveSpeedFactor = 22f;
                }
            }
            if (crazytrampoline)
            {
                foreach (Trampoline trampo in trampoline)
                {
                    trampo.bounceForce = 3f;
                    trampo.launchForce = 3f;
                    trampo.launchForceRagdoll = 3f;
                    trampo.bounceForce = 3f;
                }
            }
            if (crazypool)
            {
                foreach (Water pool in water)
                {
                    pool.force = 5f;
                    pool.drag = 5f;
                    pool.playerForceM = 100f;
                    pool.maxDepth = 15f;
                }
            }
            if (setevening)
            {
                foreach (EveningToggler killme in room)
                {
                    killme.DayTimeChanged(TimeOfDay.Evening);
                }
            }
            else if (!setevening)
            {
                foreach (EveningToggler killme in room)
                {
                    killme.DayTimeChanged(TimeOfDay.Morning);
                }
            }
            if (shockyourself)
            {
                foreach (Player player in players)
                {
                    player.RPCA_CallTakeDamageAndTase(0f, 5f);
                }
            }
            if (makesoundloop)
            {
                foreach (Player player in players)
                {
                    if (player != null)
                    {
                        {
                            int soundID = 0;
                            player.refs.view.RPC("RPC_MakeSound", RpcTarget.All, new object[]
{
            soundID
});
                        }
                    }
                }
            }
            if (superspeedothers)
            {
                foreach (Player player in players)
                {
                    if (slowothers)
                    {
                        slowothers = false;
                    }
                    else if (reversecontrols)
                    {
                        reversecontrols = false;
                    }
                    else
                    {
                        if (player != null && !player.ai)
                        {
                            {
                                float speedFactor = 10f;
                                float time = 1f;
                                player.refs.view.RPC("RPCA_SlowFor", RpcTarget.All, new object[]
                                {
                                speedFactor,
                                time
                                });
                            }
                        }
                    }
                }
            }
            if (!superspeedothers && !slowothers && !reversecontrols)
            {
                foreach (Player player in players)
                {
                    if (player != null && !player.ai)
                    {
                        {
                            float speedFactor = 1f;
                            float time = 1f;
                            player.refs.view.RPC("RPCA_SlowFor", RpcTarget.All, new object[]
                            {
                                speedFactor,
                                time
                            });
                        }
                    }
                }
            }
            if (slowothers)
            {
                foreach (Player player in players)
                {
                    if (superspeedothers)
                    {
                        superspeedothers = false;
                    }
                    else if (reversecontrols)
                    {
                        reversecontrols = false;
                    }
                    else
                    {
                        if (player != null && !player.ai)
                        {
                            {
                                float speedFactor = -0f;
                                float time = 1f;
                                player.refs.view.RPC("RPCA_SlowFor", RpcTarget.All, new object[]
                                {
                                speedFactor,
                                time
                                });
                            }
                        }
                    }
                }
            }
            if (reversecontrols)
            {
                foreach (Player player in players)
                {
                    if (superspeedothers)
                    {
                        superspeedothers = false;
                    }
                    else if (slowothers)
                    {
                        slowothers = false;
                    }
                    else
                    {
                        if (player != null && !player.ai)
                        {
                            {
                                float speedFactor = -1f;
                                float time = 1f;
                                player.refs.view.RPC("RPCA_SlowFor", RpcTarget.All, new object[]
                                {
                                speedFactor,
                                time
                                });
                            }
                        }
                    }
                }
            }
            if (superspeedmonsters)
            {
                foreach (Player player in players)
                {
                    if (slowmonsters)
                    {
                        slowmonsters = false;
                    }
                    else
                    {
                        if (player != null && player.ai)
                        {
                            {
                                float speedFactor = 10f;
                                float time = 1f;
                                player.refs.view.RPC("RPCA_SlowFor", RpcTarget.All, new object[]
                                {
                                speedFactor,
                                time
                                });
                            }
                        }
                    }
                }
            }
            if (!superspeedmonsters && !slowmonsters)
            {
                foreach (Player player in players)
                {
                    if (player != null && player.ai)
                    {
                        {
                            float speedFactor = 1f;
                            float time = 1f;
                            player.refs.view.RPC("RPCA_SlowFor", RpcTarget.All, new object[]
                            {
                                speedFactor,
                                time
                            });
                        }
                    }
                }
            }
            if (slowmonsters)
            {
                foreach (Player player in players)
                {
                    if (superspeedmonsters)
                    {
                        superspeedmonsters = false;
                    }
                    else
                    {
                        if (player != null && player.ai)
                        {
                            {
                                float speedFactor = -0f;
                                float time = 1f;
                                player.refs.view.RPC("RPCA_SlowFor", RpcTarget.All, new object[]
                                {
                                speedFactor,
                                time
                                });
                            }
                        }
                    }
                }
            }
            if (shockplayers)
            {
                foreach (Player player in players)
                {
                    if (player != null)
                    {
                        {
                            float damage = 0f;
                            float tase = 1f;
                            player.refs.view.RPC("RPCA_CallTakeDamageAndTase", RpcTarget.All, new object[]
                            {
                                damage,
                                tase
                            });
                        }
                    }
                }
            }
            if (godmodeplayers)
            {
                foreach (Player player in players)
                {
                    if (player != null && !player.ai)
                    {
                        player.CallHeal(99.99f);
                    }
                }
            }
            if (playersjumploop)
            {
                foreach (PlayerController playercontroller in playerControllers)
                {
                    foreach (Player player in players)
                    {
                        if (player != null && !player.ai)
                        {
                            {
                                playercontroller.TryJump();
                            }
                        }
                    }
                }
            }
            if (playersfall)
            {
                foreach (PlayerController playercontroller in playerControllers)
                {
                    foreach (Player player in players)
                    {
                        if (player != null && !player.ai)
                        {
                            {
                                float seconds = 1f;
                                player.refs.view.RPC("RPCA_Fall", RpcTarget.All, new object[]
                                {
                                    seconds
                                });
                            }
                        }
                    }
                }
            }
            if (clearallinventory)
            {
                foreach (PlayerInventory inventory in playerinventory)
                {
                    foreach (Player player in players)
                    {
                        if (player != null && !player.ai)
                        {
                            {
                                inventory.SyncClearSlot(lastClearedSlot);
                            }
                        }
                    }
                }
            }
            if (bigsquareall)
            {
                foreach (Player player in players)
                {
                    if (player != null)
                    {
                        float hue = 1f;
                        int colorIndex = -1;
                        string faceText = "☭";
                        float faceRotation = 1f;
                        float faceSize = 1f;
                        player.refs.view.RPC("RPCA_SetAllFaceSettings", RpcTarget.AllBuffered, new object[]
                        {
                            hue,
                            colorIndex,
                            faceText,
                            faceRotation,
                            faceSize
                        });
                    }
                }
            }
            if (giveallmcloop)
            {
                int currentRun = 1000000000;
                SurfaceNetworkHandler.Instance.photonView.RPC("RPCA_OnNewWeek", RpcTarget.All, new object[]
                {
                    currentRun
                });
            }
            if (setallplayersname)
            {
                foreach (Player player in players)
                {
                    if (player != null)
                    {
                        float hue = 1f;
                        int colorIndex = -1;
                        float faceRotation = 1f;
                        player.refs.view.RPC("RPCA_SetAllFaceSettings", RpcTarget.AllBuffered, new object[]
                        {
                            hue,
                            colorIndex,
                            playerName,
                            faceRotation,
                            facesize
                        });
                    }
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
                    case 4:
                        windowRect = GUI.Window(0, windowRect, menu5, "Content Warning Menu");
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

            void menu5(int id)
            {
                windowRect.width = 400f;
                windowRect.height = 435f;
                GUIStyle windowStyle = new GUIStyle(GUI.skin.window);
                Color hoverColor = new Color(0f, 51f / 255f, 102f / 255f);
                Texture2D hoverTexture = new Texture2D(1, 1);
                hoverTexture.SetPixel(0, 0, hoverColor);
                hoverTexture.Apply();
                windowStyle.normal.background = hoverTexture;
                windowStyle.onNormal.background = hoverTexture;
                windowStyle.onHover.background = hoverTexture;
                GUI.skin.window = windowStyle;
                var playervisor = GameObject.FindObjectsOfType<PlayerVisor>();
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Go Back Troll Tab", GUILayout.Width(380f)))
                {
                    selectedTab = 1;
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginVertical("Face Troll Stuff", GUI.skin.box);
                GUILayout.Space(40f);
                playerName = GUILayout.TextField(playerName, 3);
                GUILayout.BeginHorizontal();
                setallplayersname = GUILayout.Toggle(setallplayersname, "Set All Players Face", GUILayout.Width(190));
                bigsquareall = GUILayout.Toggle(bigsquareall, "All Players Face Big Square", GUILayout.Width(180));
                GUILayout.EndHorizontal();
                facesize = GUILayout.HorizontalSlider(facesize, 0.01f, 5.0f);
                GUILayout.Label("Face Size: " + facesize.ToString());
                GUILayout.EndVertical();
                GUILayout.BeginVertical("Illegal Characters", GUI.skin.box);
                GUILayout.Space(40f);
                GUILayout.BeginHorizontal();
                GUILayout.Label("╰⋃╯");
                if(GUILayout.Button("Copy", GUILayout.Width(120)))
                {
                    GUIUtility.systemCopyBuffer = "╰⋃╯";
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("≖ʖ≖");
                if (GUILayout.Button("Copy", GUILayout.Width(120)))
                {
                    GUIUtility.systemCopyBuffer = "≖ʖ≖";
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("≧◡≦");
                if (GUILayout.Button("Copy", GUILayout.Width(120)))
                {
                    GUIUtility.systemCopyBuffer = "≧◡≦";
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("ᵔ.ᵔ");
                if (GUILayout.Button("Copy", GUILayout.Width(120)))
                {
                    GUIUtility.systemCopyBuffer = "ᵔ.ᵔ";
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("＾▿＾");
                if (GUILayout.Button("Copy", GUILayout.Width(120)))
                {
                    GUIUtility.systemCopyBuffer = "＾▿＾";
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("║█║");
                if (GUILayout.Button("Copy", GUILayout.Width(120)))
                {
                    GUIUtility.systemCopyBuffer = "║█║";
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("-_•");
                if (GUILayout.Button("Copy", GUILayout.Width(120)))
                {
                    GUIUtility.systemCopyBuffer = "-_•";
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("Х̶̿̀͊̍̈́͑̓̈́̃̆́Х̶̿̀͊̍̈́Х̶̿̀͊̍̈́");
                if (GUILayout.Button("Copy", GUILayout.Width(120)))
                {
                    GUIUtility.systemCopyBuffer = "Х̶̿̀͊̍̈́͑̓̈́̃̆́Х̶̿̀͊̍̈́Х̶̿̀͊̍̈́";
                }
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }

            void menu4(int id)
            {
                windowRect.height = 350f;
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
                windowRect.width = 600;
                windowRect.height = 515f;
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
                if (GUILayout.Button("Self - Server",GUILayout.Width(100f)))
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

                GUILayout.BeginVertical(GUI.skin.box);
                {
                    GUILayout.Box("Enemy Spawner");
                    GUILayout.Space(20f);
                    if (GUILayout.Button(enemyButtonText, GUILayout.Height(55)))
                    {
                        isEnemyDropdownVisible = !isEnemyDropdownVisible;
                    }
                    if (isEnemyDropdownVisible)
                    {
                        float dropdownHeight = Mathf.Min(enemyNames.Length * 30, 200);
                        GUILayout.BeginVertical(GUI.skin.box, GUILayout.Height(dropdownHeight));
                        enemyScrollPos = GUILayout.BeginScrollView(enemyScrollPos);
                        foreach (var enemyName in enemyNames)
                        {
                            if (GUILayout.Button(enemyName, GUILayout.Height(30)))
                            {
                                selectedEnemyIndex = Array.IndexOf(enemyNames, enemyName);
                                enemyButtonText = enemyName;
                                isEnemyDropdownVisible = false;
                            }
                        }
                        GUILayout.EndScrollView();
                        GUILayout.EndVertical();
                    }
                    if (selectedEnemyIndex != -1 && GUILayout.Button("Spawn Enemy", GUILayout.Height(40)))
                    {
                        Monster.SpawnMonster(enemyNames[selectedEnemyIndex]);
                    }
                }
                GUILayout.EndVertical();

                GUILayout.BeginVertical(GUI.skin.box);
                {
                    GUILayout.Box("Hat Spawner");
                    GUILayout.Space(20f);
                    if (GUILayout.Button(hatButtonText, GUILayout.Height(55)))
                    {
                        isHatDropdownVisible = !isHatDropdownVisible;
                    }
                    if (isHatDropdownVisible)
                    {
                        float dropdownHeight = Mathf.Min(hatNames.Length * 30, 200);
                        GUILayout.BeginVertical(GUI.skin.box, GUILayout.Height(dropdownHeight));
                        hatScrollPos = GUILayout.BeginScrollView(hatScrollPos);
                        foreach (var hatName in hatNames)
                        {
                            if (GUILayout.Button(hatName, GUILayout.Height(30)))
                            {
                                selectedHatIndex = Array.IndexOf(hatNames, hatName);
                                hatButtonText = hatName;
                                isHatDropdownVisible = false;
                            }
                        }
                        GUILayout.EndScrollView();
                        GUILayout.EndVertical();
                    }
                    if (selectedHatIndex != -1 && GUILayout.Button("Spawn Hat", GUILayout.Height(40)))
                    {
                        MetaProgressionHandler.EquipHat(selectedHatIndex);
                    }
                    if (selectedHatIndex != -1 && GUILayout.Button("Spawn Hat For All Players", GUILayout.Height(40)))
                    {
                        foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
                        {
                            item.Show();
                            foreach (Player player in players)
                            {
                                if (player != null)
                                {
                                    {
                                        player.Call_EquipHat(11);
                                        player.Call_EquipHat(selectedHatIndex);
                                    }
                                }
                            }
                        }
                        closedebug();
                    }
                }
                GUILayout.EndVertical();
            }
        }


        void menu2(int id)
        {
            windowRect.width = 600f;
            windowRect.height = 595f;
            var divingBell = GameObject.FindObjectsOfType<DivingBell>();
            var pickups = GameObject.FindObjectsOfType<Pickup>();
            var playerinventory = GameObject.FindObjectsOfType<PlayerInventory>();
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
                DivingBellDoorButton[] interact = FindObjectsOfType<DivingBellDoorButton>();
                Player[] players = Cheat.players;
                for (int i = 0; i < Mathf.Min(interact.Length, players.Length); i++)
                {
                    interact[i].Interact(players[i]);
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
            if (GUILayout.Button("Force Players To Pickup Item", GUILayout.Width(186), GUILayout.Height(52)))
            {
                if (Player.localPlayer != null)
                {
                    Pickup[] pickup = FindObjectsOfType<Pickup>();
                    Player[] players = Cheat.players;
                    for (int i = 0; i < Mathf.Min(players.Length); i++)
                    {
                        pickup[i].Interact(players[i]);
                    }
                }
            }
            if (GUILayout.Button("Start Game", GUILayout.Width(125), GUILayout.Height(52)))
            {
                SurfaceNetworkHandler.Instance.RequestStartGame();
            }
            if (GUILayout.Button("Reset Surface", GUILayout.Width(252), GUILayout.Height(52)))
            {
                SurfaceNetworkHandler.ResetSurface();
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Teleport To Random Realm", GUILayout.Width(186), GUILayout.Height(52)))
            {
                ShadowRealmHandler.instance.TeleportPlayerToRandomRealm(Player.localPlayer);
            }
            if (GUILayout.Button("Teleport Players To Random Realm", GUILayout.Width(383), GUILayout.Height(52)))
            {
                foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
                {
                    item.Show();
                    Player[] players = GetPlayersOnCurrentServer();
                    if (players != null && players.Length > 0)
                    {
                        foreach (Player player in players)
                        {
                            if (player != null)
                            {
                                {
                                    ShadowRealmHandler.instance.TeleportPlayerToRandomRealm(player);
                                    Debug.Log("!! TO CLOSE THAT MENU JUST PRESS ESC BUTTON !!");
                                }
                            }
                        }
                    }
                }
                closedebug();
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Make Sound", GUILayout.Width(186), GUILayout.Height(40)))
            {
                foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
                {
                    item.Show();
                    foreach (Player player in players)
                    {
                        if (player != null)
                        {
                            {
                                int soundID = 0;
                                player.refs.view.RPC("RPC_MakeSound", RpcTarget.All, new object[]
{
            soundID
});
                            }
                        }
                    }
                   
                }
                closedebug();
            }
            if (GUILayout.Button("Give Players MC", GUILayout.Width(125), GUILayout.Height(40)))
            {
                int currentRun = 1000000;
                SurfaceNetworkHandler.Instance.photonView.RPC("RPCA_OnNewWeek", RpcTarget.All, new object[]
                {
                    currentRun
                });
            }
            if (GUILayout.Button("Face Troll Tab", GUILayout.Width(252), GUILayout.Height(40)))
            {
                selectedTab = 4;
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            fastbeep = GUILayout.Toggle(fastbeep, "Fast Camera Beep", GUILayout.Width(125));
            GUILayout.Space(20f);
            lockdivingbelldoor = GUILayout.Toggle(lockdivingbelldoor, "Divingbell Lock", GUILayout.Width(125));
            GUILayout.Space(5f);
            reqsleep = GUILayout.Toggle(reqsleep, "Players To Sleep Loop", GUILayout.Width(150));
            GUILayout.Space(10f);
            killallmonstersloop = GUILayout.Toggle(killallmonstersloop, "Kill Monsters Loop", GUILayout.Width(150));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            brokedrone = GUILayout.Toggle(brokedrone, "Broke The Drone", GUILayout.Width(125));
            GUILayout.Space(20f);
            alwaysopendoor = GUILayout.Toggle(alwaysopendoor, "Open Sliding Doors", GUILayout.Width(130));
            makegameharder = GUILayout.Toggle(makegameharder, "More Harder Spawn", GUILayout.Width(130));
            GUILayout.Space(30f);
            closelasers = GUILayout.Toggle(closelasers, "Close Lasers", GUILayout.Width(130));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            crazymonsters = GUILayout.Toggle(crazymonsters, "Crazy Monsters", GUILayout.Width(130));
            GUILayout.Space(15f);
            crazytrampoline = GUILayout.Toggle(crazytrampoline, "Crazy Trampoline", GUILayout.Width(130));
            crazypool = GUILayout.Toggle(crazypool, "Crazy Pool Physics ", GUILayout.Width(130));
            GUILayout.Space(30f);
            setevening = GUILayout.Toggle(setevening, "Time Set Evening", GUILayout.Width(130));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            makesoundloop = GUILayout.Toggle(makesoundloop, "Make Sound Loop", GUILayout.Width(120));
            GUILayout.Space(25f);
            superspeedothers = GUILayout.Toggle(superspeedothers, "All Players Super Speed", GUILayout.Width(165));
            GUILayout.Space(10f);
            slowothers = GUILayout.Toggle(slowothers, "All Players Slow", GUILayout.Width(115));
            shockplayers = GUILayout.Toggle(shockplayers, "Shock Players", GUILayout.Width(160));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            reversecontrols = GUILayout.Toggle(reversecontrols, "Reverse Player Controls", GUILayout.Width(160));
            superspeedmonsters = GUILayout.Toggle(superspeedmonsters, "All Monster Super Speed", GUILayout.Width(160));
            slowmonsters = GUILayout.Toggle(slowmonsters, "All Monster Slow", GUILayout.Width(115));
            godmodeplayers = GUILayout.Toggle(godmodeplayers, "Godemode Players", GUILayout.Width(130));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            clearallinventory = GUILayout.Toggle(clearallinventory, "Clear Players Inventory", GUILayout.Width(160));
            giveallmcloop = GUILayout.Toggle(giveallmcloop, "Drop All Players FPS", GUILayout.Width(150));
            GUILayout.Space(10f);
            playersjumploop = GUILayout.Toggle(playersjumploop, "All Players Fly", GUILayout.Width(115));
            playersfall = GUILayout.Toggle(playersfall, "Make Players Fall", GUILayout.Width(125));
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
            if (GUILayout.Button("Delete Pickups", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                foreach (Pickup pickup in pickups)
                {
                    pickup.RPC_Remove();
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Wipe Money", GUILayout.Width(186), GUILayout.Height(52)))
            {
                foreach (var player in PhotonNetwork.PlayerListOthers)
                {
                    int actorNumber = player.ActorNumber;
                    SurfaceNetworkHandler.Instance.RPCA_HospitalBill(actorNumber, 99999);
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }

        Player[] GetPlayersOnCurrentServer()
        {
            return Cheat.players;
        }

        private void menu(int id)
        {
            windowRect.width = 600f;
            windowRect.height = 555f;
            players = FindObjectsOfType<Player>();
            var hat = GameObject.FindObjectsOfType<HatShop>();
            var inventory = GameObject.FindObjectsOfType<PlayerInventory>();
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
            if (GUILayout.Button("Add 500K Meta Coins", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                MetaProgressionHandler.AddMetaCoins(500000);
            }
            if (GUILayout.Button("Remove 500K Meta Coins", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                MetaProgressionHandler.RemoveMetaCoins(500000);
            }
            if (GUILayout.Button("Clear Inventory", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                foreach(PlayerInventory playerinventory in inventory)
                {
                    playerinventory.Clear();
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("Open Console", GUILayout.Width(281)))
                {
                    foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
                    {
                        item.Show();
                    }
                }

                if (GUILayout.Button("Close Console", GUILayout.Width(281)))
                {
                    foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
                    {
                        item.Hide();
                    }
                }
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
            GUILayout.Space(5f);
            shockyourself = GUILayout.Toggle(shockyourself, "Shock Yourself", GUILayout.Width(120));
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
            if (GUILayout.Button("Revive  All Players", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
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
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add Inf Quota (Host Only)", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                SurfaceNetworkHandler.RoomStats.AddQuota(99999999);
            }
            if (GUILayout.Button("Delete 50K Money(Host Only)", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                SurfaceNetworkHandler.RoomStats.RemoveMoney(50000);
            }
            if (GUILayout.Button("Restock Hat Store", GUILayout.Width(186), GUILayout.Height(52), GUILayout.ExpandWidth(false)))
            {
                foreach (HatShop hatshop in hat)
                {
                    hatshop.Restock();
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Kill All Players", GUILayout.Width(186), GUILayout.Height(52)))
            {
                foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
                {
                    item.Show();
                    foreach (Player player in players)
                    {
                        if (player != null)
                        {
                            {
                                player.CallTakeDamage(999f);
                            }
                        }
                    }
                }
                closedebug();
            }
            if (GUILayout.Button("Make Clown All Players", GUILayout.Width(186), GUILayout.Height(52)))
            {
                foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
                {
                    item.Show();
                    foreach (Player player in players)
                    {
                        if (player != null)
                        {
                            {
                                player.Call_EquipHat(11);
                            }
                        }
                    }
                }
                closedebug();
            }
            if (GUILayout.Button("Make 1HP All Players", GUILayout.Width(186), GUILayout.Height(52)))
            {
                foreach (DebugUIHandler item in FindObjectsOfType<DebugUIHandler>())
                {
                    item.Show();
                    foreach (Player player in players)
                    {
                        if (player != null)
                        {
                            {
                                player.data.health = 100f;
                                player.CallTakeDamage(99f);
                            }
                        }
                    }
                }
                closedebug();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
    }
}
