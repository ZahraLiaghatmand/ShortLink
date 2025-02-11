using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application.Common.Interfaces
{
    public interface IShortCodeGenerator
    {
        string Generator(string url);
    }
}
