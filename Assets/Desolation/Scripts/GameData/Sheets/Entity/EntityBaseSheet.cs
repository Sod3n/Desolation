using Cathei.BakingSheet;

namespace Desolation.Scripts.Data.Sheets
{
    public class EntityBaseSheet : Sheet<EntityBaseSheet.Row>
    {
        public class Row : SheetRow
        {
            public float HP { get; private set; }
            public float Damage { get; private set; }
        }
    }
}