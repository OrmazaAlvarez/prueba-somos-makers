﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Loans.Dtos
{
    public class LoansUpdateDto
    {
        public long Id { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
