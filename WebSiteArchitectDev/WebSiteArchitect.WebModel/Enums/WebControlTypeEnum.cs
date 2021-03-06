﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WebSiteArchitect.WebModel.Enums
{
    public enum WebControlTypeEnum
    {
        [Description("Button")]
        button,

        [Description("EmptySpace")]
        emptySpace,

        [Description("Label")]
        label,

        [Description("Input")]
        input,

        [Description("Select")]
        select,

        [Description("Panel")]
        panel,

        [Description("Row")]
        row,

        [Description("Image")]
        image


    }
}
