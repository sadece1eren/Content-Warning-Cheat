using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ContentWarningCheat
{
    public class Esp : MonoBehaviour
    {
        public static void DrawBoxPlayers(Vector3 footpos, Vector3 headpos, Color color)
        {
            float height = headpos.y - footpos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;
            Render.DrawBox(footpos.x - (width / 2), (float)Screen.height - footpos.y - height, width, height, color, 2f);
        }
        public static void DrawLinePlayers(Vector3 footpos, Vector3 headpos, Color color)
        {
            float height = headpos.y - footpos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;
            Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(footpos.x, (float)Screen.height - footpos.y), color, 2f);
        }
        public static void DrawStringPlayers(string text, Vector3 footpos, Vector3 headpos, Color color)
        {
            float height = headpos.y - footpos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;
            var content = new GUIContent(text);
            var size = Render.StringStyle.CalcSize(content);
            var startPos = new Vector2(footpos.x - (width / 2) + size.x / 2, (float)Screen.height - footpos.y - height - size.y);
            Render.DrawString(startPos, text, color);
        }
    }
}