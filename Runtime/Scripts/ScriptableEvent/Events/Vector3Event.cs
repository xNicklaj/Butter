﻿using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace Dev.Nicklaj.Butter
{
    [CreateAssetMenu(menuName = "Butter/Events/Vector3 Event")]
    public class Vector3Event : GameEvent<Vector3>, ISerializedRaise
    {
        public bool HasArgument => true;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            // Try to parse the input as a vector2
            var tmp = arg0.Replace("(", "").Replace(")", "").Split(',');
            if (float.TryParse(tmp[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var x) == false || 
                float.TryParse(tmp[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var y) == false ||
                float.TryParse(tmp[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var z) == false)
            {
                Debug.LogError("Failed to parse the event data. Make sure the parameters for your vector3 event are correct.");
                return;
            }
            this.Raise(new Vector3(x,y,z));
        }
    }
}