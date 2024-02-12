using System;
using UnityEngine;
using UnityEngine.UI;

namespace Util.Struct
{
    [Serializable]
    public struct FillState
    {
        public float m_value;
        public Color m_color;

        public FillState(float value, Color color)
        {
            m_value = value;
            m_color = color;
        }
    }
}