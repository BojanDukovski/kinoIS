using System;
using System.Collections.Generic;
using System.Text;
using KinoIS.Domain.Models;

namespace KinoIS.Service.Interface
{
    public interface KinoUserService
    {
        KinoUser findById(string id);
    }
}
