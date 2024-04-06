using Cathei.BakingSheet;
using Desolation.Scripts.GameData.Sheets;

namespace Desolation.Scripts.GameData
{
    public class SheetContainer : SheetContainerBase
    {
        public SheetContainer(Microsoft.Extensions.Logging.ILogger logger) : base(logger) {}
        
        public EntityBaseSheet EntityBase { get; set; }
    }
}