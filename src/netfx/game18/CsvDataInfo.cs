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
        public string VehicleType { get; set; } = "";
        public string Plate { get; set; } = "";
        public string RegState { get; set; } = "";
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        public string Color { get; set; } = "";

        public static IEqualityComparer<CsvDataInfo> Comparer { get { return TComparer.Create<CsvDataInfo>((obj1, obj2) =>
        (obj1.Plate?.Equals(obj2.Plate, StringComparison.InvariantCultureIgnoreCase) ?? false)
        //&& (obj1.VerhicleType?.Equals(obj2.VerhicleType, StringComparison.InvariantCultureIgnoreCase) ?? false)
        //&& (obj1.RegState?.Equals(obj2.RegState, StringComparison.InvariantCultureIgnoreCase) ?? false)
        //&& (obj1.Make?.Equals(obj2.Make, StringComparison.InvariantCultureIgnoreCase) ?? false)
        //&& (obj1.Model?.Equals(obj2.Model, StringComparison.InvariantCultureIgnoreCase) ?? false)
        //&& (obj1.Color?.Equals(obj2.Color, StringComparison.InvariantCultureIgnoreCase) ?? false)
        ); } }

        public CsvDataInfo() { }
        public CsvDataInfo(CsvDataInfo obj) {
            VehicleType = obj.VehicleType;
            Plate = obj.Plate;
            RegState = obj.RegState;
            Make = obj.Make;
            Model = obj.Model;
            Color = obj.Color;
        }
        public CsvDataInfo GetDiff(CsvDataInfo originalObj) {
            CsvDataInfo result = new CsvDataInfo {
                Plate = Plate
            };
            bool hasDiff = false;
            if(!VehicleType?.Equals(originalObj.VehicleType, StringComparison.InvariantCultureIgnoreCase) ?? false)
            {
                result.VehicleType = VehicleType;
                hasDiff = true;
            }
            if (!RegState?.Equals(originalObj.RegState, StringComparison.InvariantCultureIgnoreCase) ?? false)
            {
                result.RegState = RegState;
                hasDiff = true;
            }
            if (!Make?.Equals(originalObj.Make, StringComparison.InvariantCultureIgnoreCase) ?? false)
            {
                result.Make = Make;
                hasDiff = true;
            }
            if (!Model?.Equals(originalObj.Model, StringComparison.InvariantCultureIgnoreCase) ?? false)
            {
                result.Model = Model;
                hasDiff = true;
            }
            if (!Color?.Equals(originalObj.Color, StringComparison.InvariantCultureIgnoreCase) ?? false)
            {
                result.Color = Color;
                hasDiff = true;
            }
            if(hasDiff)
            {
                return result;
            }
            return null;
        }
    }
}
