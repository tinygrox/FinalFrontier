using System;
using UnityEngine;
using KSP.Localization;

namespace Nereid
{
   namespace FinalFrontier
   {
      class AboutWindow : PositionableWindow
      {
            private static string str_About = Localizer.GetStringByTag("#FinalFrontier_About_title");
            private static string str_Close = Localizer.GetStringByTag("#FinalFrontier_Close");
         public AboutWindow()
            : base(Constants.WINDOW_ID_ABOUT, str_About) // "About"
         {

         }

         protected override void OnWindow(int id)
         {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical(FFStyles.STYLE_RIBBON_DESCRIPTION);
            GUILayout.Label("Final Frontier - written by Nereid (A.Kolster)",FFStyles.STYLE_STRETCHEDLABEL);
            GUILayout.Label("");
            GUILayout.Label("Some ribbons and graphics are inspired and/or created by Unistrut.", FFStyles.STYLE_STRETCHEDLABEL); 
            GUILayout.Label("The First-In-Space and First-EVA-In-Space ribbons are created by SmarterThanMe.", FFStyles.STYLE_STRETCHEDLABEL);
            GUILayout.Label("The toolbar was created by blizzy78.", FFStyles.STYLE_STRETCHEDLABEL);
            GUILayout.Label("Some custom ribbons are created/provided by nothke, SmarterThanMe, helldiver and Wyrmshadow.", FFStyles.STYLE_STRETCHEDLABEL);
            GUILayout.Label("");
            GUILayout.Label("Special thanks to Unistrut for giving permissions to use his ribbon graphics.", FFStyles.STYLE_STRETCHEDLABEL);
            GUILayout.Label("");
            GUILayout.Label("In memory of our beloved Cira. We will miss you.");
            GUILayout.Label("");
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            if (GUILayout.Button(str_Close, FFStyles.STYLE_BUTTON)) SetVisible(false); // "Close"
            GUILayout.EndHorizontal();
            DragWindow();
         }

         public override int GetInitialWidth()
         {
            return 350;
         }
      }
   }
}
