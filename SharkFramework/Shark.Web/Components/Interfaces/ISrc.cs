using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.Web.Components.Interfaces
{
    public interface ISrc
    {
        string Src { get; }
        public void ValidateSrc(string expectedSrc)
        {
            Helpers.ComponentHelper.WaitUntil(() => Src.Equals(expectedSrc));
        }
    }
}
