﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Exceptions
{
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException()
        {

        }
        public UserNotFoundException(string message):base(message)
        {

        }
    }
}
