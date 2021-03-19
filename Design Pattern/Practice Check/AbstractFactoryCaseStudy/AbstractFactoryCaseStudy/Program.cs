using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryCaseStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            CarType ctype = CarType.LUXURY;
            Location loc = Location.INDIA;

            var fg = new FactoryGetter();
            fg.GetCar(ctype, loc);
        }
    }

    public enum CarType
    {
        MICRO, MINI, LUXURY
    }
    public enum Location
    {
        DEFAULT, USA, INDIA
    }
}
