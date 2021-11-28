using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EEGControl
{
    public class EEGVariableController : MonoBehaviour

    {
        [Range(0, 1000)]
        public float delta;

        [Range(0, 1000)]
        public float theta;

        [Range(0, 1000)]
        public float alpha;

        [Range(0, 1000)]
        public float beta;

        [Range(0, 1000)]
        public float gamma;

        public static float Delta;
        public static float Theta;
        public static float Alpha;
        public static float Beta;
        public static float Gamma;

        GUIStyle deltaStyle;
        GUIStyle thetaStyle;
        GUIStyle alphaStyle;
        GUIStyle betaStyle;
        GUIStyle gammaStyle;



        // Start is called before the first frame update
        void Start()
        {
            Delta = delta;
            Theta = theta;
            Alpha = alpha;
            Beta = beta;
            Gamma = gamma;

            deltaStyle = new GUIStyle();
            thetaStyle = new GUIStyle();
            alphaStyle = new GUIStyle();
            betaStyle = new GUIStyle();
            gammaStyle = new GUIStyle();

            deltaStyle.normal.textColor = Color.red;
            thetaStyle.normal.textColor = Color.magenta;
            alphaStyle.normal.textColor = Color.blue;
            betaStyle.normal.textColor = Color.green;
            gammaStyle.normal.textColor = Color.yellow;

            deltaStyle.fontSize = 20;
            thetaStyle.fontSize = 20;
            alphaStyle.fontSize = 20;
            betaStyle.fontSize = 20;
            gammaStyle.fontSize = 20;


        }

        void OnGUI()
        {

            GUI.Label(new Rect(0, 20, 100, 100), "Delta: " + Delta.ToString(), deltaStyle);
            GUI.Label(new Rect(0, 45, 100, 100), "Theta: " + Theta.ToString(), thetaStyle);
            GUI.Label(new Rect(0, 70, 100, 100), "Alpha: " + Alpha.ToString(), alphaStyle);
            GUI.Label(new Rect(0, 95, 100, 100), "Beta: " + Beta.ToString(), betaStyle);
            GUI.Label(new Rect(0, 120, 100, 100), "Gamma: " + Gamma.ToString(), gammaStyle);
            
        }

        // Update is called once per frame
        void Update()
        {
            OnGUI();
        }

        public void TestClick()
        {
            Alpha += 1;
        }


    }
}


