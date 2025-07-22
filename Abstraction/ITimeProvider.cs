using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPoster.Abstraction;

public interface ITimeProvider
{
    DateTime GetCurrentTime();
}
