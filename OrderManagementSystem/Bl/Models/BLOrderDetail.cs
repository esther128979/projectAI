
namespace Bl.Models;

public partial class BLOrderDetail
{
    public int OrderCode { get; set; }

    public int? CategoryCode { get; set; }

    public int? UsageDays { get; set; }
}
