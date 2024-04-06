using System.IO;
using Cathei.BakingSheet;
using Cathei.BakingSheet.Unity;
using UnityEditor;
using UnityEngine;
using GoogleSheetConverter = Cathei.BakingSheet.GoogleSheetConverter;

namespace Desolation.Scripts.GameData.Editor
{
    public class ConvertorFromGoogleDocsWindow : EditorWindow
    {
        [MenuItem("Window/DataSheets/ConvertorFromGoogleDocs")]
        public static void ShowWindow()
        {
            GetWindow<ConvertorFromGoogleDocsWindow>(false, "Convertor", true);
        }
        
        void OnGUI()
        {
            if (GUILayout.Button("Convert From Google Docs"))
            {
                ConvertAsync();
            }
        }
        
        private async void ConvertAsync()
        {
            Debug.Log("Starting convert process. Please, wait.");
            
            var sheetContainer = new SheetContainer(new UnityLogger());
                
            // replace with your Google sheet identifier
            // https://developers.google.com/sheets/api/guides/concepts
            string googleSheetId = "1lRhQVgixL7TWecTHo9VWG1IWfd-oTGKmR7A0aAz6VO0";

            // service account credential than can read the sheet you're converting
            // this starts with { "type": "service_account", "project_id": ...
            string googleCredential = File.ReadAllText("Assets/Desolation/GameData/credentials.json");

            var googleConverter = new GoogleSheetConverter(googleSheetId, googleCredential);

            var jsonConverter = new JsonSheetConverter("Assets/Desolation/GameData/Converted/");
                
            // bake sheets from google converter
            await sheetContainer.Bake(googleConverter);
                
            await sheetContainer.Store(jsonConverter);
            
            Debug.Log("Convert process is done.");
        }
    }
    
}