using Cathei.BakingSheet;

namespace Desolation.Scripts.GameData.Sheets
{
    public class EntityBaseSheet : Sheet<EntityBaseSheet.Row>
    {
        public class Row : SheetRow
        {
            public float Health { get; private set; }
            public float Damage { get; private set; }
        }
    }
}