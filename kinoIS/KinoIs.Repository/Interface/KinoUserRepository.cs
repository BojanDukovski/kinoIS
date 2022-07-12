using KinoIS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinoIs.Repository.Interface
{
    public interface KinoUserRepository
    {
        KinoUser findById(string id);
        KinoUser Update(KinoUser user);
    }
}
