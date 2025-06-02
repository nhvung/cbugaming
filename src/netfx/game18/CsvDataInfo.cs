using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSSystem;

namespace game18
{
    class CsvDataInfo
    {
        public string VerhicleType { get; set; } = "";
        public string Plate { get; set; } = "";
        public string RegState { get; set; } = "";
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        public string Color { get; set; } = "";

        public static IEqualityComparer<CsvDataInfo> Comparer { get { return TComparer.Create<CsvDataInfo>((obj1, obj2) => (obj1.VerhicleType?.Equals(obj2.VerhicleType, StringComparison.InvariantCultureIgnoreCase) ?? false)
        && (obj1.Plate?.Equals(obj2.Plate, StringComparison.InvariantCultureIgnoreCase) ?? false)
        && (obj1.RegState?.Equals(obj2.RegState, StringComparison.InvariantCultureIgnoreCase) ?? false)
        && (obj1.Make?.Equals(obj2.Make, StringComparison.InvariantCultureIgnoreCase) ?? false)
        && (obj1.Model?.Equals(obj2.Model, StringComparison.InvariantCultureIgnoreCase) ?? false)
        && (obj1.Color?.Equals(obj2.Color, StringComparison.InvariantCultureIgnoreCase) ?? false)
        
        ); } }
    }
}
