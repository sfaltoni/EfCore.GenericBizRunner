﻿// Copyright (c) 2018 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Threading.Tasks;
using GenericBizRunner;
using Microsoft.EntityFrameworkCore;
using TestBizLayer.BizDTOs;
using TestBizLayer.DbForTransactions;

namespace TestBizLayer.ActionsAsync.Concrete
{
    public class BizActionInOutWriteDbAsync : BizActionStatus, IBizActionInOutWriteDbAsync
    {
        private readonly TestDbContext _context;

        public BizActionInOutWriteDbAsync(TestDbContext context)
        {
            _context = context;
        }

        public async Task<BizDataOut> BizActionAsync(BizDataIn inputData)
        {
            if (inputData.Num >= 0)
            {
                _context.Add(new LogEntry(inputData.Num.ToString()));
                Message = "All Ok";
            }
            else
            {
                AddError("Error");
            }
            return new BizDataOut("Result");
        }
    }
}