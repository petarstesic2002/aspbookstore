﻿using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ASPProjekat.ApplicationLayer.Commands
{
    public interface ICreateOrder:ICommand<CreateOrderDto>
    {
    }
}
