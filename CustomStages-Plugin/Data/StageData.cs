using System;
using UnityEngine;

namespace CustomStages.Data
{
    [Serializable]
    public class StageData
    {
        public string StageName;
        public string Author;
        public string MusicID;

        [Header("Blastzones")]
        public float BlastzoneDistUp = 28;
        public float BlastzoneDistDown = 25;
        public float BlastzoneDistLeft = 24;
        public float BlastzoneDistRight = 24;

        [Header("Camera")]
        public float CameraDistUp = 18;
        public float CameraDistDown = 15;
        public float CameraDistLeft = 18;
        public float CameraDistRight = 18;
        public float CameraMinDist = 7;
    }
}
