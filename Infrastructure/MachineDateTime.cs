﻿using Application.Common;

namespace Infrastructure;
public class MachineDateTime: IDateTime
{
    public DateTime Now => DateTime.Now;
}
