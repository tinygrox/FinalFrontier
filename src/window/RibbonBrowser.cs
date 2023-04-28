using System;
using UnityEngine;
using System.Collections.Generic;
using KSP.Localization;

namespace Nereid
{
    namespace FinalFrontier
    {
        class RibbonBrowser : AbstractWindow
        {
            private Vector2 scrollPosition = Vector2.zero;
            public static int WIDTH = 555;
            public static int HEIGHT = 600;
            private String search = "";
            private static string Window_title = Localizer.Format("#FinalFrontier_RibbonBrowser_title");
            private static string btn_EnableAll = Localizer.Format("#FinalFrontier_RibbonBrowser_EnableAll");
            private static string btn_Close = Localizer.Format("#FinalFrontier_Close");
            private static string str_Search = Localizer.Format("#FinalFrontier_RibbonBrowser_Search");
            private static string str_None = Localizer.Format("#FinalFrontier_RibbonBrowser_NONE");
            private static string str_NoRibbons = Localizer.Format("#FinalFrontier_RibbonBrowser_noribbons");
            public RibbonBrowser(): base(Constants.WINDOW_ID_RIBBONBROWSER, Window_title) // "Ribbons"
            {
            }

         protected override void OnWindow(int id)
         {
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button(btn_EnableAll, FFStyles.STYLE_BUTTON)) // "Enable all"
            {
               FinalFrontier.configuration.EnableAllRibbons();
            }

            GUILayout.FlexibleSpace(); // Button("Ribbons:", GUIStyles.STYLE_LABEL);
            if (GUILayout.Button(btn_Close, FFStyles.STYLE_BUTTON)) // "Close"
            {
               SetVisible(false);
               // save configuration in case a ribbon was enabled/disabled
               FinalFrontier.configuration.Save();
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label(str_Search, HighLogic.Skin.label); // "Search:"
            search = GUILayout.TextField(search, FFStyles.STYLE_STRETCHEDTEXTFIELD);
            GUILayout.EndHorizontal();
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, FFStyles.STYLE_SCROLLVIEW, GUILayout.Height(HEIGHT));
            GUILayout.BeginVertical();
            int ribbonsFound = 0;
                string name;
                string description;
            foreach (Ribbon ribbon in RibbonPool.Instance())
            {
               name = ribbon.GetName();
               description = ribbon.GetDescription();
               if (search == null || search.Trim().Length == 0 || name.ContainsIgnoringCase(search) || description.ContainsIgnoringCase(search))
               {
                  GUILayout.BeginHorizontal(FFStyles.STYLE_RIBBON_AREA);
                  bool enabled = ribbon.enabled;
                  if(GUILayout.Toggle(enabled, "" , FFStyles.STYLE_NARROW_TOGGLE)!=enabled)
                  {
                     FinalFrontier.configuration.SetRibbonState(ribbon.GetCode(), !enabled);
                  }
                  GUILayout.Label(ribbon.GetTexture(), FFStyles.STYLE_SINGLE_RIBBON);
                  GUILayout.Label(name + ": " + description, FFStyles.STYLE_RIBBON_DESCRIPTION);
                  GUILayout.EndHorizontal();
                  ribbonsFound++;
               }
            }
            // no ribbons match search criteria
            if(ribbonsFound == 0)
            {
               GUILayout.BeginHorizontal(FFStyles.STYLE_RIBBON_AREA);
               GUILayout.Label(str_None, FFStyles.STYLE_SINGLE_RIBBON); // "NONE"
               GUILayout.Label(str_NoRibbons, FFStyles.STYLE_RIBBON_DESCRIPTION); // "no ribbons found"
               GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
            GUILayout.EndScrollView();
            GUILayout.Label(Localizer.Format("#FinalFrontier_RibbonBrowser_summaryribbons", RibbonPool.Instance().Count(), RibbonPool.Instance().GetCustomRibbons().Count), FFStyles.STYLE_STRETCHEDLABEL); //RibbonPool.Instance().Count() + " ribbons in total (" + RibbonPool.Instance().GetCustomRibbons().Count + " custom ribbons)" 
           
            GUILayout.EndVertical();

            DragWindow();
         }

         public override int GetInitialWidth()
         {
            return WIDTH;
         }
      }
   }
}