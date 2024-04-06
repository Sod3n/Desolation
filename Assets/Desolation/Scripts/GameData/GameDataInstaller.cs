using System.Threading.Tasks;
using Cathei.BakingSheet;
using Cathei.BakingSheet.Unity;
using UnityEngine;
using Zenject;

namespace Desolation.Scripts.GameData
{
    public class GameDataInstaller : MonoInstaller<GameDataInstaller>
    {
        public override void InstallBindings()
        {
            var sheetContainer = new SheetContainer(new UnityLogger());
            var jsonConverter = new JsonSheetConverter("Assets/Desolation/GameData/Converted");
            _ = Task.Run(() => sheetContainer.Bake(jsonConverter)).Result; // get result to wait async method

            Container.BindInstance(sheetContainer)
                .AsSingle();
        }
    }
}