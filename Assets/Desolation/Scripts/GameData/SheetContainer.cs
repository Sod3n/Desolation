using Cathei.BakingSheet;
using Desolation.Scripts.Data.Sheets;

namespace Desolation.Scripts.Data
{
    public class SheetContainer : SheetContainerBase
    {
        public SheetContainer(Microsoft.Extensions.Logging.ILogger logger) : base(logger) {}
        
        public EntityBaseSheet EntityBase { get; set; }
    }
}